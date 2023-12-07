using System;

namespace ParkingLotProblem
{
    class Program
    {
        static void Main(string[] args)
        {

            //UC 1
            ParkingLot parkingLot = new ParkingLot(capacity: 50);
            Car car1 = new Car(licensePlate: "ABC123", driverName: "John Doe");
            Car car2 = new Car(licensePlate: "XYZ789", driverName: "Jane Doe");

            parkingLot.ParkCar(car1);
            parkingLot.ParkCar(car2);

            // Create observers
            ParkingLotOwner lotOwner = new ParkingLotOwner(parkingLot);
            AirportSecurity security = new AirportSecurity(parkingLot);
            ParkingAttendent attendant = new ParkingAttendent(parkingLot);

            //UC2
            car1.LeaveParkingLot(parkingLot);

            //UC3
            // Car1 leaving the parking lot triggers the LotFull event
            car1.LeaveParkingLot(parkingLot);

            //UC6
            // Parking attendant parks a new car
            Car car3 = new Car(licensePlate: "JKL456", driverName: "Bob Smith");
            attendant.ParkCar(car3);

            //UC7
            // Driver finds their car
            parkingLot.FindCar("XYZ789");
        }
    }
}
