using System;
using System.Collections.Generic;

public class Deck
{
    private List<Card> drawPile;
    private List<Card> discardPile;

    public Deck()
    {
        drawPile = new List<Card>();
        discardPile = new List<Card>();
        // Populate the drawPile as before
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (FaceValue faceValue in Enum.GetValues(typeof(FaceValue)))
            {
                drawPile.Add(new Card(suit, faceValue));
            }
        }
    }

    public void Shuffle()
    {
        Random rng = new Random();
        int n = drawPile.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card temp = drawPile[k];
            drawPile[k] = drawPile[n];
            drawPile[n] = temp;
        }
    }

    public Card DealOne()
    {
        if (drawPile.Count == 0)
        {
            throw new InvalidOperationException("No cards left in the draw pile.");
        }
        Card card = drawPile[drawPile.Count - 1];
        drawPile.RemoveAt(drawPile.Count - 1);
        return card;
    }

    public bool IsEmpty()
    {
        return drawPile.Count == 0;
    }

    public void Discard(Card card)
    {
        discardPile.Add(card);
    }

    // Optionally, you might want to add a method to get the top card of the discard pile
    // This could be useful for displaying it in the UI or allowing players to pick it up if your game rules allow
    public Card GetTopCardOfDiscardPile()
    {
        if (discardPile.Count > 0)
        {
            return discardPile[discardPile.Count - 1];
        }
        else
        {
            return null; // Or throw an exception if you prefer
        }
    }

    // public Card PeekTopCardOfDrawPile()
    // {
    //     if (drawPile.Count == 0)
    //     {
    //         throw new InvalidOperationException("No cards left in the draw pile.");
    //     }
    //     return drawPile[drawPile.Count - 1];
    // }

    // You may also want to add methods to manage moving cards from the discard pile back to the draw pile
    // For example, if the draw pile runs out
}
