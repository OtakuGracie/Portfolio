package genAndCollLab;

public class DealingCardsDemo {
	
	public static void main(String[] args)
	{
		Deck myDeck = new Deck();
		CardPlayer jane = new CardPlayer();
		System.out.println("Deck object and CardPlayer Object Jane created.");
		
		myDeck.shuffle();
		System.out.println("The deck has been shuffled");
		
		for (int i = 0; i <= 4; i++)
			jane.getCard(myDeck.deal());
		
		System.out.println("This is Jane's hand: ");
		jane.showCards();
	}
	
}
