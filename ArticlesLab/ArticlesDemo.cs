
using System;



namespace ArticlesLab
{
    public class ArticlesDemo
    {
        public static void Main()
        {
            string name;
            string[] sStartDate;
            string[] sEndDate;
            DateTime endDate;
            DateTime startDate;
            
            Console.WriteLine("Enter the name of an author to search for in the format: lastName firstName");
            name = Console.ReadLine().Replace(" ","");

            Console.WriteLine("Enter the starting date to search for articles in the format: mm/dd/yyyy");
            sStartDate = Console.ReadLine().Split("/");

            while (!Articles.validateDate(sStartDate))
            {
                Console.WriteLine("Date entered is invalid");
                Console.WriteLine("Enter the starting date to search for articles in the format: mm/dd/yyyy");
                sStartDate = Console.ReadLine().Split("/");
            }

            startDate = new DateTime(int.Parse(sStartDate[2]), int.Parse(sStartDate[0]), int.Parse(sStartDate[1]));
            
            

            Console.WriteLine("Enter the end date to search for articles in the format: mm/dd/yyyy");
            sEndDate = Console.ReadLine().Split("/");

            while (!Articles.validateDate(sEndDate))
            {
                Console.WriteLine("Date entered is invalid");
                Console.WriteLine("Enter the end date to search for articles in the format: mm/dd/yyyy");
                sStartDate = Console.ReadLine().Split("/");
            }

            endDate = new DateTime(int.Parse(sEndDate[2]), int.Parse(sEndDate[0]), int.Parse(sEndDate[1]));
            Articles.WriteMatchingFile(name, startDate, endDate);

            


        }

        
        
    }
}
