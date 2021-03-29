using System;
using System.Collections.Generic;
using System.Text;

namespace BusProject
{
    public class Transaction
    {

        
        private const decimal TICKETCOST = 5.00m;
        private bool serviceCancelled;
        private bool counterClosed;
        private bool paymentGatewayUnresponsive;

        public bool PaymentGatewayUnresponsive { set => paymentGatewayUnresponsive = value; }
        public bool ServiceCancelled { set => serviceCancelled = value; }
        public bool CounterClosed { set => counterClosed = value; }

        public void purchaseTicket(Customer cust, Route busRoute, int routeNum)
        {
            int busNum;
            int seatNum;
            

            if (serviceCancelled)
            {
                throw new ServiceCancelledException();
            }
            else if (counterClosed)
            {
                throw new CounterClosedException();
            }
            else if (cust.Funds < TICKETCOST)
            {
                throw new InsufficientFundsException(cust.FirstName + " " + cust.LastName);
            }
            else if (paymentGatewayUnresponsive)
            {
                throw new PayGatewayUnresponsiveException();
            }
            else
            {
                
                busNum = busRoute.getAvailableBusNum();

                if (busNum == -1)
                {
                    throw new NoSeatsException(busNum);
                }
                else
                {
                    seatNum = busRoute.BusList[busNum].getOpenSeat();
                    cust.removeFunds(TICKETCOST);
                    busRoute.BusList[busNum].reserveSeat(seatNum);

                    cust.setTicketInfo(routeNum, busNum, seatNum);

                    
                }
            }

            

        }
    }
}
