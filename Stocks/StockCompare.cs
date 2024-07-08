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
    public class StockComparer(Stock stock)
    {
        public Product? findProduct(in int id)
        {
            int amountProduct = stock.getAmountProducts();
            for (int i = 0; i < amountProduct; i++)
            {
                if (stock.getProduct(i)?.Id == id)
                    return stock.getProduct(i);
            }

            return null;
        }
        public Product? findProduct(Product? findProduct)
        {
            if (findProduct is null)
            {
                HelpLoger.addLoger("StockComparer.findProduct(): findProduct is null", DateTime.Now, new StackTrace(true));
                return null;
            }

            int amountProduct = stock.getAmountProducts();
            for (int i = 0; i < amountProduct; i++)
            {
                if (stock.getProduct(i) == findProduct)
                    return stock.getProduct(i);
            }

            return null;
        }
        public List<Product?>? findProduct(Stock? findStockProduct)
        {
            if (findStockProduct is null)
            {
                HelpLoger.addLoger("StockComparer.findProduct(): findProduct is null", DateTime.Now, new StackTrace(true));
                return null;
            }
            if (findStockProduct.getListProduct() is null)
            {
                HelpLoger.addLoger("StockComparer.findProduct(): findProduct.getListProduct() is null", DateTime.Now, new StackTrace(true));
                return null;
            }

            List<Product?>? products = new List<Product?>();
            foreach (Product product in findStockProduct.getListProduct())
            {
                if (findProduct(product) is not null)
                    products.Add(product);
            }

            return products;
        }
        public List<Product?>? findProductFileStock(string path)        
        {
            Stock? fileStock = StockConverter.JsonFileToStock(path);

            if (fileStock == null)
                return null;

            return findProduct(fileStock);
        }
        public List<Product?>? findProductFileStocks(string path)
        {
            List<Stock>? fileStocks = StockConverter.JsonFileToStocks(path);


            if (fileStocks == null)
                return null;


            List<Product?>? products = new List<Product?>();
            foreach (Stock tempStock in fileStocks)
            {
                List<Product?>? tempProducts = findProduct(tempStock);
                if (tempProducts is not null)
                    products.AddRange(tempProducts);
            }

            return products;
        }
        public bool comparisonProduct(Product addProduct)
        {
            if (addProduct is null)
                return false;


            if (findProduct(addProduct) is not null)
                return true;
            else
                return false;
        }
    }
}
