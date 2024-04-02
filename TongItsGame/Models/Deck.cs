using System;
using System.Collections.Generic;

public class Deck
{
    private List<Card> cards;

    public Deck()
    {
        cards = new List<Card>();
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (FaceValue faceValue in Enum.GetValues(typeof(FaceValue)))
            {
                cards.Add(new Card(suit, faceValue));
            }
        }
    }

    public void Shuffle()
    {
        Random rng = new Random();
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card temp = cards[k];
            cards[k] = cards[n];
            cards[n] = temp;
        }
    }

    public Card DealOne()
    {
        if (cards.Count == 0)
        {
            throw new InvalidOperationException("No cards left in the deck.");
        }
        Card card = cards[cards.Count - 1];
        cards.RemoveAt(cards.Count - 1);
        return card;
    }
}
