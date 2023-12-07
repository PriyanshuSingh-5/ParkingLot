using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotProblem
{
    class ParkingAttendent :ILotStatusObserver
    {
        private readonly ParkingLot parkingLot;

        public ParkingAttendent(ParkingLot lot)
        {
            parkingLot = lot;
            // Subscribe the observer during construction
            parkingLot.Subscribe(this);
        }

        public void Update(bool isLotFull)
        {
            if (!isLotFull)
            {
                Console.WriteLine("Parking Attendant: Lot has space. Ready to park more cars.");
            }
        }

        public void ParkCar(Car car)
        {
            parkingLot.ParkCar(car);
        }
    }
}
