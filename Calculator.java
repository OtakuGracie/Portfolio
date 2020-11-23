package statisticsCalculator;

import java.util.Arrays;

public class Calculator {
	
	public static double calcMean(double[] array)
	{
		double total = 0.0;
		
		for (int i = 0; i < array.length; i++)
		{
			total += array[i];
		}
		
		return total / array.length;
	}
	
	public static double calcMed(double[] array)
	{
		Arrays.sort(array);
		
		if (array.length % 2 == 0)
		{
			return (array[(array.length / 2) - 1] + array[(array.length / 2)]) / 2;
		}
		else
		{
			return array[Math.round(array.length / 2)];
		}
	}
	
	public static double calcSampleSD(double[] array)
	{
		double sampleMean = calcMean(array);
		
		double total = 0.0;
		
		for (int i = 0; i < array.length; i++)
		{
			total += Math.pow(array[i] - sampleMean, 2);
		}
		
		return Math.sqrt(total / (array.length - 1));
	}
	
	public static double calcPopulationSD(double[] array)
	{
		double sampleMean = calcMean(array);
		
		double total = 0.0;
		
		for (int i = 0; i < array.length; i++)
		{
			total += Math.pow(array[i] - sampleMean, 2);
		}
		
		return Math.sqrt(total / array.length);
	}
	
}
