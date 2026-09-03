namespace PifPafCLI;

public class Deck
{
    // FIELDS & PROPERTIES 
    private IList<Card> _cards = new List<Card>();
    public IList<Card> Cards {  get { return _cards; } }

    public HashSet<Suit> Suits = new HashSet<Suit>() {
        Suit.Clubs,
        Suit.Hearts,
        Suit.Spades,
        Suit.Diamonds,
    };


    // CONSTRUCTOR
    public Deck()
    {
        Initialize();
    }


    // METHODS
    private void Initialize()
    {
        foreach (Suit suit in Suits)
        {
            if (suit == Suit.Joker)
            {
                _cards.Add(new Card(0, Suit.Joker));
                _cards.Add(new Card(0, Suit.Joker));
                continue;
            }

            for (int i = 1; i < 14; i++)
            {
                _cards.Add(new Card(i, suit));
            }
        }
    }

    public void Shuffle()
    {
        for (int i = _cards.Count - 1; i > 0; i--)
        {
            int j = Random.Shared.Next(i + 1);

            (_cards[i], _cards[j]) = (_cards[j], _cards[i]);
        }
    }
}
