namespace Simple_Card_Dealer;

public class Program
{
    private static Random _random = new Random();

    public static void Main(string[] args)
    {
        Console.WriteLine("=== Welcome to Card Dealer ===");

        List<Card> deck = new List<Card>();
        List<Card> hand = new List<Card>();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nWhat do you want to do?\n1. Create a deck of cards\n2. Shuffle deck\n3. Draw 5 cards\n4. View current hand\n5. View remaining deck\n6. Clear hand\n7. Exit");
            Console.Write("Enter your choice (1-7): ");
            string choice = GetValidString();

            switch (choice)
            {
                case "1":
                    CreateDeck(deck);
                    break;
                case "2":
                    ShuffleDeck(deck);
                    break;
                case "3":
                    DrawCards(deck, hand);
                    break;
                case "4":
                    ShowHand(hand);
                    break;
                case "5":
                    DeckCheck(deck);
                    break;
                case "6":
                    ClearHand(hand);
                    break;
                case "7":
                    Console.WriteLine("=== Thank you for using Card Dealer ===");
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid input! Input must be between 1 and 7.");
                    break;
            }
        }
    }

    // Main Methods
    private static void CreateDeck(List<Card> deck)
    {
        string[] suits = ["Spades", "Hearts", "Diamonds", "Clubs"];
        string[] ranks = ["Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"];

        if (deck.Count > 0)
        {
            deck.Clear();
        }

        foreach (string suit in suits)
        {
            foreach (string rank in ranks)
            {
                deck.Add(new Card(suit, rank));
            }
        }

        Console.WriteLine("A new deck is created!");
        Console.WriteLine($"{deck.Count} cards in deck.");
    }

    private static void ShuffleDeck(List<Card> deck)
    {
        if (deck.Count < 1)
        {
            Console.WriteLine("Cannot shuffle! Your deck is empty.");
            return;
        }

        Card? temp = null;

        for (int i = deck.Count - 1; i >= 0; i--)
        {
            int j = _random.Next(i + 1);
            temp = deck[j];
            deck[j] = deck[i];
            deck[i] = temp;
        }

        Console.WriteLine("Deck shuffled!");
    }

    private static void DrawCards(List<Card> deck, List<Card> hand)
    {
        if (deck.Count < 1)
        {
            Console.WriteLine("The deck is empty!");
            return;
        }

        int count;
        int deckLimit = deck.Count;
        for (count = 0; count < 5 && count < deckLimit; count++)
        {
            if (deck.Count < 1)
            {
                Console.WriteLine("Deck is empty!");
                break;
            }

            hand.Add(deck[0]);
            deck.RemoveAt(0);
        }

        Console.WriteLine($"{count} {(count > 1 ? "Cards" : "Card")} has been added to your hand!");
    }

    private static void ShowHand(List<Card> hand)
    {
        if (hand.Count < 1)
        {
            Console.WriteLine("Your hand is empty!");
            return;
        }

        Console.WriteLine("Your current hand: \n");
        foreach (Card card in hand)
        {
            Console.WriteLine(card);
        }
    }

    private static void DeckCheck(List<Card> deck)
    {
        if (deck.Count < 1)
        {
            Console.WriteLine("The deck is empty!");
            return;
        }

        Console.WriteLine($"There {(deck.Count > 1 ? "are" : "is")} {deck.Count} {(deck.Count > 1 ? "cards" : "card")} remaining!");
    }

    private static void ClearHand(List<Card> hand)
    {
        if (hand.Count < 1)
        {
            Console.WriteLine("Your hand is already empty!");
            return;
        }

        hand.Clear();
        Console.WriteLine("Your hand is emptied!");
    }

    // Helper Method
    private static string GetValidString()
    {
        while (true)
        {
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input.Trim();
            }
            else
            {
                Console.WriteLine("Invalid input! Input cannot be empty.");
            }
        }
    }
}