
using System.Text;

namespace Lesson2
{
    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            //     Игра “Жизнь”:
            //      Місце дії гри – розмічена на клітини площина(нехай буде обмеженою 10х10, але з можливістю розширення).
            //      Кожна клітина на цій поверхні має вісім сусідів, що оточують її, і може перебувати у двох станах: бути «живою» (заповненою)або «мертвою» (порожньою).
            //      Розподіл живих клітин на початку гри називається першим поколінням.Кожне наступне покоління розраховується на основі попереднього за такими правилами:
            //          - у порожній(мертвій) клітині, з якою сусідять три живі клітини, зароджується життя;
            //          - якщо у живої клітки є дві чи три живі сусідки, то ця клітка продовжує жити;
            //          - в іншому випадку(якщо живих сусідів менше двох або більше трьох) клітина помирає(від самотності або від перенаселеності).

            //      Гра припиняється, якщо
            //          - на полі не залишиться жодної «живої» клітини;
            //          - конфігурація на черговому кроці в точності(без зрушень і поворотів) повторить себе на одному з більш ранніх кроків(складається періодична конфігурація) (не обов'язково)
            //          - при черговому кроці жодна з клітин не змінює свого стану(приватний випадок попереднього правила, складається стабільна конфігурація)(не обов'язково)


            //Гравець не бере активної участі у грі.Він лише розставляє чи генерує початкову конфігурацію «живих» клітин, які потім змінюються відповідно до правил.Конфігурація має бути налаштована у коді.
            try
            {
                GameLife(InputInfo(out int x, out int y));
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // вибір та реалізація способу заповнення початкового поля гри
        static bool[,] InputInfo (out int x, out int y)
        {
            Console.WriteLine("*****  GAME \"LIFE\"  *****\n");

            Console.Write("Enter heigth of the game field (more than 1): ");
            x = Convert.ToInt32(Console.ReadLine());
            if (x <= 1)
                throw new FormatException("Size should be more than 1!");

            Console.Write("Enter length of the game field (more than 1): ");
            y = Convert.ToInt32(Console.ReadLine());
            if (y <= 1)
                throw new FormatException("Size should be more than 2!");


            Console.Write("\nIf you want to fill the game field by yourself please enter \"1\" otherwise press enter: ");
            string? mode = Console.ReadLine();

            switch (mode)
            {
                case "1":
                    bool[,] fieldByHand = new bool[x, y];
                    string? input;
                    Console.WriteLine();
                    for (int i = 0; i < fieldByHand.GetLength(0); i++)
                    {
                        for (int j = 0; j < fieldByHand.GetLength(1); j++)
                        {
                            Console.WriteLine($"Enter a state (0 - is alive, any other action - is dead) for cell in positions {i + 1} (heigth) and {j + 1} (length):");
                            input = Console.ReadLine();
                            switch (input)
                            {
                                case "0":
                                    fieldByHand[i, j] = true;
                                    break;
                                    
                                default:
                                    break;
                            }
                        }
                    }
                    Console.WriteLine("\nZero generation: ");
                    ShowField(fieldByHand);
                    return fieldByHand;

                default:
                    return InitialField(x, y);
            }

        }

        // генерація початкового ігрового поля
        static bool[,] InitialField(int heigth, int length)
        {
            bool[,] field = new bool[heigth, length];
            Random cell = new Random();

            for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < length; j++)
                    if (cell.Next(2) == 0)
                        field[i, j] = true;
            }

            Console.WriteLine("\nZero generation: ");
            ShowField(field);

            return field;
        }

        // графічний вивід на консоль
        static void ShowField(bool[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j])
                        Console.Write("# ");
                    else
                        Console.Write(". ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // рахуємо живі клітини навколо визначеної клітини
        static int NeighbAliveCounter(bool[,] field, int x, int y)
        {
            int counter = 0;
            int heigthIndex = field.GetLength(0);
            int lengthIndex = field.GetLength(1);

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j =  y - 1; j <= y + 1; j++)
                {
                    // перевірка на знахождення позиції на полі, та виключення самої визначеної клітини
                    if (i >= 0 && i < heigthIndex && j >= 0 && j < lengthIndex && !(i == x && j == y))
                        if (field[i, j])
                            counter++;
                }
            }
            return counter;
        }

        // перевірка на рівність поточної генерації та попередньої
        static bool IsEquals(bool[,] preGen, bool[,] newGen)
        {
            for (int i = 0; i < preGen.GetLength(0);i++)
            {
                for (int j = 0;j < preGen.GetLength(1);j++)
                {
                    if (preGen[i,j] != newGen[i,j])
                        return false;
                }
            }
            return true;
        }

        // перевірка, чи не померли всі клітини...
        static bool IsAllDead(bool[,] newGen)
        {
            foreach (bool cell in newGen)
                if (cell)
                    return false;

            return true;
        }

        // основний метод
        static void GameLife(bool[,] preGen, List<string>? history = null)
        {
            int heigth = preGen.GetLength(0);
            int length = preGen.GetLength(1);
            bool[,] newGen = new bool[heigth, length];

            // лист для порівняння попередніх версій з поточною
            if (history == null)
                history = new List<string>();

            for (int i = 0; i < heigth; i++)
            {
                for (int j =  0; j < length; j++)
                {
                    // самі умови зміни стану клітини - за дефолтом в новому масиві всі false, тому зміни тільки на true
                    int aliveNeighb = NeighbAliveCounter(preGen, i, j);

                    if (!preGen[i, j] && aliveNeighb >= 3)
                        newGen[i, j] = true;

                    else if (preGen[i, j] && (aliveNeighb == 2 || aliveNeighb == 3))
                        newGen[i, j] = true;
                }
            }

            // пишемо історію станів поля
            StringBuilder toHistory = new StringBuilder();
            foreach (bool s in newGen)
                toHistory.Append(s);

            // виводимо на консоль нове покоління
            Console.WriteLine($"Generation {history.Count + 1}:");
            ShowField(newGen);

            // перевірки на умови кінця гри
            if (IsAllDead(newGen))
            { 
                Console.WriteLine($"Everyone died...\nGame over!");
                return;
            }

            if (IsEquals(preGen, newGen))
            { 
                Console.WriteLine($"No more new generations. No more evolution...\nGame over!");
                return;
            }

            if (history.Contains(toHistory.ToString()))
            {
                Console.WriteLine($"The circle of life is closed. Life is eternal from {history.IndexOf(toHistory.ToString()) + 1} generation!\nGame over!");
                return;
            }

            // якщо не кінець - дописуємо в історію станів полів
            history.Add(toHistory.ToString());

            // нове покоління через рекурсію
            GameLife(newGen, history);
        }
    }
}