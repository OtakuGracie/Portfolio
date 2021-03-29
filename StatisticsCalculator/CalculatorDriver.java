package statisticsCalculator;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class CalculatorDriver {

	public static void main(String[] args) throws FileNotFoundException {
		var stdin = new Scanner(System.in);
		String menuChoice = "0";
		double[] numArray;
		File numFile = null;
		Scanner numFileReader = null;
		boolean numFileSet = false;
		String regexMatchCSV = "^[0-9]+(.[0-9]+)?(,[0-9]+(.[0-9]+)?)+$"; //regex for matching a file with just comma separated numbers, int or decimal

		while (!numFileSet)
		{
			System.out.println("Please enter the name of the csv file with numbers to use:");

			numFile = new File(stdin.nextLine().trim().toLowerCase() + ".csv");

			if (numFile.exists())
			{
				numFileReader = new Scanner(numFile);
				
				if (numFileReader.hasNext(regexMatchCSV))
				{
					numFileSet = true;
				}
				else
				{
					System.out.println("The file is empty or not in the correct format. It should have a comma separated list of numbers only with no spaces\n\n");
				}
			}
			else
			{
				System.out.println("The specified file was not found \n\n");
			}
		}

		while (!menuChoice.equals("x"))
		{
			System.out.println("Enter a number for a calculation type or x to exit");
			System.out.println("[1] = Calculate Mean");
			System.out.println("[2] = calculate median");
			System.out.println("[3] = calculate Sample deviation");
			System.out.println("[4] = calculate population deviation");
			System.out.println();

			menuChoice = stdin.nextLine().trim().toLowerCase();

			numArray = ArrayConverter.strToDouble(numFileReader.nextLine().split(","));

			if (menuChoice.equals("1"))
			{
				System.out.println("\nThe mean of the data set is:");
				System.out.println(Calculator.calcMean(numArray));
			}
			else if (menuChoice.equals("2"))
			{
				System.out.println("\nThe Median of the data set is:");
				System.out.println(Calculator.calcMed(numArray));
			}
			else if (menuChoice.equals("3"))
			{
				System.out.println("\nThe Sample Standard Deviation of the data set is:");
				System.out.println(Calculator.calcSampleSD(numArray));
			}
			else if (menuChoice.equals("4"))
			{
				System.out.println("\nThe population standard deviation of the data set is:");
				System.out.println(Calculator.calcPopulationSD(numArray));
			}
			else if (menuChoice.equals("x"))
			{
				//makes sure the error message below isn't printed when x is entered
			}
			else
			{
				System.out.println("\nnot a valid input");
			}

			System.out.print("\n\n\n");
			numFileReader = new Scanner(numFile);
		}

		stdin.close();
		System.out.println("Program terminated successfully");
	}
}


