using System;
using System.Collections.Generic;
using System.Text;

namespace BusProject
{
    public class NoSeatsException : Exception
    {
        public NoSeatsException(int num)
            : base("There are no free seats on bus #" + num)
        {
        }

    }
}
