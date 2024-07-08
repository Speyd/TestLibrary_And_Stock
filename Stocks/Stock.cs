using System.Text;
using Newtonsoft.Json;
using Products;

namespace Stocks
{
    public class Stock
    {
        public string Name { get; init; }
        public int MaxCountProduct { get; init; }
        public int CountProduct { get; set; } = 0;

        [JsonProperty]
        private List<Product>? products;
        private StockComparer stockComparer;
        private StockManipulator stockManipulator;

        public Stock(string name = "ERROR_NAME", int maxCountProduct = 1, List<Product>? _products = null)
        {
            Name = name;

            MaxCountProduct = maxCountProduct;
            products = _products ?? new List<Product>();
            stockComparer = new StockComparer(this);
            stockManipulator = new StockManipulator(this);
        }

        public string show()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{Name}\n");
            stringBuilder.AppendLine($"Max count product: {MaxCountProduct}\n");
            stringBuilder.AppendLine($"Count product: {CountProduct}\n");


            if (products is null || products.Count == 0)
                return stringBuilder.ToString() + "LIST_EMPTY";



            foreach (Product item in products)
                stringBuilder.AppendLine(item.show());

            return stringBuilder.ToString();
        }
        public StockComparer getStockComparer() => stockComparer;
        public List<Product>? getListProduct() => products;
        public int getAmountProducts()
        {
            return products is not null ? products.Count : 0;
        }
        public StockManipulator getStockManipulator() => stockManipulator;
        public Product? getProduct(in int index)
        {
            return index >= 0 && index < products?.Count ? products?[index] : null;
        }
    }
}
