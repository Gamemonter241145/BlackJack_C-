 namespace GroupThree
 {
    public enum Suit
    {
        Club, Heart, Diamond, Spade
    }
    public enum Face
    {
        Ace = 1,Two,Three,Four,Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
    }
    public class Card
    {
        public Suit Suit { get; private set; }

        public Face Face { get; private set; }
          public int Points
        {
            get
            {
                if ((int)Face > 10)
                {
                    return 10;
                }
                return (int)Face;
            }
        }
        public Card(Suit suit, Face face)
        {
            Suit = suit;
            Face = face;
        }
        readonly string[] _faces = { "-", "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        readonly string[] _suits = { "♣", "♦", "♥", "♠" };
        public override string ToString()
        {
            string face = _faces[(int)Face];
            string suit = _suits[(int)Suit];
            return face +" "+ suit + " ";
        }
    }
}