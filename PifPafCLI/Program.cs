namespace PifPafCLI;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to PifPaf!");

        Deck deck = new Deck();
        deck.Shuffle();

        foreach (Card card in deck.Cards)   
            Console.WriteLine($"{card.Label} | {card.Value} | {card.Suit.ToString()}");
    }
}

