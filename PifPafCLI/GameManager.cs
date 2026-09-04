namespace PifPafCLI;

public class GameManager
{
    // FIELDS & PROPERTIES
    public List<Player> Players { get; set; }
    public List<Card> Decks { get; set; }
    public List<Card> DiscardPile { get; set; } = new List<Card>();


    // CONSTRUCTOR
    public GameManager()
    {
        // 1. Selecionar número de jogadores (criar classe de Player)
        Players = CreatePlayers();

        // 2. Criar decks conforme número de jogadores
        Decks = SetupDecks(Players.Count);

        // 3. Atribuir 9 cartas a cada jogador
        SetupHands(Players);

        // 4. Criar loop de gameplay 
        // 4.1 Turnos
        bool isGameOver = false;
        while (!isGameOver)
        {
            foreach (Player player in Players)
            {
                TakeTurn(player);
                //if (VerifyWin(player))
                //{
                //    Console.WriteLine($"{player.Name} wins!");
                //    break;
                //}
                isGameOver = VerifyWin(player);
            }
        }


        // 4.2 Escolhas do player (qual carta joga fora, pega do baralho ou da pilha de descarte)

        // 4.3 Pilha de descarte (criar classe DiscardPile)

        // 4.3 Escolhas da IA (offline)

        // 4.4 Mecânica real-time pra bater e finalizar o jogo


        // 5. Melhorar display de informações

        // FUTURO: Conseguir jogar online (self-hosted ou local)
    }


    // METHODS
    private List<Player> CreatePlayers()
    {
        // TODO: LEAVE QUANTITIES AS MENU SELECTION
        Console.WriteLine("Type player number (2-4): ");
        int playerCount = int.Parse(Console.ReadLine());
        List<Player> players = new List<Player>();
        players.Add(new Player("You"));
        for (int i = 1; i <= playerCount; i++)
        {
            string playerName = "Player " + i;
            players.Add(new Player(playerName));
        }

        return players;
    }

    private List<Card> SetupDecks(int playerCount)
    {
        int deckCount = playerCount / 4;
        List<Card> cards = new List<Card>();
        for (int i = 0; i < deckCount; i++)
        {
            Deck deck = new Deck();
            deck.Shuffle();
            cards.AddRange(deck.Cards);
        }

        return cards;
    }

    private void SetupHands(List<Player> players)
    {
        for (int i = 0; i < 9; i++)
        {
            foreach (Player player in players)
            {
                Card card = Decks[0];
                player.Hand.Add(card);
                Decks.RemoveAt(0);
            }
        }
    }

    private void TakeTurn(Player player)
    {
        Console.WriteLine($"{player.Name}'s turn.");
        if (player.IsMainPlayer)
        {
            DisplayHand(player);
            ChooseDiscard(player);

            if (IsBuying())
            {
                Card boughtCard = Decks[0];
                player.Hand.Add(boughtCard);
                Decks.RemoveAt(0);
            }
            else
            {
                Card boughtCard = DiscardPile[DiscardPile.Count - 1];
                player.Hand.Add(boughtCard);
                Decks.RemoveAt(0);
            }
        }
        else
        {
            // AI logic for other players
            // Placeholder: Random discard and buy from deck or discard pile
            Random rand = new Random();
            int cardToDiscard = rand.Next(player.Hand.Count);
            DiscardPile.Add(player.Hand[cardToDiscard]);
            player.Hand.RemoveAt(cardToDiscard);

            if (rand.Next(2) == 0)
            {
                Card boughtCard = Decks[0];
                player.Hand.Add(boughtCard);
                Decks.RemoveAt(0);
            }
            else
            {
                Card boughtCard = DiscardPile[DiscardPile.Count - 1];
                player.Hand.Add(boughtCard);
                Decks.RemoveAt(0);
            }
        }
    }

    private bool VerifyWin(Player player)
    {

        return false;
    }

    private void DisplayHand(Player player)
    {
        Console.WriteLine("Your hand: ");
        Console.WriteLine(
            $"[{player.Hand[0].Label}]" +
            $"[{player.Hand[1].Label}]" +
            $"[{player.Hand[2].Label}]" +
            $"[{player.Hand[3].Label}]" +
            $"[{player.Hand[4].Label}]" +
            $"[{player.Hand[5].Label}]" +
            $"[{player.Hand[6].Label}]" +
            $"[{player.Hand[7].Label}]" +
            $"[{player.Hand[8].Label}]"
            );
    }

    private void ChooseDiscard(Player player)
    {
        Console.WriteLine("Choose a card to discard (1-9): ");
        int cardToDiscard = int.Parse(Console.ReadLine()) - 1;
        DiscardPile.Add(player.Hand[cardToDiscard]);
        player.Hand.RemoveAt(cardToDiscard);
    }

    private bool IsBuying()
    {
        Console.WriteLine("Buy from deck [1] or graveyard [2]");
        int choice = int.Parse(Console.ReadLine());
        while (choice != 1 && choice != 2)
        {
            Console.WriteLine("Invalid choice. Buy from deck [1] or graveyard [2]");
            choice = int.Parse(Console.ReadLine());
        }

        if (choice == 1)
            return true;
        else
            return false;
    }
}
