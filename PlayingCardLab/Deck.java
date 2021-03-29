package genAndCollLab;

import java.util.Collections;
import java.util.LinkedList;

public class Deck 
{
	
	 private LinkedList<Card> deck = new LinkedList<>();
	
	Deck()
	{
		for (CardSuit suit : CardSuit.values())
		{
			for (CardVal value : CardVal.values())
			{
				deck.add(new Card(value, suit));
			}
		}
		
	}
	
	public Card deal()
	{
		return deck.removeFirst();
	}
	
	public void shuffle()
	{
		Collections.shuffle(deck);
	}
	
}
