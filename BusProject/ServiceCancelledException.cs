using System;
using System.Collections.Generic;
using System.Text;

namespace BusProject
{
    public class ServiceCancelledException : Exception
    {
        public ServiceCancelledException()
            : base("The bus service has been cancelled")
        {
        }
    }
}
