using RandomLibrary;

Randomizer randomizer = new Randomizer();
Console.WriteLine(randomizer.integerRange(1, 10));
Console.WriteLine(randomizer.floatRange(1.1, 10.1, 200));
Console.WriteLine(randomizer.stringRange("6789qwer"));
Console.WriteLine(randomizer.stringRange("123qwer", 0));
Console.WriteLine(randomizer.stringRange(new string[]{ null , "123" }, -1));