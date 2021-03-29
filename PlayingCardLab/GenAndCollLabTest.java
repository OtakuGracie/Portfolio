package genAndCollLab;


import java.io.ByteArrayOutputStream;
import java.io.PrintStream;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import static org.junit.jupiter.api.Assertions.*;


public class GenAndCollLabTest {

	private final ByteArrayOutputStream outContent = new ByteArrayOutputStream();
	private final PrintStream originalOut = System.out;
	
	@Before
	public void setUpStreams() {
	    System.setOut(new PrintStream(outContent));
	}

	@Test
	public void testGetCardValue() 
	{
		Card myCard = new Card(CardVal.KING, CardSuit.SPADES);
		
		assertEquals(CardVal.KING, myCard.getValue(), "The card value returned should be the same as what was passed to the constructor");
	}
	
	@Test
	public void testGetCardSuit() 
	{
		Card myCard = new Card(CardVal.KING, CardSuit.SPADES);
		
		assertEquals(CardSuit.SPADES, myCard.getSuit(), "The card suit returned should be the same as what was passed to the constructor");
	}
	
	@Test
	public void testDeal() 
	{
		Card tempCard;
		Deck testDeck = new Deck();
		
		for (CardSuit suit : CardSuit.values())
		{
			for (CardVal value : CardVal.values())
			{
				tempCard = testDeck.deal();
				assertEquals(value, tempCard.getValue(), "The card values returned should be equal to the face value of the defualt cards for the deck");
				assertEquals(suit, tempCard.getSuit(), "The card suits returned should be equal to the suit of the defualt cards for the deck");
			}
		}
	}
	
	@Test
	public void testShuffle() 
	{
		Deck myDeck = new Deck();
		Card tempCard;
		int unshuffledCards = 0;
		myDeck.shuffle();
		
		for (CardSuit suit : CardSuit.values())
		{
			for (CardVal value : CardVal.values())
			{
				tempCard = myDeck.deal();
				if (tempCard.getValue().equals(value) && tempCard.getSuit().equals(suit))
					unshuffledCards++;
			}
		}
		
		assertNotEquals(52, unshuffledCards, "At least one card should have been moved when the deck was shuffled");
	}
	
	@Test
	public void testShowCards() 
	{
		Deck testDeck = new Deck();
		CardPlayer joe = new CardPlayer();
		
		joe.getCard(testDeck.deal());
		joe.showCards();
		
		assertEquals("ACE of HEARTS\n", outContent.toString());
	}
	
	@After
	public void restoreStreams() {
	    System.setOut(originalOut);
	}

}
