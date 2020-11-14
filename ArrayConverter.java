
public class ArrayConverter {

	public static int[] strToInt(String[] strArray)
	{
		int[] newArray = new int[strArray.length];
		
		for (int i = 0; i < strArray.length; i++)
		{
			newArray[i] = Integer.parseInt(strArray[i]);
		}
		
		return newArray;
	}
	
	public static double[] strToDouble(String[] strArray)
	{
		double [] newArray = new double[strArray.length];
		
		for (int i = 0; i < strArray.length; i++)
		{
			newArray[i] = Double.parseDouble(strArray[i]);
		}
		
		return newArray;
	}
	
	public static float[] strToFloat(String[] strArray)
	{
		float [] newArray = new float[strArray.length];
		
		for (int i = 0; i < strArray.length; i++)
		{
			newArray[i] = Float.parseFloat(strArray[i]);
		}
		
		return newArray;
	}
}
