using HW_4_Repka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HW_4_Repka
{
    internal class Tale
    {
        private string? _name;
        private Charachter _nextCharachter;
        private int _days;
        private Plant _plant;


        public Tale()
        {
            _nextCharachter = new Charachter();
        }

        public void TalkTale()
        {
            Console.Write("Яку рослину садимо? Введіть назву: ");
            _name = Console.ReadLine();

            Console.WriteLine($"\n\tКазка про {_name}\n");
            Console.WriteLine($"Посадив {CharachtersNames.Grandpa} {_name}");

            Console.Write($"Через скільки днів будемо тягнути {_name}? Введіть кількість днів: ");
            _days = Convert.ToInt32(Console.ReadLine());

            _plant = new Plant(_name, _days);
            Console.WriteLine($"Виросла {_plant.Name} велика-превелика.\n");

            while (true)
            {
                Console.WriteLine($"Тягнемо {_plant.Name}...");

                if (!_nextCharachter.IsPulledPlant(_plant))
                {
                    Console.WriteLine($"Але не виходить {_plant.Name} з під землі.");

                    _nextCharachter = _nextCharachter.CallHelp();

                    if (_nextCharachter.Name == null)
                    {
                        Console.WriteLine($"\n\nНажаль, не вистачило персонажів щоб витягнути {_plant.Name}, необхідно було або тягнути раніше, або більше персонажів");
                        break;
                    }
                    Console.WriteLine($"\nПокликали {_nextCharachter.Name}\n");
                }
                else
                    break;
            }

            Console.WriteLine($"\nВага {_plant.Name} склала {_plant.Weigth} кг, а сила, з якою тягнули - {_nextCharachter.Force:F1} кгс");

        }


    }
}
