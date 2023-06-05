using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_3
{
    public class Card
    {
        int _cost;
        public char Suit { get; set; }
        public string CardValue { get; set; }
        public int Cost
        {
            get
            { return _cost; }
            set
            {
                switch (CardValue)
                {
                    case "J":
                        _cost = 2;
                        break;
                    case "Q":
                        _cost = 3;
                        break;
                    case "K":
                        _cost = 4;
                        break;
                    case "A":
                        _cost = 11;
                        break;
                    default:
                        _cost = Convert.ToInt32(CardValue);
                        break;
                }
            }
        }

        public Card(char suit, string cardValue)
        {
            Suit = suit;
            CardValue = cardValue;
            Cost = _cost;
        }
    }
}
