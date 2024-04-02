using System.Collections.Generic;

public class Hand
{
    private List<Card> cards;

    public Hand()
    {
        cards = new List<Card>();
    }

    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    public bool RemoveCard(Card card)
    {
        return cards.Remove(card);
    }

    public int CardCount()
    {
        return cards.Count;
    }

    public Card GetCard(int index)
    {
        if (index >= 0 && index < cards.Count)
        {
            return cards[index];
        }
        throw new ArgumentOutOfRangeException(nameof(index), "Index out of range");
    }

    // Other hand-related methods like evaluating the hand can be added here
}
