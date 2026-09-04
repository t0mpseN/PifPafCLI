namespace PifPafCLI;

public class Card
{
    // FIELDS & PROPERTIES ==========
    private int _value;
    public int Value { get { return _value; } }

    private Suit _suit;
    public Suit Suit { get { return _suit; } }

    private string _label;
    public string Label { get { return _label; } }


    // CONSTRUCTOR ==========
    public Card (int value, Suit suit)
    {
        _value = value;
        _suit = suit;

        _label = GetLabel(value, suit);
    }


    // METHODS ==========
    public string GetLabel(int value, Suit suit)
    {
        string label = "";
        if (value == 0)
            label += "JOKER";
        if (value <= 10)
            label += value.ToString();
        else
        {
            switch (value)
            {
                case (11):
                    label += "J";
                    break;
                case (12):
                    label += "Q";
                    break;
                case (13):
                    label += "K";
                    break;
            }
        }

        switch (suit)
        {
            case (Suit.Hearts):
                label += "♥";
                break;
            case (Suit.Diamonds):
                label += "♦";
                break;
            case (Suit.Clubs):
                label += "♣";
                break;
            case (Suit.Spades):
                label += "♠";
                break;
        }

        return label;
    }
}
