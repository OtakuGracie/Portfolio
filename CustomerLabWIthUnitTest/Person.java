package customerLab;

public class Person {
	private String name;
	private String address;
	private String telephoneNum;
	
	Person()
	{
		name = "Null";
		address = "Null";
		telephoneNum = "Null";
	}
	
	Person(String name, String address, String telephoneNum)
	{
		this.name = name;
		this.address = address;
		this.telephoneNum = telephoneNum;
	}
	
	public String getName()
	{
		return name;
	}
	
	public String getAddress()
	{
		return address;
	}
	
	public String getTelephoneNum()
	{
		return telephoneNum;
	}
	
	public void setName(String name)
	{
		this.name = name;
	}
	
	public void setAddress(String address)
	{
		this.address = address;
	}
	
	public void setTelephoneNum(String telephoneNum)
	{
		this.telephoneNum = telephoneNum;
	}
	
	
}
