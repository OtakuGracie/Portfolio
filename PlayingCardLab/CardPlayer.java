package genAndCollLab;

import java.util.ArrayList;
import java.util.ListIterator;

public class CardPlayer 
{
	private ArrayList<Card> hand = new ArrayList<>();
	
	
	public void getCard(Card drawnCard)
	{
		hand.add(drawnCard);
	}
	
	public void showCards()
	{
		Card TempCard;
		
		ListIterator<Card> iterator = hand.listIterator();
		while (iterator.hasNext())
		{
			TempCard = iterator.next();
			System.out.print(TempCard.getValue().toString() + " of " + TempCard.getSuit().toString() + "\n");
		}
	}
}
