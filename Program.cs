namespace GroupThree
{
    class Program
    {
        static void Main(string[] args)
        {
            Blackjack blackJack = new Blackjack(dealername : "BarBam") ;
            blackJack.AddPlayer(new Player(playerName: "Prawit", startMoney: 10000));
            string exit = "";
            while (exit != "n")
            {
                blackJack.Play();
                Console.Write("Play next round (Y/N)? : ");
                exit = Console.ReadLine().ToLower();
                Console.Clear();
            }
        }
    }
}