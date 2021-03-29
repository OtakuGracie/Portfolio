package genAndCollLab;

public class Card
{
	private CardVal value;
	private CardSuit suit;
	
	Card(CardVal value, CardSuit suit)
	{
		this.value = value;
		this.suit = suit;
	}
	
	public CardVal getValue()
	{
		return value;
	}
	
	public CardSuit getSuit()
	{
		return suit;
	}
}
