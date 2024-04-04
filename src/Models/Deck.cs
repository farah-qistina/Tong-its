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

    public Card DealOne() // Draw a card from the draw pile
    {
        if (drawPile.Count == 0)
        {
            throw new InvalidOperationException("No cards left in the draw pile.");
        }
        Card card = drawPile[drawPile.Count - 1];
        drawPile.RemoveAt(drawPile.Count - 1);
        return card;
    }

    public void Discard(Card card)
    {
        discardPile.Add(card);
    }
    

    public Card PeekTopCardOfDrawPile()
    {
        if (drawPile.Count == 0)
        {
            throw new InvalidOperationException("No cards left in the draw pile.");
        }
        return drawPile[drawPile.Count - 1];
    }

    public Card GetTopCardOfDiscardPile()
    {
        if (discardPile.Count > 0)
        {
            return discardPile[discardPile.Count - 1];
        }
        else
        {
            return null;
        }
    }

    public bool IsEmpty()
    {
        return drawPile.Count == 0;
    }
}
