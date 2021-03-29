using System;
using System.Collections.Generic;
using System.Text;

namespace BusProject
{
    public class Route
    {
        private Bus[] busList;
        
        public Bus[] BusList { get => busList; }
        

        public Route(Bus[] busList)
        {
            this.busList = busList;


        }
        public int getAvailableBusNum()
        {
            for (int i = 0; i < busList.Length; i++)
            {
                if (busList[i].IsRunning == true && busList[i].getOpenSeat() != -1)
                {
                    return i;
                }
            }

            return -1;
        }




    }
}
