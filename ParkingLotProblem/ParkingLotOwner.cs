using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotProblem
{
    
    class ParkingLotOwner: ILotFullObserver
    {
        private readonly ParkingLot parkingLot;

        public ParkingLotOwner(ParkingLot lot)
        {
            parkingLot = lot;
            // Subscribe the observer during construction
            parkingLot.Subscribe(this);
        }

        public void Update()
        {
            Console.WriteLine("Parking Lot Owner: Lot is full. Putting out the full sign.");
        }
        public void Update(bool isLotFull)
        {
            if (!isLotFull)
            {
                Console.WriteLine("Parking Lot Owner: Lot has space again. Taking in the full sign.");
            }
        }
    }
}
