
using System.Text;

namespace Lesson
{
    enum Digits
    {
        Zero, One, Two, Three, Four, Five, Six, Seven, Eigth, Nine
    }
    enum SecondDozen
    {
        Ten, Eleven, Twelve, Thirteen, Fourteen, Fifteen, Sixteen, Seventeen, Eighteen, Nineteen
    }
    enum Dozens
    {
        Twenty = 2, Thirty, Forty, Fifty, Sixty, Seventy, Eighty, Ninety
    }

    public class Program
    {
        public static void Main() 
        {
            while (true)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.Write("\nEnter task number, or press ENTER to exit: ");
                string? choose = Console.ReadLine();

                switch (choose)
                {
                    case "1":
                        //Знайти позицію літери в алфавіті та перевести її в інший регістр

                        Console.WriteLine("TASK 1: Знайти позицію літери в алфавіті та перевести її в інший регістр\n");
                        try
                        {
                            string alphabet = "abcdefghijklmnopqrstuvwxyz";

                            Console.Write("Enter your letter in the low case: ");
                            char letter = Convert.ToChar(Console.ReadLine());

                            FindPositionAndConvertCase(alphabet, letter);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Error: incorrect letter! Exiting...");
                        }
                        continue;

                    case "2":


                        //Розділювач рядка. Дана строка та символ, потрібно розділити строку на кілька строк (масив строк) виходячи із заданого символу.
                        //Наприклад: строка = "Лондон, Париж, Рим", а символ = ','.Результат = string[] { "Лондон", "Париж", "Рим" }.

                        Console.WriteLine("\n\n\nTASK 2: Розділювач рядка\n");
                        string sentence = "Лондон, Париж, Рим";
                        Console.WriteLine("Input list: " + sentence);

                        char splitter = ',';

                        string[] splitted = sentence.Split(splitter, StringSplitOptions.TrimEntries);

                        foreach (string s in splitted)
                            Console.WriteLine(s);
                        continue;

                    case "3":
                        //Пошук підстроки у строці.

                        Console.WriteLine("\n\n\nTASK 3: Пошук підстроки у строці\n");
                        string text = "a set of words that is complete in itself, conveying a statement, question, exclamation, or command";
                        string subText1 = "conveying a statement";
                        string subText2 = "conveying the statement";


                        if (text.Contains(subText1))
                            Console.WriteLine($"Text\n\"{text}\"\ncontaines subsrting\n\"{subText1}\"\n");
                        if (!text.Contains(subText2))
                            Console.WriteLine($"Text\n\"{text}\"\ndoesn't containes subsrting\n\"{subText2}\"");
                        continue;

                    case "4":
                        //Написати програму, яка виводить число літерами. Приклад: 117 - сто сімнадцять

                        Console.WriteLine("\n\n\nTASK 4: Написати програму, яка виводить число літерами\n");
                        try
                        {
                            Console.Write("Enter an integer number from -999 to 999: ");
                            int number = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine(DisassemblingNumber(number));
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Error: incorrect format of number!");
                        }
                        continue;

                    case "5":
                        //Поміняти місцями значення двох змінних (типу int) (без використання 3й)
                        Console.WriteLine("\n\n\nTASK 5: Поміняти місцями значення двох змінних (типу int) (без використання 3й)\n");

                        int first = 10, second = 20;
                        Console.WriteLine($"First number: {first}, second number {second}");

                        (first, second) = (second, first);
                        Console.WriteLine($"First number: {first}, second number {second}");
                        continue;

                    default:
                        Console.WriteLine("Exit program.");
                        return;
                }
            }
        }
        public static void FindPositionAndConvertCase(string text, char letter)
        {
            if (text.Contains(letter))
                Console.WriteLine($"Letter \"{letter}\" is on {text.IndexOf(letter) + 1} position of alphabet\n" +
                    $"New alphabet: {text.Replace(letter, char.ToUpper(letter))}");
            else
                Console.WriteLine("Error: incorrect letter! Exiting...");
        }

        public static StringBuilder DisassemblingNumber(int num)
        {
            List<int> list = new List<int>();

            const int step = 10;
            int div = 1;

            for (int i = 0; i < num.ToString().Length; i++)
            {
                list.Insert(0, Math.Abs(num / div % step));
                div *= step;
            }

            return NumberToWords(list);
        }

        public static StringBuilder NumberToWords (List<int> digits, string sign = "")
        {
            StringBuilder numInWords = new StringBuilder();
            numInWords.Append(sign);
            if (digits.Count == 0)                      // перевірка на нульове значення
            {
                numInWords.Append(Digits.Zero);
                return numInWords;
            }   
            if (digits[0] == 0)                         // рекурсія у випадку від'ємного значення
            {
                digits.RemoveAt(0);
                return NumberToWords(digits, "Minus ");
            }       
            switch (digits.Count)                       // основний блок формування
            {
                case 1:                                             // 1-цифрове число
                    numInWords.Append((Digits)digits[0]);
                    return numInWords;

                case 2:                                             // 2-цифрове число
                    if (digits[0] == 1)
                        numInWords.Append((SecondDozen)digits[1]);
                    else if (digits[1] != 0)
                    {
                        numInWords.Append((Dozens)digits[0] + " ");
                        numInWords.Append(((Digits)digits[1]).ToString().ToLower());
                    }
                    else
                        numInWords.Append((Dozens)digits[0]);
                    return numInWords;

                case 3:                                             // 3-цифрове число
                    if (digits[1] == 0 && digits[2] == 0)
                        numInWords.Append((Digits)digits[0] + " hundred");
                    else if (digits[1] == 0 && digits[2] != 0)
                        numInWords.Append((Digits)digits[0] + " hundred " + ((Digits)digits[2]).ToString().ToLower());
                    else if (digits[1] == 1)
                        numInWords.Append((Digits)digits[0] + " hundred " + ((SecondDozen)digits[2]).ToString().ToLower());
                    else if (digits[2] != 0)
                        numInWords.Append((Digits)digits[0] + " hundred " + ((Dozens)digits[1]).ToString().ToLower() + " " + ((Digits)digits[2]).ToString().ToLower());
                    else
                        numInWords.Append((Digits)digits[0] + " hundred " + ((Dozens)digits[1]).ToString().ToLower());
                    return numInWords;

                default:
                    Console.WriteLine("Error: only numbers from -999 to 999!");
                    return numInWords.Clear();
            }
        }
    }
}
