package customerLab;

public class Customer extends Person {
	private int customerNum;
	private boolean isOnMailingList;
	
	Customer()
	{
		customerNum = 0;
		isOnMailingList = false;
	}
	
	Customer(String name, String address, String telephoneNum, int customerNum, boolean isOnMailingList)
	{
		super(name, address, telephoneNum);
		this.customerNum = customerNum;
		this.isOnMailingList = isOnMailingList;
	}
	
	public int getCustomerNum()
	{
		return customerNum;
	} 
	
	public boolean getIsOnMailingList()
	{
		return isOnMailingList;
	}
	
	public void setCustomerNum(int customerNum)
	{
		this.customerNum = customerNum;
	}
	
	public void setMailingList(boolean isOnMailingList)
	{
		this.isOnMailingList = isOnMailingList;
	}
}
