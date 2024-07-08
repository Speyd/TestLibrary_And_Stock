using System.Security.Cryptography;
using System.Globalization;


namespace RandomLibrary
{
    using static RandomHelper;
    file class RandomHelper
    {
        public static int getDecimalPlaces(double number)
        {
            string numberString = number.ToString(CultureInfo.InvariantCulture);
            int decimalIndex = numberString.IndexOf('.');

            if (decimalIndex == -1)
                return 0;

            return numberString.Length - decimalIndex - 1;
        }

        public static int getAmountNullString(string?[] text)
        {
            int amountNull = 0;

            foreach(string? line in text)
            {
                if (line is null)
                    amountNull++;
            }

            return amountNull;
        }
    }


    public class Randomizer
    {
        private Random random = new Random();


        public int integerRange(int min, int max)
        {
            return random.Next(min, max);
        }
        public double floatRange(double min, double max, int decimalPlaces = 0)
        {
            double number = random.NextDouble() * (max - min) + min;

            if(decimalPlaces >= 0 && decimalPlaces <= getDecimalPlaces(number))
                number = Math.Round(number, decimalPlaces);

            return number;
        }

        public string stringRange()
        {
            string result = "";

            int lenght = integerRange(1, 32);
            for (int i = 0; i < lenght; i++)
                result += (char)integerRange(65, 122);

            return result;

        }

        public string stringRange(string? text)
        {
            if (text == null)
                return string.Empty;

            string result = "";

            for (int i = 0; i < text.Length; i++)
                result += text[integerRange(0, text.Length)];

            return result;
        }

        public string stringRange(string? text, int amountSymbol = 0)
        {
            if(text == null)
                return string.Empty;

            else if (amountSymbol <= 0)
                amountSymbol = integerRange(1, 100);


            string result = "";

            for (int i = 0; i < amountSymbol; i++)
                result += text[integerRange(0, text.Length)];

            return result;

        }

        public string stringRange(string?[] text, int amountSymbol = -1)
        {
            if (amountSymbol < 0)
                amountSymbol = integerRange(1, 100);

            string result = "";
            int amountNull = getAmountNullString(text);


            while (amountSymbol != text.Length && amountNull != text.Length)
            {
                foreach (string? line in text)
                {
                    if (result.Length == amountSymbol)
                        return result;
                    else if (line is null)
                        continue;

                    result += line[integerRange(0, line.Length)];
                }
            }
            
            return result;
        }
    }
}
