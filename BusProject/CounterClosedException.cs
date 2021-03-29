using System;
using System.Collections.Generic;
using System.Text;

namespace BusProject
{
    public class CounterClosedException : Exception
    {
        public CounterClosedException()
            : base("The counter is currently closed")
        {
        }
    }
}
