namespace HW_3
{
    public class Program
    {
        static void Main()
        {
            Console.Write("Enter 1 to start tasks 1-5, or press enter to launch Game21: ");
            switch (Console.ReadLine())
            {
                case "1":
                    //  Згенерувати впорядковану колоду карт
                    List<Card> initDeck = CardsActions.CardDeckGenerator();
                    Console.WriteLine("Card deck from box (sorted)");
                    CardsActions.CardDeckPrint(initDeck);

                    //  Перемішати колоду карт
                    List<Card> workDeck = CardsActions.CardDeckRandom(initDeck);
                    Console.WriteLine("Randomly mixed card deck:");
                    CardsActions.CardDeckPrint(workDeck);

                    //  Знайти позиції всіх тузів у колоді
                    CardsActions.FindAcesPositions(workDeck);

                    //  Перемістити всі пікові карти на початок колоди
                    CardsActions.SpadesSorting(workDeck);
                    Console.WriteLine("\nSorted by spades:");
                    CardsActions.CardDeckPrint(workDeck);

                    //  Відсортувати колоду
                    CardsActions.SortingDeck(workDeck);
                    Console.WriteLine("Sorted:");
                    CardsActions.CardDeckPrint(workDeck);
                    break;

                default:
                    //  Створіть консольну програму для карткової гри «21» з простими правилами:
                    //      - у грі 36 карт
                    //      - вартість карток в окулярах: Туз - 11 очок; Король – 4 очки; Леді / Дама - 3 бали; Джек / Валет – 2 очки; Інші карти за їх номіналом

                    //  2 гравці(ви та комп'ютер)
                    //  мета гри - набрати 21 очко

                    //  спочатку ви повинні ввести, хто отримує перші картки
                    //  ви та комп'ютер отримуєте 2 карти відразу

                    //  після цього кожен із вас вирішить, чого ви хочете ? отримати ще одну карту або перестати отримувати карти(залежить від того, хто першим почав гру)

                    //  якщо один з вас набрав 21 очко або 2 тузи, гра закінчена і виграє гравець з 21 очком або 2 тузами

                    //  якщо один із гравців набирає більше 21 очка, гра закінчується, але в кінці раунду

                    //  якщо у вас обох більше 21 очка гра закінчена та виграє гравець з меншою кількістю очок


                    //  має бути можливість продовжувати грати
                    //  повинна статистика за результатами всіх зіграних ігор

                    Game21.Game();
                    break;
            }
        }
    }
}