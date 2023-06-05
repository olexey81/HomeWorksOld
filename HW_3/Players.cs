namespace HW_3
{
    public class Players
    {
        int _sumPoints;

        public int SumPoints { get; set; }
        public List<Card> CardsOnHands { get; set; }
        public string PlayerName { get; set; }
        public bool IsFirst { get; set; }
        public bool IsWon { get; set; }
        public bool Continue { get; set; } = true;

        public Players(string name)
        {
            PlayerName = name;
            CardsOnHands = new List<Card>();
        }

        public int SumOfPoints()
        {
            _sumPoints = 0;
            foreach (Card card in CardsOnHands)
                _sumPoints += card.Cost;
            SumPoints = _sumPoints;
            return _sumPoints;
        }
        public void TerminateProgress()
        {
            CardsOnHands.Clear();
            SumPoints = 0;
            IsFirst = false;
            IsWon = false;
            Continue = true;
        }
    }
}
