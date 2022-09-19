namespace GroupThree
{
    public class Dealer
    {
        List<Card> _card = new List<Card>();

        public bool IsStand
        {
            get; protected set;
        }

        public string Name
        {
            get; private set;
        }

        public int Points
        {
            get
            {
                int points = 0;
                foreach (Card card in _card)
                {
                    points += card.Points;
                }
                return points;
            }
        }

        public int NumberOfCardOnHand
        {
            get { return _card.Count; }
        }

        public bool IsBusted
        {
            get
            {
                if (Points <= 21)
                {
                    return false;
                }
                return true;
            }
        }
        public bool IsBlackJack
        {
            get
            {
                
                if (Points == 11 && NumberOfCardOnHand == 2 && HasAceOnHand)
                {
                    return true;
                }
                return false;
            }
        }

        private bool HasAceOnHand
        {
            get
            {
                foreach (Card card in _card)
                {
                    if (card.Face == Face.Ace)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public Dealer(string name)
        {
            Name = name;
        }
        public void AddCard(Card card)
        {
            _card.Add(card);
        }
        public virtual void DropAllCard()
        {
            _card.Clear();
        }
        public string CardOnHand(bool FirstCardOnly = false)
        {
            string text = "";
            for (int i = 0; i < _card.Count; i++)
            {
                if (i == 0 || FirstCardOnly == false)
                {
                    text += _card[i].ToString() + "";
                }
                else
                {
                    text += "[**]";
                }
            }
            return text;
        }
        public virtual string PlayingAction(Deck deck)
        {
            if (Points <= 17)
            {
                Card card = deck.Deal;
                AddCard(card);
                return $"Dealer {Name} Hit ";
            }
            IsStand = true;
            return $"Dealer {Name} Stand !!";
        }
    }
}