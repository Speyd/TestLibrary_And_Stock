using Newtonsoft.Json;

namespace Products
{
    public class Product : IEquatable<Product>
    {
        public int Id { get; init; }
        public int Amount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Product(int id, string name, string description, int amount = 1)
        {
            Id = id;
            Amount = amount;
            Name = name;
            Description = description;
        }
        public bool Equals(Product? product)
        {
            if (product is null) return false;

            if (product.Id == this.Id &&
               product.Name == this.Name &&
               product.Description == this.Description)
            {
                return true;
            }
            else
                return false;
        }
        public static bool operator ==(Product product_1, Product product_2)
        {
            if (product_1 is null)
                return product_2 is null;

            return product_1.Equals(product_2);
        }
        public static bool operator !=(Product p1, Product p2)
        {
            return !(p1 == p2);
        }
        public string show() => JsonConvert.SerializeObject(this);
    }
}
