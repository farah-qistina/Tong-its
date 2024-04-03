using System;
using System.Drawing;
using System.Windows.Forms;


public class Game
{
    private Deck deck;
    private List<Hand> hands;
    private int numberOfPlayers= 3;
    private int currentPlayerIndex;
    private bool emptyHand; // New boolean variable to track if any player's hand is empty
    private bool callDraw;
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

        // StartGame();

    }

    public void DisplayHands()
    {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            OnHandChanged?.Invoke(i);
        }
    }

    public List<Hand> GetAllHands()
    {
        return new List<Hand>(hands); // Returns a new list containing all cards in the hand
    }

    public void PrintAllHands(List<Hand> hands1)
    {
        for (int i = 0; i < hands1.Count; i++)
        {
            Console.WriteLine($"Player {i + 1}'s hand:");
            foreach (Card card in hands1[i].GetAllCards()) // Using GetAllCards() as defined in Hand.cs
            {
                string cardDescription = $"{card.FaceValue} of {card.Suit}";
                Console.WriteLine(cardDescription);
            }
            Console.WriteLine(); // Add a newline for better readability
        }
    }

    public void Initialize(int numberOfPlayers) {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            Hand hand = new Hand();
            for (int j = 0; j < 12; j++) // Assuming 12 cards are dealt to each player initially in Tong-Its
            {
                hand.AddCard(deck.DealOne());
            }
            hands.Add(hand);
        }
    }

    public void StartGame()
    {
        while (!emptyHand && !callDraw && !deck.IsEmpty())
        {
            PlayTurn();
        }

        // After exiting the loop, check if callDraw is true
        if (callDraw || deck.IsEmpty())
        {
            // Call the CalcScore method to determine the winner
            int winnerIndex = CalcScore();
        }
    }

    // Example method to manage a player's turn
    // This method would be called in your game loop to handle each turn
    public void PlayTurn()
    {
        // Example flow of a turn:
        // 1. Player draws a card
        DrawCard();

        OnHandChanged?.Invoke(currentPlayerIndex);

        // 2. Player plays their hand (not implemented here, depends on your game's rules)

        // 3. Player discards a card (you might want to allow the player to choose which card to discard)
        if (hands[currentPlayerIndex].CardCount() > 0)
        {
            Card cardToDiscard = hands[currentPlayerIndex].GetCard(0); //Discards 1st card for now
            DiscardCard(cardToDiscard);
        }

        

        // Check if the current player has any cards left in his hand
        if (hands[currentPlayerIndex].CardCount() == 0)
        {
            emptyHand = true; // Set emptyHand to true if the current player's hand is empty
        }

        //Check if player wants to call draw

        // Move to the next player's turn
        NextPlayer();
    }

    // Advances to the next player
    public void NextPlayer()
    {
        currentPlayerIndex = (currentPlayerIndex + 1) % hands.Count;
    }

    // Allows the current player to draw a card from the deck
    // public Card DrawCard()
    // {
    //     if (deck.IsEmpty())
    //     {
    //         throw new InvalidOperationException("No more cards in the deck.");
    //     }

    //     Card drawnCard = deck.DealOne();
    //     hands[currentPlayerIndex].AddCard(drawnCard);
    //     return drawnCard;
    // }

    

    public void DrawCard()
    {
        // Your logic to draw a card and return its value/name
    }

    // Allows the current player to discard a specific card
    public void DiscardCard(Card card)
    {
        if (!hands[currentPlayerIndex].RemoveCard(card))
        {
            throw new ArgumentException("The card is not in the player's hand.");
        }

        // Optionally, add the card to a discard pile if your game needs one
    }

    public Card GetTopDiscard()
    {
        // Call the Deck's method to get the top card of the discard pile
        return deck.GetTopCardOfDiscardPile();
    }

    // public Card GetTopDraw()
    // {
    //     // Use the newly created method in Deck to get the top card of the draw pile
    //     return deck.PeekTopCardOfDrawPile();
    // }

    public bool IsDrawPileEmpty()
    {
        return deck.IsEmpty(); // Assuming IsEmpty() checks the draw pile in your Deck class
    }

    public int CalcScore()
    {
        int winningPlayerIndex = -1;
        int highestScore = 0;

        for (int i = 0; i < hands.Count; i++)
        {
            int handScore = 0;
            foreach (Card card in hands[i].GetAllCards()) // Assuming a method GetAllCards exists to return all cards in a hand
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

    

    // Additional methods as needed for game logic, checking for win conditions, etc.
}
