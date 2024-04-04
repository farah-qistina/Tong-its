public class Card
{
    public Suit Suit { get; private set; }
    public FaceValue FaceValue { get; private set; }

    public Card(Suit suit, FaceValue faceValue)
    {
        Suit = suit;
        FaceValue = faceValue;
    }
    
    public override string ToString()
    {
        return $"{FaceValue} of {Suit}";
    }
}
