using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusProject;

namespace BusProjectTest
{
    [TestClass]
    public class BusTest
    {
        [TestMethod]
        public void TestCustomer()
        {
            Customer dummyCust = new Customer("Alex", "Williams", "AlexWills@gmail.com");
            dummyCust.setPaymentInfo("333 state street Seneca Falls", "1234567890904321");

            Assert.AreEqual("Alex", dummyCust.FirstName);
            Assert.AreEqual("Williams", dummyCust.LastName);
            Assert.AreEqual("AlexWills@gmail.com", dummyCust.Email);
            Assert.AreEqual("333 state street Seneca Falls", dummyCust.Address);

        }

        [TestMethod]
        public void TestAddFunds()
        {
            Customer dummyCust = new Customer("Alex", "Williams", "AlexWills@gmail.com");
            dummyCust.setPaymentInfo("333 state street Seneca Falls", "1234567890904321");
            dummyCust.addFunds(15.00m);

            Assert.AreEqual(15.00m, dummyCust.Funds);

            dummyCust.addFunds(-5.00m);

            Assert.AreEqual(15.00m, dummyCust.Funds);
        }

        [TestMethod]
        public void TestRemoveFunds()
        {
            Customer dummyCust = new Customer("Alex", "Williams", "AlexWills@gmail.com");
            dummyCust.setPaymentInfo("333 state street Seneca Falls", "1234567890904321");
            dummyCust.addFunds(15.00m);
            dummyCust.removeFunds(5.00m);

            Assert.AreEqual(10.00m, dummyCust.Funds);

            dummyCust.removeFunds(-10.00m);

            Assert.AreEqual(10.00m, dummyCust.Funds);
        }

        [TestMethod]
        public void TestSetTicketInfo()
        {
            Customer dummyCust = new Customer("Alex", "Williams", "AlexWills@gmail.com");
            dummyCust.setTicketInfo(1, 10, 1);

            Assert.AreEqual(true, dummyCust.HasTicket);
            Assert.AreEqual(1, dummyCust.RouteNum);
            Assert.AreEqual(10, dummyCust.BusNum);
            Assert.AreEqual(1, dummyCust.SeatNum);
        }

        [TestMethod]
        public void TestBus()
        {
            Bus bus1 = new Bus(20);

            Assert.AreEqual(true, bus1.IsRunning);

            for (int i = 0; i < 20; i++)
            {
                Assert.AreEqual(false, bus1.Seats[i]);
            }
        }

        [TestMethod]
        public void TestReserveSeat()
        {
            Bus bus1 = new Bus(20);
            bus1.reserveSeat(4);


            Assert.AreEqual(true, bus1.Seats[4]);
        }

        [TestMethod]
        public void TestFreeSeat()
        {
            Bus bus1 = new Bus(20);
            bus1.reserveSeat(5);

            bus1.freeSeat(5);

            Assert.AreEqual(false, bus1.Seats[5]);
        }

        [TestMethod]
        public void TestGetOpenSeat()
        {
            Bus bus1 = new Bus(20);
            bus1.reserveSeat(0);
            bus1.reserveSeat(5);

            Assert.AreEqual(1, bus1.getOpenSeat());
        }

        [TestMethod]
        public void TestGetAvailableBus()
        {
            Bus[] busList = { new Bus(20), new Bus(20), new Bus(20) };
            Route route1 = new Route(busList);

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    route1.BusList[i].reserveSeat(j);
                }
            }

            Assert.AreEqual(2, route1.getAvailableBusNum());
        }

        [TestMethod]
        public void TestPurchaseTicket()
        {
            Transaction trans = new Transaction();
            Customer dummyCust = new Customer("Alex", "Williams", "AlexWills@gmail.com");
            dummyCust.addFunds(5.00m);

            Bus[] busList = { new Bus(20), new Bus(20), new Bus(20) };
            Route route1 = new Route(busList);

            trans.purchaseTicket(dummyCust, route1, 1);


            Assert.AreEqual(0, dummyCust.BusNum);
            Assert.AreEqual(0, dummyCust.SeatNum);
        }

        [TestMethod]
        public void TestCounterClosedException()
        {
            Transaction trans = new Transaction();
            trans.CounterClosed = true;
            Customer dummyCust = new Customer("Alex", "Williams", "AlexWills@gmail.com");
            dummyCust.addFunds(5.00m);

            Bus[] busList = { new Bus(20), new Bus(20), new Bus(20) };
            Route route1 = new Route(busList);
            try
            {
                trans.purchaseTicket(dummyCust, route1, 1);
            }
            catch (CounterClosedException e)
            {
                Assert.AreNotEqual(string.Empty, e);
            }
        }

        [TestMethod]
        public void TestServiceCancelledException()
        {
            Transaction trans = new Transaction();
            trans.ServiceCancelled = true;
            Customer dummyCust = new Customer("Alex", "Williams", "AlexWills@gmail.com");
            dummyCust.addFunds(5.00m);

            Bus[] busList = { new Bus(20), new Bus(20), new Bus(20) };
            Route route1 = new Route(busList);
            try
            {
                trans.purchaseTicket(dummyCust, route1, 1);
            }
            catch (ServiceCancelledException e)
            {
                Assert.AreNotEqual(string.Empty, e);
            }
        }

        [TestMethod]
        public void TestPaymentGatewayUnresponsive()
        {
            Transaction trans = new Transaction();
            trans.PaymentGatewayUnresponsive = true;
            Customer dummyCust = new Customer("Alex", "Williams", "AlexWills@gmail.com");
            dummyCust.addFunds(5.00m);

            Bus[] busList = { new Bus(20), new Bus(20), new Bus(20) };
            Route route1 = new Route(busList);
            try
            {
                trans.purchaseTicket(dummyCust, route1, 1);
            }
            catch (PayGatewayUnresponsiveException e)
            {
                Assert.AreNotEqual(string.Empty, e);
            }
        }

        [TestMethod]
        public void TestNoSeatsException()
        {
            Transaction trans = new Transaction();
            Customer dummyCust = new Customer("Alex", "Williams", "AlexWills@gmail.com");
            dummyCust.addFunds(5.00m);

            Bus[] busList = { new Bus(20), new Bus(20), new Bus(20) };
            Route route1 = new Route(busList);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    route1.BusList[i].reserveSeat(j);
                }
            }

            try
            {
                trans.purchaseTicket(dummyCust, route1, 1);
            }
            catch (NoSeatsException e)
            {
                Assert.AreNotEqual(string.Empty, e);
            }
        }

        [TestMethod]
        public void TestInsufficientFundsException()
        {
            Transaction trans = new Transaction();
            Customer dummyCust = new Customer("Alex", "Williams", "AlexWills@gmail.com");
            

            Bus[] busList = { new Bus(20), new Bus(20), new Bus(20) };
            Route route1 = new Route(busList);
            try
            {
                trans.purchaseTicket(dummyCust, route1, 1);
            }
            catch (InsufficientFundsException e)
            {
                Assert.AreNotEqual(string.Empty, e);
            }
        }
    }
}
