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

        _label = GetLabel(value);
    }

    
    // METHODS ==========
    public string GetLabel(int value)
    {
        if (value == 0)
            return "JOKER";
        if (value <= 10 )
            return value.ToString();
        else
        {
            switch (value)
            {
                case (11):
                    return "J";
                case (12):
                    return "Q";
                case (13):
                    return "K";
            }
        }

        throw new Exception("Couldn't get a valid label for this card value.");
    }
}
