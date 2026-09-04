namespace PifPafCLI;

public class Player
{
    // FIELDS & PROPERTIES
    public bool IsMainPlayer { get; set; } = false;
    public string Name { get; set; }
    public List<Card> Hand { get; set; } = new List<Card>(9);

    // TODO: Melhorar essa porra
    public List<List<Card>> Trios { get; set; } = new List<List<Card>>(3);


    // CONSTRUCTOR
    public Player(string name)
    {
        Name = name;
        if (Name == "You")
            IsMainPlayer = true;
    }


    // METHODS
}
