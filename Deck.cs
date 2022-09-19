namespace GroupThree
{
    public class Deck
    {
        Card[] cards = new Card[52];
        int cardIndex = 0;
        public Card Deal
        {
            get
            {
                int index = cardIndex;
                if (cardIndex > 51)
                {
                    Console.WriteLine("error");
                }
                else
                {
                    cardIndex++;
                }
                return cards[index];
            }
        }
        public Deck(int numberOfShuffleTime = 250)
        {
            Reset();
            Shuffle(numberOfShuffleTime);
        }
        public void Shuffle(int numberOfShuffleTime)
        {
            Random random = new Random();
            foreach (Card card in cards)
            {
                int index0 = random.Next(52);
                int index1 = random.Next(52);
                Card card1 = cards[index0];
                cards[index0] = cards[index1];
                cards[index1] = card1;
            }
        }
        public void Reset()
        {
            cardIndex = 0;
            int index = 0;
            foreach (Face face in Enum.GetValues(typeof(Face)))
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    cards[index] = new Card(face: face, suit: suit);
                    index++;
                }
            }
        }
    }
}