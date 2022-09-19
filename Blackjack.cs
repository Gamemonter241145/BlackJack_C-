namespace GroupThree
{
    public class Blackjack
    {
        List<Player> _players = new List<Player>();
        Dealer _dealer ;
        Deck _deck;
        int _round = 0;

        public Blackjack (string dealername)
        {
            _dealer = new Dealer(dealername);
        }
        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }
        public string VersusWithDealer(Player player)
        {
            string message = "underfind !!";
            if (player.IsSurrender)
            {
                message = playerSurrender(player);
            }
            else if (player.IsBusted == true && _dealer.IsBusted == false && _dealer.IsBlackJack == false)
            {
                message = playerLose(player);
            }
            else if (player.Points < _dealer.Points && _dealer.IsBusted == false && player.IsBlackJack == false)
            {
                message = playerLose(player);
            }
            else if (player.IsBlackJack == false && _dealer.IsBlackJack == true)
            {
                message = playerLose(player);
            }
            else if (player.IsBusted == false && _dealer.IsBusted == true && player.IsBlackJack == false)
            {
                message = playerWin(player);
            }
            else if (player.Points > _dealer.Points && player.IsBusted == false)
            {
                message = playerWin(player);
            }
            else if (player.IsBusted && _dealer.IsBusted)
            {
                message = Tie(player);
            }
            else if (player.Points == _dealer.Points && !_dealer.IsBusted)
            {
                message = Tie(player);
            }
            else if (player.IsBlackJack && _dealer.IsBlackJack)
            {
                message = Tie(player);
            }
            return message;
        }
        private string displayDealerAndPlayerPoint(Player player)
        {
            string message = $"dealer {_dealer.Name} has {_dealer.CardOnHand()} : {_dealer.Points} points ";
            message += $"\nplayer {player.Name} has {player.CardOnHand()} : {player.Points} points ";
            return message;
        }
        private string playerSurrender(Player player)
        {
            player.AddMoney(player.Bet/2);
            string message = displayDealerAndPlayerPoint(player);
            message += $"\n player {player.Name} Surrender!!"; 
            message += $"\nplayer {player.Name} Bet {player.Bet/2} $";
            return message;
        }
        private string playerLose(Player player)
        {
            string message = displayDealerAndPlayerPoint(player);
            message += $"\n** player {player.Name} Lose **";
            message += $"\nplayer {player.Name} Lose Bet {player.Bet} $";
            return message;
        }
        private string playerWin(Player player)
        {
            string message = displayDealerAndPlayerPoint(player);
            message += $"\n ** player {player.Name} Win Dealer IsBusted!! **";
            message += $"\nplayer {player.Name} get {player.Bet*2} $";
            return message;
        }
        private string Tie(Player player)
        {
            string message = displayDealerAndPlayerPoint(player);
            message += $"\n ** Tie!! **";
            message += $"\nplayer {player.Name} Get Bet {player.Bet} $";
            player.AddMoney(player.Bet);
            return message;
        }
        public string NextRound()
        {
            _round++;
            string message = $"Round {_round} Start !! ";
            _deck = new Deck(numberOfShuffleTime: 350);
            foreach (Player player in _players)
            {
                player.DropAllCard();
            }
            _dealer.DropAllCard();
            return message;
        }
        public void Play()
        {
            string message = NextRound();
            System.Console.WriteLine(message);
            foreach (Player player in _players)
            {
                player.AddBet();
            }
            for (int i = 0; i < 2; i++)
            {
                foreach (Player player in _players)
                {
                    player.AddCard(_deck.Deal);
                }
                _dealer.AddCard(_deck.Deal);
            }
            List<Player> numberOfStandPlayer = new List<Player>();
            while (numberOfStandPlayer.Count < _players.Count)
            {
                foreach (Player player in _players)
                {
                    System.Console.WriteLine($"dealer {_dealer.Name} has { _dealer.CardOnHand(FirstCardOnly: true)} ");
                if (player.IsBlackJack || player.IsStand || player.IsSurrender || player.IsBusted)
                    {
                        if (numberOfStandPlayer.Contains(player) == false)
                        {
                            numberOfStandPlayer.Add(player);
                        }
                        continue;
                    }

                    string text = player.PlayingAction(_deck);
                    System.Console.WriteLine(text);
                }
            }
            while (_dealer.IsStand == false)
            {
                string text = _dealer.PlayingAction(_deck);
                System.Console.WriteLine(text);
            }
            foreach (Player players in _players)
            {
                message = VersusWithDealer(players);
                System.Console.WriteLine(message);
            }
        }
    }
}