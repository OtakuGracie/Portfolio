using System;
using System.Collections.Generic;
using System.Text;

namespace BusProject
{
    public class Bus
    {
        private bool[] seats; //true represents a seat that has been reserved
        private bool isRunning;

        public bool IsRunning { get => isRunning; set => isRunning = value; }
        public bool[] Seats { get => seats; }

        public Bus(int seatNum)
        {
            seats = new bool[seatNum];
            isRunning = true;
        }
        public int getOpenSeat()
        {
            for (int i = 0; i < seats.Length; i++)
            {
                if (seats[i] == false)
                {
                    return i;
                }
            }

            return -1;
        }

        public void reserveSeat(int seatNum)
        {
            seats[seatNum] = true;
        }

        public void freeSeat(int seatNum)
        {
            seats[seatNum] = false;
        }
    }
}
