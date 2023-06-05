namespace HW_3
{
    public static class CardsActions
    {

        public static char[] suit = new char[] { '\u2660', '\u2663', '\u2666', '\u2665' };
        public static string[] cardValue = new string[] { "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        public static List<Card> CardDeckGenerator()
        {
            List<Card> deck = new List<Card>();

            foreach (char s in suit)
            {
                foreach (string v in cardValue)
                    deck.Add(new Card(s, v));
            }

            return deck;
        }
        public static List<Card> CardDeckRandom(List<Card> deckInit)
        {
            List<Card> deckRandom = new List<Card>(deckInit.Count);
            Random rnd = new Random();
            int index;

            while (deckInit.Count > 0)
            {
                index = rnd.Next(deckInit.Count);
                deckRandom.Add(deckInit[index]);
                deckInit.RemoveAt(index);
            }

            return deckRandom;
        }
        public static void CardDeckPrint(List<Card> deck)
        {
            foreach (Card item in deck)
                Console.Write($"{item.Suit}{item.CardValue} ");
            Console.WriteLine("");
        }
        public static void FindAcesPositions(List<Card> deck)
        {
            Console.WriteLine("Aces are on the next positions in the deck:");
            foreach (Card item in deck)
                if (item.CardValue == "A")
                    Console.Write($"{deck.IndexOf(item) + 1}  ");
            Console.WriteLine();
        }
        public static void SpadesSorting(List<Card> deck)
        {
            int counter = cardValue.Length;
            int i = 0;

            // друга умова - для виключення обробки останньої карти в колоді, якщо вона піка
            while (counter != 0 && i < deck.Count - cardValue.Length)  
            {
                if (deck[i].Suit == suit[0])
                {
                    deck.Add(deck[i]);
                    deck.RemoveAt(i);
                    counter--;
                    i--;
                }
                i++;
            }
            deck.Reverse();
        }
        public static void SortingDeck(List<Card> deck)
        {
            int countValue = cardValue.Length;
            int countSuit = suit.Length;
            int i = 0;

            foreach (string v in cardValue)
            {
                while (countSuit != 0 && i < deck.Count - suit.Length)
                {
                    if (deck[i].CardValue == v)
                    {
                        deck.Add(deck[i]);
                        deck.RemoveAt(i);
                        countSuit--;
                        i--;
                    }
                    i++;
                }
                i = 0;
                countSuit = suit.Length;
            }

            foreach (char s in suit)
            {
                while (countValue != 0)
                {
                    if (deck[i].Suit == s)
                    {
                        deck.Add(deck[i]);
                        deck.RemoveAt(i);
                        countValue--;
                        i--;
                    }
                    i++;
                }
                i = 0;
                countValue = cardValue.Length;
            }
        }
    }
}
