using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products;
using Logers;

namespace Stocks
{
    public class StockManipulator(Stock stock)
    {
        public void deleteProduct(in Product? deleteProduct)
        {
            if (deleteProduct is null)
            {
                HelpLoger.addLoger("Stock.deleteProduct(): deleteProduct is null", DateTime.Now, new StackTrace(true));
                return;
            }

            stock.getListProduct()?.Remove(deleteProduct);
        }
        public void deleteProduct(in int id)
        {
            Product? deleteProduct = stock.getStockComparer().findProduct(id);

            if (deleteProduct is not null)
                stock.getListProduct()?.Remove(deleteProduct);
        }
        public void addProduct(Product? product)
        {
            if (product is null)
            {
                HelpLoger.addLoger("Stock.addProduct(): product is null", DateTime.Now, new StackTrace(true));
                return;
            }
            else if (stock.CountProduct >= stock.MaxCountProduct)
            {
                HelpLoger.addLoger("Stock.addProduct(): CountProduct == MaxCountProduct", DateTime.Now, new StackTrace(true));
                return;
            }



            Product? findProduct = stock.getStockComparer().findProduct(product);

            if (findProduct is null)
            {
                stock.getListProduct()?.Add(product);
                stock.CountProduct++;
            }
            else
                findProduct.Amount += product.Amount;
        }
        public void addProduct(in int id, in string name = "ERROR_NAME", in string description = "ERROR_NAME", in int amount = 1)
        {
            addProduct(new Product(id, name, description, amount));
        }
    }
}
