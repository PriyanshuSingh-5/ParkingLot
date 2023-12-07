using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotProblem
{
    //UC4
    class AirportSecurity: ILotFullObserver
    {
        private readonly ParkingLot parkingLot;

        public AirportSecurity(ParkingLot lot)
        {
            parkingLot = lot;
            // Subscribe the observer during construction
            parkingLot.Subscribe(this);
        }

        public void Update()
        {
            Console.WriteLine("Airport Security: Parking lot is full. Redirecting security staff.");
        }
    }
}
