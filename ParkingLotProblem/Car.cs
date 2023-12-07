using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotProblem
{
    class Car
    {
        public string LicensePlate { get; private set; }
        public string DriverName { get; private set; }

        public Car(string licensePlate, string driverName)
        {
            LicensePlate = licensePlate;
            DriverName = driverName;
        }

        public void LeaveParkingLot(ParkingLot parkingLot)
        {
            parkingLot.UnparkCar(this);
        }
    }
}
