using System;
using System.Collections.Generic;
using System.Text;

namespace BusProject
{
    public class PayGatewayUnresponsiveException : Exception 
    {
        public PayGatewayUnresponsiveException()
        : base("The Payment gateway is not responding")
        {
        }
    }
}
