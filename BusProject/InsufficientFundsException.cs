using System;
using System.Collections.Generic;
using System.Text;

namespace BusProject
{
    public class InsufficientFundsException: Exception
    {
        public InsufficientFundsException()
            : base("Not enough funds to buy a ticket")
        {  
        }

        public InsufficientFundsException(string name)
            : base(name + " does not have enough funds to buy a ticket")
        {
        }
    }
}
