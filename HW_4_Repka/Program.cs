using System.Text;

namespace HW_4_Repka
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                Console.Write("Яку рослину садимо? Введіть назву: ");
                string name = Console.ReadLine();                         
                Console.WriteLine($"\n\tКазка про {name}\n");

                Charachter nextCharachter = new Charachter();

                Console.WriteLine($"Посадив {nextCharachter.Name} {name}");
                Console.Write($"Через скільки днів будемо тягнути {name}? Введіть кількість днів: ");

                int days = Convert.ToInt32(Console.ReadLine());

                Plant plant = new Plant(name, days);
                Console.WriteLine($"Виросла {plant.Name} велика-превелика.\n");

                while (true)
                {
                    Console.WriteLine($"Тягнемо {plant.Name}...");

                    if (!nextCharachter.IsPulledPlant(plant))
                    {
                        Console.WriteLine($"Але не виходить {plant.Name} з під землі.");

                        nextCharachter = nextCharachter.CallHelp();

                        if (nextCharachter.Name == null)
                        {
                            Console.WriteLine($"\n\nНажаль, не вистачило персонажів щоб витягнути {plant.Name}, необхідно було або тягнути раніше, або більше персонажів");
                            break;
                        }
                        Console.WriteLine($"\nПокликали {nextCharachter.Name}\n");
                    }
                    else
                        break;
                }

                Console.WriteLine($"\nВага {plant.Name} склала {plant.Weigth} кг, а сила, з якою тягнули - {nextCharachter.Force:F1} кгс");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}