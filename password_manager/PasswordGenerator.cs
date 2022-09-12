using System;
using System.Collections;


namespace Password_manager
{
    public class PasswordGenerator
    {

        private static PasswordGenerator instance = null;
        public const int MINPASSWORDLENGTH = 10;
        public const int MAXPASSWORDLENGTH = 30;
        private Random randNumGenerator = new Random();

        private PasswordGenerator() {}

        public static PasswordGenerator getInstance()
        {
            if (instance == null)
            {
                instance = new PasswordGenerator();
            }

            return instance;
        }

        public String newPassword(int length = MINPASSWORDLENGTH)
        {
            int numSpecialChars = randNumGenerator.Next(1, (int)Math.Floor((double)length/4));
            int numDigits = randNumGenerator.Next(1, (int)Math.Floor((double)length / 4));
            int numUppercaseChars = randNumGenerator.Next(1, (int)Math.Floor((double)length / 3));
            var password = new ArrayList();
            

            for (int i = 0; i < numSpecialChars; i++)
            {
                password.Add(generateSpecialChar());
            }


            for (int i = 0; i < numDigits; i++)
            {
                password.Insert(randNumGenerator.Next(0,password.Count + 1), (char)randNumGenerator.Next(48,57)); ;
            }

            for (int i = 0; i < numUppercaseChars; i++)
            {
                password.Insert(randNumGenerator.Next(0, password.Count + 1), (char)randNumGenerator.Next(65,90));
            }

            //fills in the remainder of the password with random lowercase letters
            while(password.Count < length)
            {
                password.Insert(randNumGenerator.Next(0, password.Count + 1), (char)randNumGenerator.Next(97,122));
            }

            return new String((char[])password.ToArray(typeof(char)));
        }

        public char generateSpecialChar()
        {
            char[] specialCharSet = {'!','#','$','%','&','*','+','/','?','<','>','='};

            return specialCharSet[randNumGenerator.Next(0, specialCharSet.Length - 1)];
        }

        public int generateIntInBounds(int[] intArray)
        {
            return intArray[randNumGenerator.Next(0, intArray.Length - 1)];
        }

        
    }
}
