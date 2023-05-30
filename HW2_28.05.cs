
using System.Text;

namespace Lesson2
{

    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                //Console.OutputEncoding = Encoding.UTF8;
                Console.Write("\nEnter task number, or press ENTER to exit: ");
                string? choose = Console.ReadLine();

                switch (choose)
                {
                    case "1":
                        Console.WriteLine("TASK 1: Реверс строки/ масиву.Без додаткового масиву. Складність О(n)\n");
                        // для строки:
                        string text = "qwerty";
                        Reverse(text);

                        // для масивів
                        int[] intArray = new int[] { 1, 2, 3, 4, 5 };
                        Reverse(intArray);

                        float[] floatArray = new float[] { 1.56f, 2f, 3f, 4.4f, 5f };
                        Reverse(floatArray);

                        decimal[] decimalArray = new decimal[] { 0.2m, 1.9m, 9.5m, -32.4m, 56.7m };
                        Reverse(decimalArray);

                        break;

                    case "2":
                        Console.WriteLine("\n\n\nTASK 2: Перевірка гіпотези Сиракуз: Візьмемо будь-яке натуральне число.\n" +
                            " Якщо воно парне - розділимо його навпіл, якщо непарне - помножимо на 3, додамо 1 і розділимо навпіл.\n" +
                            "Повторимо ці дії із знову отриманим числом.\n" +
                            "Гіпотеза свідчить, незалежно від вибору першого числа рано чи пізно ми отримаємо 1.\n" +
                            "На вхід – число, при кожній зміні – роздрукувати число. Зробити рекурсивно.\r\n\n");
                        try
                        {
                            Console.Write("Enter your natural number: ");
                            int num = Convert.ToInt32(Console.ReadLine());
                            SyracuseCheker(num);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Error: incorrect format of number!");
                        }
                        break;

                    case "3":

                        Console.WriteLine("\n\n\nTASK 3: Фільтрування неприпустимих слів у строці. Має бути саме слова, а не частини слів\n");

                        // тестовий текст:
                        string userText = " To die: to sleep, to live;\tNo more.\n" +
                            "To die, to sleep,\vto live! ";
                        Console.WriteLine($"Text to check:\n\n{userText}\n\n");

                        string[] forbiddenWords = { "die", "live" };
                        Console.WriteLine("Words to remove:");
                        foreach (string item in forbiddenWords)
                            Console.Write($"\"{item}\" ");

                        Console.WriteLine("\n");

                        string[] words = TextDisassebler(userText);
                        WordsRemover(words, forbiddenWords);
                        break;

                    case "4":

                        Console.WriteLine("\n\n\nTASK 4: Генератор випадкових символів.На вхід у символів, на виході рядок з випадковими символами.\n");
                        try
                        {
                            Console.Write("Enter char's array size: ");
                            int num = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            foreach (char c in RandCharsGenerate(num))
                                Console.Write(c);
                            Console.WriteLine();
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Error: incorrect format of number!");
                        }
                        break;

                    case "5":
                        Console.WriteLine("\n\n\nTASK 5: \"Дірка\"(пропущене число) у масиві.\n" +
                                "Масив довжини N у випадковому порядку заповнений цілими числами з діапазону від 0 до N.\n" +
                                "Кожне число зустрічається в масиві трохи більше одного разу.Знайти відсутнє число(дірку).\n" +
                                "Є дуже простий та оригінальний спосіб вирішення. Складність алгоритму O(N).\n" +
                                "Використання додаткової пам'яті, пропорційної довжині масиву не допускається.\n\n ");

                        // створення масиву: якщо 2й параметр true - буде масив, де немає лише одного с N чисел,
                        // відповідно до умови завдання
                        int[] arrSingle = RandomArrCreator(10, true, out bool single);
                        FindMissingNumbers(arrSingle, single);

                        // інакше - можливе кілька відсутніх чисел (додатково, але там за допомогою стандартних методів для масивів)
                        int[] arrFew = RandomArrCreator(10, false, out bool few);
                        FindMissingNumbers(arrFew, few);

                        break;

                    case "6":

                        break;

                    default:
                        Console.WriteLine("Exit program.");
                        return;
                }
            }
        }

        static void Reverse(string input)
        {
            Console.WriteLine(input);

            // варіант 1 через StringBuilder:
            StringBuilder output = new StringBuilder(input.Length);

            int endIndex = input.Length - 1;
            for (int i = 0; i <= endIndex; i++)
            {
                output.Insert(i, input[i]);
                if (endIndex > i)
                    output.Insert(i, input[endIndex]);
                endIndex--;
            }
            Console.WriteLine(output.ToString());

            // варіант 2, лише вхідна строка
            int initLength = input.Length;

            for (int i = initLength - 1; i >= 0; i--)
                input += input[i];

            Console.WriteLine(input.Remove(0, initLength));
            Console.WriteLine();
        }

        static void Reverse<T>(T[] input)
        {
            foreach (T i in input)
                Console.Write(i + " ");
            Console.WriteLine();

            int endIndex = input.Length - 1;
            for (int i = 0; i < endIndex; i++)
            {
                var temp = input[i];
                input[i] = input[endIndex];
                input[endIndex] = temp;
                endIndex--;
            }
            foreach (T i in input)
                Console.Write(i + " ");

            Console.WriteLine();
        }

        static void SyracuseCheker(int num, int i = 0)     // і - необовїязковий параметр для рахування ітерацій рекурсії
        {
            if (num < 1)
            {
                Console.WriteLine("\nError: You have entered number less than 1.");
                return;
            }
            if (num == 1)
            {
                if (i == 0)
                {
                    Console.WriteLine("\nYou have entered 1. No calculations required");
                    return;
                }
                Console.WriteLine($"\nValue {num} has reached at {i} iteration.");
                return;
            }
            num = num != 1 && num % 2 != 0
                ? num * 3 + 1
                : num /= 2;
            Console.Write($"{num} ");

            SyracuseCheker(num, ++i);
        }

        static string[] TextDisassebler(string text)
        {
            char[] punctuation = {' ', ',', '.', '?', '!', '"', '(', ')', ';', ':', '\n', '\t', '\v'};
            int wordsCounter = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if ((text[i] == ' ' || text[i] == '\n' || text[i] == '\v' || text[i] == '\t') && i != 0 && i != text.Length - 1)
                    wordsCounter++;
            }
            string[] words = new string[wordsCounter + 1];
            int wordIdent = 0;
            string word = "";

            int startIndex = 0;
            int endIndex = text.Length;
            while ( startIndex < endIndex )
            {
                bool flag = true;

                for ( int i = 0; flag && i < punctuation.Length; i++ )
                {
                    if (text[startIndex] == punctuation[i])
                        flag = false;
                }
                if (flag)
                {
                    word += text[startIndex].ToString().ToLower();
                    startIndex++;
                    continue;
                }
                if (!flag && word.Length > 0)
                {
                    words[wordIdent] = word;
                    word = "";
                    wordIdent++;
                }
                startIndex++;
                //flag = true;
            }
            
            return words;
        }

        static void WordsRemover(string[] wordsFromText, string[] fobbWords)
        {

            if (wordsFromText.Length < 0 || wordsFromText.Length < 0)     // перевірка довжини строки (в цілому тут можна кидати виключення)
            {
                Console.WriteLine("No text or forbidden words!");
                return;
            }

            for (int i = 0; i < wordsFromText.Length; i++)                // масив зі слів текста
            {

                for (int j = 0; j < fobbWords.Length; j++)                // масив заборонених слів
                {
                    if (wordsFromText[i] == fobbWords[j])                 // порівнюємо
                    {
                        int wordLength = wordsFromText[i].Length;
                        wordsFromText[i] = "";
                        for (int k = 0; k < wordLength; k++)
                        {
                            wordsFromText[i] += "*";
                        }
                    }
                }
            }
            Console.WriteLine("Cleared text:\n");
            foreach (string word in wordsFromText)
                Console.Write($"{word} ");
            Console.WriteLine();
        }

        static char[] RandCharsGenerate (int number)
        {
            char[] chars = new char[number];
            Random randChar = new Random();
            
            for (int i = 0; i < chars.Length; i++ )
                chars[i] = (char)randChar.Next(33, 127);    // генерація символів ASCII з 33 по 126

            return chars;
        }

        static int[] RandomArrCreator (int n, bool unique, out bool isSingle)
        {
            Random rand = new Random();
            List<int> array = new List<int>();
            isSingle = false;

            for (int i = 0; i < n; i++)
            {
                int temp = rand.Next(0, n + 1);
                if (unique)
                {
                    isSingle = true;
                    if (!array.Contains(temp))
                        array.Add(temp);
                    else
                        i--;
                }
                else
                {
                    array.Add(temp);
                }
            }
            Console.WriteLine("Randomly created array:");
            foreach (int i in array)
                Console.Write($"{i} ");

            int[] outArr = array.ToArray();
            return outArr;
        }

        static void FindMissingNumbers(int[] numbers, bool single)
        {
            int sumOfFullArr = (numbers.Length * (numbers.Length + 1)) / 2;

            if (single)
            {
                int missedNumber = sumOfFullArr - numbers.Sum();
                Console.WriteLine($"\nMissed number in the array is {missedNumber}\n");
                return;
            }

            List<int> listMissedNumb = new List<int>();
            for (int i = 0;i <= numbers.Length;i++)
            {
                if (!numbers.Contains(i))
                    listMissedNumb.Add(i);
            }
            Console.WriteLine("\nMissed numbers in the array are: ");
            foreach (int i in listMissedNumb)
                Console.Write($"{i} ");
            Console.WriteLine(  );
        }
    }
}
