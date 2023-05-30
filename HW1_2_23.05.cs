
using System.Text;

namespace Lesson1_2
{
    enum Digits
    {
        one = 49, two, three, four, five, six, seven, eigth, nine
    }
    enum SecondDozen
    {
        ten = 48, eleven, twelve, thirteen, fourteen, fifteen, sixteen, seventeen, eighteen, nineteen
    }
    enum Dozens
    {
        twenty = 50, thirty, forty, fifty, sixty, seventy, eighty, ninety
    }

    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                //Console.OutputEncoding = Encoding.UTF8;
                Console.Write("\nEnter task number, or press ENTER to exit: ");
                string? choose = Console.ReadLine();

                switch (choose)
                {
                    case "1":
                        //Знайти позицію літери в алфавіті та перевести її в інший регістр

                        Console.WriteLine("TASK 1: Знайти позицію літери в алфавіті та перевести її в інший регістр\n");
                        try
                        {
                            string alphabet = "abcdefghijklmnopqrstuvwxyz, ABCDEFGHIJKLMNOPQRSTUVWXYZ.\n" +
                                "абвгґдеєжзиіїйклмнопрстуфхцчш, АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШ.";  // абетка для прикладу, можна використати будь-який текст, або ввести з консолі:
                            //Console.WriteLine("Enter your text");
                            //string alphabet = Console.ReadLine();
                            FindPositionAndConvertCase(alphabet);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Error: incorrect letter! Exiting...");
                        }
                        break;

                    case "2":


                        //Розділювач рядка. Дана строка та символ, потрібно розділити строку на кілька строк (масив строк) виходячи із заданого символу.
                        //Наприклад: строка = "Лондон, Париж, Рим", а символ = ','.Результат = string[] { "Лондон", "Париж", "Рим" }.

                        Console.WriteLine("\n\n\nTASK 2: Розділювач рядка\n");
                        string sentence = "Лондон, Париж, Рим";
                        Console.WriteLine("Input list: " + sentence);
                        char separator = ',';

                        TextSplitter(sentence, separator);
                        break;

                    case "3":
                        //Пошук підстроки у строці.

                        Console.WriteLine("\n\n\nTASK 3: Пошук підстроки у строці\n");
                        string text = "b aaac";
                        string subText1 = "b a";
                        string subText2 = "aac";
                        string subText3 = "b aaac";

                        if (SubstringValidator(text, subText1))
                            Console.WriteLine($"Text\n\"{text}\"\ncontaines subsrting\n\"{subText1}\"\n");
                        if (!SubstringValidator(text, subText1))
                            Console.WriteLine($"Text\n\"{text}\"\ndoesn't containes subsrting\n\"{subText1}\"\n");

                        if (SubstringValidator(text, subText2))
                            Console.WriteLine($"Text\n\"{text}\"\ncontaines subsrting\n\"{subText2}\"\n");
                        if (!SubstringValidator(text, subText2))
                            Console.WriteLine($"Text\n\"{text}\"\ndoesn't containes subsrting\n\"{subText2}\"\n");

                        if (SubstringValidator(text, subText3))
                            Console.WriteLine($"Text\n\"{text}\"\ncontaines subsrting\n\"{subText3}\"\n");
                        if (!SubstringValidator(text, subText3))
                            Console.WriteLine($"Text\n\"{text}\"\ndoesn't containes subsrting\n\"{subText3}\"\n");

                        break;

                    case "4":
                        //Написати програму, яка виводить число літерами. Приклад: 117 - сто сімнадцять

                        Console.WriteLine("\n\n\nTASK 4: Написати програму, яка виводить число літерами\n");
                        try
                        {
                            Console.Write("Enter an integer number from -999 to 999: ");
                            int number = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine($"\nNumber {number} in words: {DisassNum(number)}");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Error: incorrect format of number!");
                        }
                        break;

                    case "5":
                        //Поміняти місцями значення двох змінних (типу int) (без використання 3й)
                        Console.WriteLine("\n\n\nTASK 5: Поміняти місцями значення двох змінних (типу int) (без використання 3й)\n");

                        try
                        {
                            Console.Write("Enter first number: ");
                            int num1 = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter first number: ");
                            int num2 = Convert.ToInt32(Console.ReadLine());

                            NumberChanger(num1, num2);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Error: incorrect format of number!");
                        }
                        break;

                    default:
                        Console.WriteLine("Exit program.");
                        return;
                }
            }
        }
        public static void FindPositionAndConvertCase(string text)
        {
            Console.WriteLine($"Initial text:\n{text}\n");

            Console.Write("Enter your letter to find and change case: ");
            char letter = Convert.ToChar(Console.ReadLine());
            if (!Char.IsLetter(letter))
                throw new FormatException();

            StringBuilder newText = new StringBuilder(text);
            bool flag = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == letter && Char.IsLower(text[i]))
                {
                    newText[i] = Char.ToUpper(letter);
                    Console.WriteLine($"Letter {letter} was found on {i + 1} position. The case is changed");
                    flag = true;
                }
                else if (text[i] == letter && Char.IsUpper(text[i]))
                {
                    newText[i] = Char.ToLower(letter);
                    Console.WriteLine($"Letter {letter} was found on {i + 1} position. The case is changed");
                    flag = true;
                }
            }
            if (flag)
                Console.WriteLine($"\nNew text:\n{newText}");
            else
                Console.WriteLine("Letter not found in the text");
        }

        public static void TextSplitter (string text, char separator)
        {
            if (text.Length == 0)                       // перевірка на відсутність тексту
            {
                Console.WriteLine("No text!");
                return;
            }

            int counter = 0;                            // визначаємо розмір майбутнього масиву строк
            for (int i = 0; i < text.Length; i++)       
            {
                if (text[i] == separator)
                    counter++;
            }

            if (counter == 0)                           // перевірка на відсутність роздільника в тексті
            {
                Console.WriteLine("No separators im the text!");
                return;
            }

            string[] splitText = new string[counter + 1];
            int j = 0;

            for (int i = 0; i < counter + 1; i++)
            {
                string lineToArray = string.Empty;
                for (; j < text.Length; j++)
                {
                    if (text[j] != separator)
                        lineToArray += text[j];
                    else
                    {
                        j++;
                        break;
                    }
                }
                splitText[i] = lineToArray;
            }
            foreach (string s in splitText)
                Console.WriteLine(s);
        }

        public static bool SubstringValidator(string text, string subtext)
        {
            bool result = false;

            if (text.Length < 0)                                        // перевірка довжини строки (в цілому тут можна кидати виключення)
                return result;

            if (text.Length == 0 || subtext.Length == 0)                // перевірка довжини підстроки відносно строки (так само можна з виключенням)
                return result;

            int marker = 0;                                             // маркер для повертання у разі неспівпадання 2-го і далі символа
            
            for (int i = 0, j = 0; i < text.Length; )                   
            {
                if (text[i] == subtext[j])                              // порівнюємо
                {
                    i++;
                    j++;
                    if (j == subtext.Length)
                    {
                        result = true;
                        break;
                    }
                    continue;
                }
                else
                {
                    if (marker < i)
                    {
                        i = marker + 1;
                        j = 0;
                    }
                    else
                    {
                        i++;
                        j = 0;
                    }
                    marker = i;
                }
            }
            return result;


        }

        public static StringBuilder DisassNum (int num)
        {
            StringBuilder numInWords = new StringBuilder();

            if (num == 0)
                return numInWords.Append("Zero");                   // повертає при нулі

            if (num < 0)
            {
                numInWords.Append("Minus ");                        // у випадку від'ємного значення 
                num *= -1;
            }

            string strNum = num.ToString();                         // працюємо зі строкою

            switch(strNum.Length)                                   // основний блок формування
            {
                case 1:                                             // 1-цифрове число
                    numInWords.Append((Digits)strNum[0]);
                    break;

                case 2:                                             // 2-цифрове число
                    if (strNum[0] == '1')
                    {
                        numInWords.Append((SecondDozen)strNum[1]);                          // + 10...19
                        break;
                    }
                    else
                        numInWords.Append((Dozens)strNum[0]);                               // + десятки
                    if (strNum[1] != '0')
                        numInWords.Append(" " + (Digits)strNum[1]);                         // + одиниці
                    break;

                case 3:                                             // 3-цифрове число
                    numInWords.Append((Digits)strNum[0] + " hundred");                      // + сотні
                    if (strNum[1] == '0' && strNum[2] == '0')
                        break;
                    if (strNum[1] == '1')                                                  
                    {
                        numInWords.Append(" " + (SecondDozen)strNum[2]);                    // + 10...19
                        break;
                    }
                    else if (strNum[1] != '0')                                             
                        numInWords.Append(" " + (Dozens)strNum[1]);                         // + десятки
                    if (strNum[2] != '0')                                                  
                        numInWords.Append(" " + (Digits)strNum[2]);                         // + одиниці
                    break;

                default:
                    Console.WriteLine("Error: only numbers from -999 to 999!");
                    break;
            }
            numInWords.Insert(0, Char.ToUpper(numInWords[0]));          // виправляємо першу літеру на велику.
            numInWords.Remove(1, 1);
            return numInWords;
        }

        public static void NumberChanger (int num1, int num2)
        {
            Console.WriteLine($"First number: {num1}, second number {num2}");

            num1 -= num2;
            num2 += num1;
            num1 = num2 - num1;

            Console.WriteLine($"First number: {num1}, second number {num2}");
        }

    }
}
