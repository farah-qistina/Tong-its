using System;
using System.Drawing;
using System.Windows.Forms;


public class Game
{
    private Deck deck;
    private List<Hand> hands;
    private int numberOfPlayers = 3;
    private int currentPlayerIndex;
    private bool emptyHand; // To track if any player's hand is empty
    private bool callDraw;
    private bool winnerPresent;
    private bool goNext;

    public event Action<int> OnHandChanged;
    
    

    public Game ()
    {
        deck = new Deck();
        deck.Shuffle();

        hands = new List<Hand>();
        
        Initialize(numberOfPlayers);
        
        currentPlayerIndex = 0; // Game starts with the first player
        emptyHand = false; // Initially, no player has an empty hand
        callDraw = false; //Initially, no player calls for a draw
        winnerPresent = false; // Default to false, meaning no winner initially
        goNext = false; // Default to false, player 1's turn before 2
    }

    // Game

    public void Initialize(int numberOfPlayers) {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            Hand hand = new Hand();
            for (int j = 0; j < 12; j++) // 12 cards are dealt to each player initially in Tong-Its
            {
                hand.AddCard(deck.DealOne());
            }
            hands.Add(hand);
        }
    }


    public int CalcScore()
    {
        int winningPlayerIndex = -1;
        int highestScore = 0;

        for (int i = 0; i < hands.Count; i++)
        {
            int handScore = 0;
            foreach (Card card in hands[i].GetAllCards()) 
            {
                if (card.FaceValue >= FaceValue.Two && card.FaceValue <= FaceValue.Ten)
                {
                    // Numeric cards score their face value
                    handScore += (int)card.FaceValue;
                }
                else if (card.FaceValue == FaceValue.Ace)
                {
                    // Aces score 1
                    handScore += 1;
                }
                else
                {
                    // Face cards (Jack, Queen, King) score 10
                    handScore += 10;
                }
            }

            // Update the winning player if this player has a higher score
            if (handScore > highestScore)
            {
                highestScore = handScore;
                winningPlayerIndex = i;
            }
        }

        return winningPlayerIndex;
    }


    // UI

    public void DisplayHands()
    {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            OnHandChanged?.Invoke(i);
        }
    }

    // Setters

    // Allows the current player to draw a card from the deck
    public Card DrawCard()
    {
        if (deck.IsEmpty())
        {
            throw new InvalidOperationException("No more cards in the deck.");
        }

        Card drawnCard = deck.DealOne();
        hands[currentPlayerIndex].AddCard(drawnCard);
        return drawnCard;
    }

    public void DiscardCard(Card card)
    {
        // Find the player who owns the selected card
        int playerIndex = FindPlayer(card);
        if (playerIndex != -1)
        {
            if (RemoveCard(card))
            {
                deck.Discard(card); // Adds the card to the discard pile
            }
        }
    }

    public bool RemoveCard(Card card)
    {
        // Find the player who owns the selected card
        int playerIndex = FindPlayer(card);
        if (playerIndex != -1)
        {
            return hands[playerIndex].RemoveCard(card);
        } else {
            return false;
        }
    }

    public void SetCurrentPlayerIndex(int index)
    {
        if (index >= 0 && index < numberOfPlayers)
        {
            currentPlayerIndex = index;
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index must be within the range of the number of players.");
        }
    }

    // Getters

    public int GetCurrentPlayerIndex()
    {
        return currentPlayerIndex;
    }

    public List<Hand> GetAllHands()
    {
        return new List<Hand>(hands); // Returns a new list containing all cards in the hand
    }

    public Card GetTopDraw()
    {
        // Use the method in Deck to get the top card of the draw pile
        return deck.PeekTopCardOfDrawPile();
    }

    public Card GetTopDiscard()
    {
        // Call the Deck's method to get the top card of the discard pile
        return deck.GetTopCardOfDiscardPile();
    }
    
    public bool IsDrawPileEmpty()
    {
        return deck.IsEmpty();
    }

    public bool IsCurrentPlayerHandEmpty()
    {
        return hands[currentPlayerIndex].CardCount() == 0;
    }

    public int GetPlayers(int playerIndex)
    {
        return numberOfPlayers;
    }

    public int FindPlayer(Card card)
    {
        return hands.FindIndex(hand => hand.ContainsCard(card));
    }


    // public void PrintAllHands(List<Hand> hands1) // Used for debugging
    // {
    //     for (int i = 0; i < hands1.Count; i++)
    //     {
    //         Console.WriteLine($"Player {i + 1}'s hand:");
    //         foreach (Card card in hands1[i].GetAllCards()) // Using GetAllCards() as defined in Hand.cs
    //         {
    //             string cardDescription = $"{card.FaceValue} of {card.Suit}";
    //             Console.WriteLine(cardDescription);
    //         }
    //         Console.WriteLine();
    //     }
    // }
}
