using System.Security.Cryptography;

namespace RandomLibrary1
{

    //using static DelimiterNumber;

    //file class DelimiterNumber
    //{
    //    public static int getWholePart(double number) 
    //    {
    //        return (int)number;
    //    }
    //    public static int getDecimalPlaces(double number)
    //    {
    //        string numberString = number.ToString(System.Globalization.CultureInfo.InvariantCulture);
    //        int decimalIndex = numberString.IndexOf('.');

    //        if (decimalIndex == -1)
    //            return 0;

    //        return numberString.Length - decimalIndex - 1;
    //    }
    //    public static int getFractionalPart(double number) 
    //    { 
    //        number = (int)(number - (int)number);
    //        int decimalPlaces = getDecimalPlaces(number);

    //        for (int i = 0; i < decimalPlaces; i++)
    //            number = 10;

    //        return (int)number;
    //    }
    //}

    //file class NumberCombiner
    //{
    //    public int getCombineNumber(double firtPart, int secondPart)
    //}

    public class Randomizer
    {


        private Random random = new Random();
        public int randomIntegerRange(int min, int max)
        {
            return random.Next(min, max);
        }

        public double randomFloatRange(float min, float max)
        {
            //int fisrtPart = randomIntegerRange((int)startNumber, (int)endNumber);
            //int secondPard = randomFloatRange(getFractionalPart(startNumber), getFractionalPart(endNumber));
            return random.NextDouble() * (max - min) + min;
        }
    }
}
