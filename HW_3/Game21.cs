namespace HW_3
{
    
    public static class Game21
    {
        public static Players computer = new Players("Computer");
        public static Players human = new Players("");

        public static void Game()
        {
            Console.Write("Hello! Please enter your name: ");
            human.PlayerName = Console.ReadLine();
            
            List<string> history = new List<string>();

            while (true)
            {
                Stack<Card> deck = Game21.CardDeckRandom(CardsActions.CardDeckGenerator());

                Console.Write("\nChoose who will make the first move? Enter 1 for human, or press enter for computer: ");
                if (Console.ReadLine() == "1")
                    human.IsFirst = true;
                else
                    computer.IsFirst = true;

                Gameplay(human, computer, deck);

                if (human.IsWon)
                    history.Add(human.PlayerName);
                else if (computer.IsWon)
                    history.Add(computer.PlayerName);
                else 
                    history.Add("Draw");

                Console.WriteLine("\nPlease make your choise:" +
                                  "\n--- enter 1 if you want to play again;" +
                                  "\n--- enter 2 to see previous results and play again;" +
                                  "\n--- enter 3 to see previous results and close the game" +
                                  "\n--- press enter to close the game:");

                switch (Console.ReadLine())
                {
                    case "1":
                        human.TerminateProgress();
                        computer.TerminateProgress();
                        break;

                    case "2":
                        ShowStatistic(history);
                        human.TerminateProgress();
                        computer.TerminateProgress();
                        break;

                    case "3":
                        ShowStatistic(history);
                        return;

                    default:
                        return;
                }
            }
        }


        public static void Gameplay(Players human, Players computer, Stack<Card> deck)
        {
            human.CardsOnHands.Add(deck.Pop());
            human.CardsOnHands.Add(deck.Pop());
            human.SumOfPoints();

            computer.CardsOnHands.Add(deck.Pop());
            computer.CardsOnHands.Add(deck.Pop());
            computer.SumOfPoints();


            switch (human.IsFirst)
            {
                case true:
                    Console.WriteLine($"\nMove for {human.PlayerName}");
                    Console.Write("\nYour cards are: ");
                    CardsActions.CardDeckPrint(human.CardsOnHands);

                    while (human.Continue)
                    {
                        HumanTurns(human, deck);
                        WinCheker(human);
                    }

                    Console.WriteLine($"\nMove for {computer.PlayerName}");
                    Thread.Sleep(1000);
                    while (computer.Continue)
                    {
                        ComputerTurns(computer, deck);
                        WinCheker(computer);
                        Thread.Sleep(1000);
                    }
                    break;

                case false:
                    Console.WriteLine($"\nMove for {computer.PlayerName}");
                    Thread.Sleep(1000);
                    while (computer.Continue)
                    {
                        ComputerTurns(computer, deck);
                        WinCheker(computer);
                        Thread.Sleep(1000);
                    }

                    Console.WriteLine($"\nMove for {human.PlayerName}");
                    Console.Write("\nYour cards are: ");
                    CardsActions.CardDeckPrint(human.CardsOnHands);

                    while (human.Continue)
                    {
                        HumanTurns(human, deck);
                        WinCheker(human);
                    }

                    break;
            }

            if (human.SumPoints == computer.SumPoints)
            {
                Console.WriteLine(new string('-', 60));

                Console.WriteLine("Points of both players are equal. DRAW!");
                Result(human);
                Result(computer);

                Console.WriteLine(new string('-', 60));

                return;
            }

            if (!human.IsWon && !computer.IsWon)
                RoundCheker(human, computer);

            if (human.IsWon || computer.IsWon)
            {
                Console.WriteLine(new string('-', 60));

                if (human.IsWon)
                    Console.WriteLine($"\nPlayer {human.PlayerName} won the game!");
                else
                    Console.WriteLine($"\nPlayer {computer.PlayerName} won the game!");

                Result(human);
                Result(computer);
                
                Console.WriteLine(new string('-', 60));
            }
        }
        public static Stack<Card> CardDeckRandom(List<Card> deckInit)
        {
            Stack<Card> deckRandom = new Stack<Card>(deckInit.Count);
            Random rnd = new Random();
            int index;

            while (deckInit.Count > 0)
            {
                index = rnd.Next(deckInit.Count);
                deckRandom.Push(deckInit[index]);
                deckInit.RemoveAt(index);
            }

            return deckRandom;
        }
        static void WinCheker(Players player)
        {
            if (player.SumPoints == 21 || (player.CardsOnHands.Count == 2 && player.SumPoints == 22))
            {
                player.IsWon = true;
                player.Continue = false;
                if (player.PlayerName == human.PlayerName)
                    Console.WriteLine("You reached the goal!");
                return;
            }

            if (player.SumPoints > 21)
                player.Continue = false;

            if (player.PlayerName == human.PlayerName && player.SumPoints > 21 && player.CardsOnHands.Count > 2)
                Console.WriteLine("You have exceeded 21 point...");

            if (player.PlayerName == computer.PlayerName && player.SumPoints > 21 && player.CardsOnHands.Count > 2)
                Console.WriteLine($"\n{player.PlayerName} finished his move and waits  for the cards to be revealed.");
        }
        static void RoundCheker (Players player1, Players player2)
        {
            if (player1.SumPoints < 22 && player2.SumPoints < 22 && (!player1.Continue && !player2.Continue))
            {
                if (player1.SumPoints > player2.SumPoints)
                    player1.IsWon = true;
                else
                    player2.IsWon = true;
                return;
            }

            if (player1.SumPoints >= 22 && player2.SumPoints >= 22)
            {
                if (player1.SumPoints < player2.SumPoints)
                    player1.IsWon = true;
                else
                    player2.IsWon = true;
                return;
            }

            if (player1.SumPoints < 22 && player2.SumPoints >= 22)
            {
                player1.IsWon = true;
                return;
            }

            if (player1.SumPoints >= 22 && player2.SumPoints < 22)
                player2.IsWon = true;

        }
        static void HumanTurns (Players player, Stack<Card> deck)
        {
            Console.Write("\nDo you want one additional card? Enter \"+\" if yes, or press enter if no: ");

            if (Console.ReadLine() == "+")
            {
                player.CardsOnHands.Add(deck.Pop());
            Console.Write("\nYour cards are: ");
                CardsActions.CardDeckPrint(player.CardsOnHands);
            }

            else
            {
                player.Continue = false;
                Console.Write("\nYou finished your move. Your cards are: ");
                CardsActions.CardDeckPrint(player.CardsOnHands);
            }

            player.SumOfPoints();
        }
        static void ComputerTurns (Players player, Stack<Card> deck)
        {
            if (player.SumPoints < 18)
            {
                Console.WriteLine($"\n{player.PlayerName} took a card.");
                player.CardsOnHands.Add(deck.Pop());
            }

            else
            {
                player.Continue = false;
                Console.WriteLine($"\n{player.PlayerName} finished his move and waits for the cards to be revealed.");
            }

            player.SumOfPoints();
        }
        static void Result(Players player)
        {
            Console.Write($"\n{player.PlayerName}'s cards are: ");
            CardsActions.CardDeckPrint(player.CardsOnHands);
            Console.Write($"Total points: {player.SumPoints}\n");
        }
        static void ShowStatistic(List<string> history)
        {
            for (int i  = 0; i < history.Count; i++)
                Console.WriteLine($"Winner in game {i + 1}: {history[i]}");
        }
    }
}
