namespace ConsoleApp4
{

    internal class Program
    {
        // Задание на класс стринг
        static void Main()
        {
            Console.Write("Введите строку: ");
            string input = Console.ReadLine();

            Console.WriteLine("Уникальные перестановки:");
            GetPermutations(input, 0, input.Length - 1);


            void GetPermutations(string str, int left, int right)
        {
            if (left == right)
            {
                Console.WriteLine(str);
            }
            else
            {
                for (int i = left; i <= right; i++)
                {
                    str = Swap(str, left, i);
                    GetPermutations(str, left + 1, right);
                    str = Swap(str, left, i);
                }
            }
        }

            string Swap(string str, int i, int j)
        {
            char[] charArray = str.ToCharArray();
            char temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            return new string(charArray);
        }


            // Задание на двумерный массив

            int N = 5;
            int M = 6;
            int[,] array = new int[N,M];

            int value = 1;

            for (int col = 0; col < M; col++)
            {
                for (int row = 0; row < N; row++)
                {
                    array[row, col] = value;
                    value++;
                }
            }

            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < M; col++)
                {
                    Console.Write($"{array[row, col],4}");
                }
                Console.WriteLine();
            }

            // Задание на одномерный массив

            Console.Write("Введите число от 0 до 1 000 000: ");
            if (int.TryParse(Console.ReadLine(), out int number) && number >= 0 && number <= 1000000)
            {
                Console.WriteLine($"Словами: {NumberToWords(number)}");
            }
            else
            {
                Console.WriteLine("Ошибка: введите корректное число в диапазоне от 0 до 1 000 000.");
            }
        }

        static string NumberToWords(int number)
        {
            if (number == 0)
            {
                return "ноль";
            }

            if (number == 1000000)
            {
                return "один миллион";
            }

            string[] units = { "", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
            string[] teens = { "десять", "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };
            string[] tens = { "", "", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" };
            string[] hundreds = { "", "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };

            string words = "";

            int thousands = number / 1000;
            int remainder = number % 1000;

            if (thousands > 0)
            {
                words += $"{NumberToWords(thousands)} тысяча";
                if (thousands % 10 == 2 || thousands % 10 == 3 || thousands % 10 == 4)
                {
                    words += "и";
                }
                else if (thousands > 1)
                {
                    words += " ";
                }

                if (remainder > 0)
                {
                    words += " ";
                }
            }

            if (remainder >= 100)
            {
                words += hundreds[remainder / 100];
                remainder %= 100;

                if (remainder > 0) 
                { 
                    words += " "; 
                }
            }

            if (remainder >= 10 && remainder < 20)
            {
                words += teens[remainder - 10];
            }
            else if (remainder >= 20 || remainder > 0)
            {
                words += tens[remainder / 10];
                remainder %= 10;

                if (remainder > 0)
                {
                    words += " " + units[remainder];
                }
            }

            return words.Trim();


        }



    }

}
