package customerLab;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.Test;

class CustomerLabTest {

	@Test
	void testPersonDefualt() 
	{
		Person human = new Person();
		assertEquals("Null", human.getName(), "The defualt name for person should be \"Null\"");
		assertEquals("Null", human.getAddress(), "The defualt address for person should be \"Null\"");
		assertEquals("Null", human.getTelephoneNum(), "The defualt telephone number for person should be \"Null\"");
	}
	
	@Test
	void testPerson()
	{
		String name = "Kate";
		String address = "392 South main street";
		String telephoneNum = "333-469-5000";
		
		Person human = new Person(name, address, telephoneNum);
		assertEquals(name, human.getName(), "The name returned should be the same as the name passed to the constructor");
		assertEquals(address, human.getAddress(), "The address returned should be the same as the address passed to the constructor");
		assertEquals(telephoneNum, human.getTelephoneNum(), "The telephone number returned should be the same as the telephone number passed to the constructor");
	}
	
	@Test
	void testPersonSetName()
	{
		Person human = new Person();
		
		human.setName("Hayden");
		assertEquals("Hayden", human.getName(), "The name returned should be the same as what was set in the mutator");
	}
	
	@Test
	void testPersonAddress()
	{
		Person human = new Person();
		
		human.setAddress("30 Howardson drive");
		assertEquals("30 Howardson drive", human.getAddress(), "The address returned should be the same as what was set in the mutator");
	}
	
	@Test
	void testPersonTelephoneNum()
	{
		Person human = new Person();
		
		human.setTelephoneNum("555-764-8921");
		assertEquals("555-764-8921", human.getTelephoneNum(), "The telephone number returned should be the same as what was set in the mutator");
	}
	
	@Test
	void testCustomerDefualt()
	{
		Customer cust = new Customer();
		
		assertEquals(0, cust.getCustomerNum());
		assertEquals(false, cust.getIsOnMailingList());
	}
	
	@Test
	void testGetCustomerNum()
	{
		Customer cust = new Customer("Alex", "789 South main street", "300-444-1234", 100, true);
		
		assertEquals(100, cust.getCustomerNum(), "The customer number returned should be the same as what was passed to the constructor");
	}
	
	@Test
	void testGetIsOnMailingList()
	{
		Customer cust = new Customer("Alex", "789 South main street", "300-444-1234", 100, true);
		
		assertEquals(true, cust.getIsOnMailingList());
	}

	@Test
	void testSetCustomerNum()
	{
		Customer cust = new Customer();
		
		cust.setCustomerNum(100);
		assertEquals(100, cust.getCustomerNum(), "The customer number returned should be the same as what was set in the mutator");
	}
	
	@Test
	void testSetMailingList()
	{
		Customer cust = new Customer();
		
		cust.setMailingList(true);
		assertEquals(true, cust.getIsOnMailingList(), "The mailing list boolean should return the same value set in the mutator");
	
		cust.setMailingList(false);
		assertEquals(false, cust.getIsOnMailingList(), "The mailing list boolean should return the same value set in the mutator");
	}
	
	@Test
	void testPrefCustomerDefualt()
	{
		PreferredCustomer cust = new PreferredCustomer();
		
		assertEquals(0.0, cust.getTotalPurchased(), "The total purchased returned should be the same as what was set in the no-arg constructor");
		assertEquals(0.0, cust.getDiscount(), "The discount returned should be the same as what was set in the no-arg constructor");
	}
	
	@Test
	void testGetTotalPurchased()
	{
		PreferredCustomer cust = new PreferredCustomer("Alex", "789 South main street", "300-444-1234", 100, true, 1000.0, 0.06);
		
		assertEquals(1000.0, cust.getTotalPurchased(), "The total purchased returned should be the same as what was passed to the constructor");
	}
	
	@Test
	void testGetDiscount()
	{
		PreferredCustomer cust = new PreferredCustomer("Alex", "789 South main street", "300-444-1234", 100, true, 1000.0, 0.06);
		
		assertEquals(0.06, cust.getDiscount(), "The discount returned should be the same as what was passed to the constructor");
	}
	
	@Test
	void testSetTotalPurchased()
	{
		PreferredCustomer cust = new PreferredCustomer();
		
		cust.setTotalPurchased(1200.0);
		assertEquals(1200.0, cust.getTotalPurchased(), "The total purchased returned should be the same as the value set in the mutator");
	}
	
	@Test
	void testSetDiscount()
	{
		PreferredCustomer cust = new PreferredCustomer();
		
		cust.setDiscount(0.07);
	}
	
	@Test
	void testPurchase()
	{
		PreferredCustomer cust = new PreferredCustomer();
		double purchase = -10.0;
		double[] discountLevel = {0.0, 0.05, 0.06, 0.07, 0.10};
		
		cust.purchase(purchase);
		assertEquals(0.0, cust.getTotalPurchased(), "The total purchased should not be changed when a negative number is passed to the purchase method");
		assertEquals(discountLevel[0], cust.getDiscount(), "The discount should not be changed when a negative number is passed to the purchase method");
		
		purchase = 500.0;
		
		for (int i = 1; i <= 4; i++)
		{
			cust.purchase(purchase);
			assertEquals(i * 500.0, cust.getTotalPurchased(), "The total purchased should increase by the amount passed to the purchase method.");
			assertEquals(discountLevel[i], cust.getDiscount(), "The discount level should increase for $500 increase in total purchased");
		}
		
	}
	
}
