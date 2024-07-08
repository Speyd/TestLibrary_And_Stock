using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stocks;

namespace InfoConverter
{
    public class InfoConverter
    {
        public static void StockToJsonFile(Stock stock, string path, bool rewrite = false)
        {
            if (!File.Exists(path))
                File.Create(path).Close();

            if (rewrite)
                File.WriteAllText(path, string.Empty);

            File.AppendAllText(path, JsonConvert.SerializeObject(stock, Newtonsoft.Json.Formatting.Indented));
        }
        public static void StockToJsonFile(List<Stock> stocks, string path, bool rewrite = false)
        {
            if (!File.Exists(path))
                File.Create(path).Close();

            if (rewrite)
                File.WriteAllText(path, string.Empty);

            File.AppendAllText(path, JsonConvert.SerializeObject(stocks, Newtonsoft.Json.Formatting.Indented));
        }
        public static Stock? JsonFileToStock(string path)
        {
            if (!File.Exists(path))
                return null;

            Stock? stock = null;
            try
            {
                string jsonContent = File.ReadAllText(path);
                stock = JsonConvert.DeserializeObject<Stock>(jsonContent) ?? new Stock();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error DeserializeObject: " + ex.Message);
            }

            return stock;

        }
        public static List<Stock>? JsonFileToStocks(string path)
        {
            if (!File.Exists(path))
                return null;

            List<Stock>? stocks = null;
            try
            {
                string jsonContent = File.ReadAllText(path);
                stocks = JsonConvert.DeserializeObject<List<Stock>>(jsonContent) ?? new List<Stock>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error DeserializeObject: " + ex.Message);
            }

            return stocks;
        }
    }
}
