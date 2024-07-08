using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System;
using System.Net.Http.Json;
using RandomLibrary;
using Stocks;
using Products;
using Logers;

string path = "D:\\C++ проекты\\TestLibrary\\Simulator_Stocks\\Stocks.json";
Randomizer randomizer = new Randomizer();

#region Code_for_task
Stock randomStock = new Stock(randomizer.stringRange(new string[]{"BIMBAM", "bombom"}, 6), randomizer.integerRange(1,25));
randomStock.getStockManipulator().addProduct(randomizer.integerRange(1, 100), randomizer.stringRange("qwertyyuioasdfghj", 5));
Console.WriteLine(randomStock.show());
#endregion

Stock stock = new Stock("Bimba", 1);
Console.WriteLine(stock.show());

stock.getStockManipulator().addProduct(2, "Loll", "Nonett");
Console.WriteLine(stock.show());
stock.getStockManipulator().addProduct(2, "Lolll", "Nonett", 10);
Console.WriteLine(stock.show());


List<Product?>? product1 = stock.getStockComparer().findProductFileStock(path);
Console.WriteLine("FINDER PRODUCT");
if (product1 is not null)
{
    foreach (Product? product in product1)
    {
        Console.WriteLine(product?.show());
    }
}

Console.WriteLine($"Amount loger: {Loger.Count}");

stock.getStockManipulator().deleteProduct(null);
Console.WriteLine(stock.show());

Console.WriteLine(HelpLoger.showLog());



#region Adding_&_Reading_File
if (!File.Exists(path))
    File.Create(path).Close();

File.WriteAllText(path, string.Empty);
for (int i = 0; i < stock?.getAmountProducts(); i++)
{
    File.AppendAllText(path, JsonConvert.SerializeObject(stock?.getProduct(i), Formatting.Indented));
}



string path1 = "D:\\C++ проекты\\TestLibrary\\Simulator_Stocks\\Stocks.json";
if (!File.Exists(path1))
    File.Create(path1).Close();

File.WriteAllText(path1, string.Empty);
File.AppendAllText(path1, JsonConvert.SerializeObject(stock, Formatting.Indented));




string path2 = "D:\\C++ проекты\\TestLibrary\\Simulator_Stocks\\LogerInfo.txt";
if (!File.Exists(path2))
    File.Create(path2).Close();

File.WriteAllText(path2, string.Empty);
File.AppendAllText(path2, Loger.showLog());
#endregion