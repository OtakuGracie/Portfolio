using System;

namespace BusProject
{
    public class Customer
    {
        private string firstName;
        private string lastName;
        private string address;
        private string email;
        private string cardNum;
        private decimal funds;
        private bool hasTicket;
        private int routeNum;
        private int busNum;
        private int seatNum;


        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Address { get => address; }
        public string CardNum { get => address; }
        public string Email { get => email; set => email = value; }
        public bool HasTicket { get => hasTicket; }
        public int RouteNum { get => routeNum; }
        public int BusNum { get => busNum; }
        public int SeatNum { get => seatNum; }
        public decimal Funds { get => funds;}


        public Customer(string firstName, string lastName, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            
            this.email = email;
        }

        public void setPaymentInfo(string address, string cardNum)
        {
            this.address = address;
            this.cardNum = cardNum;
        }

        public void addFunds(decimal deposit)
        {
            if (deposit > 0m)
            {
                funds += deposit;
            }
        }

        public void removeFunds(decimal cost)
        {
            if (cost > 0m)
            {
                funds -= cost;
            }
        }

        public void setTicketInfo(int routeNum, int busNum, int seatNum)
        {
            hasTicket = true;
            this.routeNum = routeNum;
            this.busNum = busNum;
            this.seatNum = seatNum;
        }
    }
}
