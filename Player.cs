namespace GroupThree
{
    public class Player : Dealer
    {
        public int Money
        {
            get; private set;
        }
        public bool IsSurrender
        {
            get; private set;
        }
        public int Bet
        {
            get; private set;
        }
        public override string PlayingAction(Deck deck)
        {
            string text = $"Player {Name} ";
            string user_input = "";
        Input:
            System.Console.WriteLine($"player {Name} has {CardOnHand()} : {Points} points \nMoney Balance :{Money - Bet}");
            System.Console.Write("Select action\ntype '1' for Hit, '2' for Stand");
            System.Console.Write(", '3' for Surrander. : ");
            user_input = System.Console.ReadLine().ToLower();
            if (user_input == "2")
            {
                IsStand = true;
                text += "Stand !!!";
            }
            else if (user_input == "3")
            {
                IsSurrender = true;
                text += "surrander !!!";
            }
            else if (user_input == "1")
            {
                Card card = deck.Deal;
                text += "hit ";
                AddCard(card);
            }
            else
            {
                System.Console.WriteLine("select new !!");
                goto Input;
            }
            return text;
        }
        public Player(string playerName, int startMoney) : base(playerName)
        {
            Money = startMoney;
        }
        public int AddMoney(int amount)
        {
            Money += amount;
            return Money;
        }
        public override void DropAllCard()
        {
            base.DropAllCard();
            Bet = 0;
            IsStand = false;
            IsSurrender = false;
        }
        public void AddBet()
        {
        Input:
            System.Console.Write($"Player {Name} has {Money} $, How Much do you want to bet ? \n");
            try
            {
                System.Console.Write($"Player:{Name} input bet : ");
                int bet_input = int.Parse(System.Console.ReadLine());
                if (bet_input > Money || bet_input < -1 || bet_input == 0)
                {
                    throw new System.Exception();
                }
                Bet = bet_input;
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Invalid input, try again !!");
                goto Input;
            }
        }
    }
}