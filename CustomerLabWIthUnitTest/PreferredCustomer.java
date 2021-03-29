package customerLab;

public class PreferredCustomer extends Customer 
{
	private double totalPurchased;
	private double discount;
	
	PreferredCustomer()
	{
		totalPurchased = 0.0;
		discount = 0.0;
	}
	
	PreferredCustomer(String name, String address, String telephoneNum, int customerNum, boolean isOnMailingList, double totalPurchases, double discount)
	{
		super(name, address, telephoneNum, customerNum, isOnMailingList);
		this.totalPurchased = totalPurchases;
		this.discount = discount;
	}
	
	public double getTotalPurchased()
	{
		return totalPurchased;
	}
	
	public double getDiscount()
	{
		return discount;
	}
	
	public void setTotalPurchased(double totalPurchased)
	{
		this.totalPurchased = totalPurchased;
	}
	
	public void setDiscount(double discount)
	{
		this.discount = discount;
	}
	
	public void purchase(double amount)
	{
		
		if (amount < 0.0)
			amount = 0.0;
		
		totalPurchased += amount;
		
		if (totalPurchased >= 500.0 && totalPurchased < 1000.0)
			discount = 0.05;
		else if (totalPurchased >= 1000.0 && totalPurchased < 1500.0)
			discount = 0.06;
		else if (totalPurchased >= 1500.0 && totalPurchased < 2000.0)
			discount = 0.07;
		else if (totalPurchased >= 2000.0)
			discount = 0.10;
	}
	
	
}
