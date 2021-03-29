

using System.Collections.Generic;
using System.IO;
using System;

namespace ArticlesLab
{
    class Articles
    {
        private static FileInfo[] searchForAuthor(string name)
        {

            DirectoryInfo[] rootDirectory = new DirectoryInfo(Directory.GetCurrentDirectory()).GetDirectories();


            for (int i = 0; i < rootDirectory.Length; i++)
            {
                if (rootDirectory[i].Name == name)
                {
                    return rootDirectory[i].GetFiles();
                }
                
            }

            return null;
        }

        private static List<string> searchArticles(string name, DateTime startDate, DateTime endDate)
        {
            
            FileInfo[] files = searchForAuthor(name);
            var metaFileNames = new List<String>();
            StreamReader reader;
            var values = new List<string>();
            DateTime articleDate;
            string[] dateFileString;
            var matchedFileInfo = new List<string>();

            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Extension == ".meta")
                {
                    reader = new StreamReader(files[i].FullName);
                    reader.ReadLine();
                    values.Add(reader.ReadLine() + "," + files[i].Directory.Name + "\\" + Path.GetFileNameWithoutExtension(files[i].FullName)); //the article's file path is added to the end so it can be passed to WriteMatchingFiles
                }
            }

            for (int i = 0; i < values.Count; i++)
            {
                dateFileString = values[i].Split(",")[1].Split("/");
                articleDate = new DateTime(int.Parse(dateFileString[2]), int.Parse(dateFileString[0]), int.Parse(dateFileString[1]));

                if (articleDate >= startDate && articleDate <= endDate)
                {
                    matchedFileInfo.Add(values[i]);
                }
            }

            

            return matchedFileInfo;

        }

        public static void WriteMatchingFile(string name, DateTime startDate, DateTime endDate)
        {
            var writer = new StreamWriter("matchedArticles.csv");

            
                List<string> matchedFileInfo = searchArticles(name, startDate, endDate);

                writer.Write("title,date,path" + Environment.NewLine);

                for (int i = 0; i < matchedFileInfo.Count; i++)
                {
                    string[] indValues = matchedFileInfo[i].Split(",");
                    writer.Write(indValues[0] + "," + indValues[1] + "," + indValues[3] + ".txt" + Environment.NewLine);
                }

                writer.Close();

            
        }

        public static bool validateDate(string[] date)
        {
            int year;
            int month;
            int day;

            if (date.Length != 3)
            {
                return false;
            }
            else if (!int.TryParse(date[2], out year) || !int.TryParse(date[0], out month) || !int.TryParse(date[1], out day))
            {
                return false;
            }
            else if (year < 1 || year > DateTime.Today.Year)
            {
                return false;
            }
            else if (month < 1 || month > 12)
            {
                return false;
            }
            else if (day < 1 || day > 31)
            {
                return false;
            }
            else if (month == 2 && year % 4 != 0 && day > 28)
            {
                return false;
            }
            else if (month == 2 && day > 29)
            {
                return false;
            }
            else if ((month == 4 || month == 6 || month == 9 || month == 11) && day > 30)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
