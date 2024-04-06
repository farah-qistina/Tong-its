using System.Collections.Generic;
using System.Linq;

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

    public List<Card> GetAllCards()
    {
        return new List<Card>(cards); // Returns a new list containing all cards in the hand
    }

    public bool ContainsCard(Card card)
    {
        return cards.Contains(card);
    }

    public void ClearHand()
    {
        cards.Clear();
    }

    public void OrderCardsFromKingToAce()
    {
        cards = cards.OrderByDescending(card => card.FaceValue).ToList();
    }

    public Card GetHighestCard()
    {
        return cards.OrderByDescending(card => card.FaceValue).FirstOrDefault();
    }

    public Card GetLowestCard()
    {
        return cards.OrderBy(card => card.FaceValue).FirstOrDefault();
    }
}
