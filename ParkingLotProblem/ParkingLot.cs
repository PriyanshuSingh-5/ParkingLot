using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotProblem
{
    class ParkingLot
    {
        public int Capacity { get; private set; }
        public int OccupiedSpaces { get; private set; }
        public int AvailableSpaces => Capacity - OccupiedSpaces;
        private List<Car> ParkedCars { get; set; }
        // Observers
        private List<ILotFullObserver> fullObservers = new List<ILotFullObserver>();
        private List<ILotStatusObserver> statusObservers = new List<ILotStatusObserver>();

        public ParkingLot(int capacity)
        {
            Capacity = capacity;
            OccupiedSpaces = 0;
            ParkedCars = new List<Car>();
        }

        public void Subscribe(ILotFullObserver observer)
        {
           fullObservers.Add(observer);
        }

        public void Subscribe(ILotStatusObserver observer)
        {
            statusObservers.Add(observer);
        }

        public void Unsubscribe(ILotFullObserver observer)
        {
            fullObservers.Remove(observer);
        }

        public void Unsubscribe(ILotStatusObserver observer)
        {
            statusObservers.Remove(observer);
        }

        public void NotifyLotFull()
        {
            foreach (var observer in fullObservers)
            {
                observer.Update();
            }
        }

        public void NotifyLotStatus()
        {
            foreach (var observer in statusObservers)
            {
                observer.Update(IsFull());
            }
        }

        public void ParkCar(Car car)
        {
            if (!IsFull())
            {
                ParkedCars.Add(car);
                OccupiedSpaces++;
                Console.WriteLine($"Car with license plate {car.LicensePlate} parked successfully.");
                CheckLotFull();
                NotifyLotStatus(); // Notify observers about lot status
            }
            else
            {
                Console.WriteLine("Sorry, the parking lot is full. Please find an alternative.");
            }
        }

        public void UnparkCar(Car car)
        {
            if (ParkedCars.Contains(car))
            {
                ParkedCars.Remove(car);
                OccupiedSpaces--;
                Console.WriteLine($"Car with license plate {car.LicensePlate} unparked successfully.");
                NotifyLotFull(); // Notify observers when a car is unparked
                NotifyLotStatus(); // Notify observers about lot status
            }
            else
            {
                Console.WriteLine($"Car with license plate {car.LicensePlate} is not in the parking lot.");
            }
        }

        private void CheckLotFull()
        {
            if (IsFull())
            {
                NotifyLotFull();
            }
        }

        public bool IsFull()
        {
            return OccupiedSpaces >= Capacity;
        }

        public Car FindCar(string licensePlate)
        {
            foreach (var car in ParkedCars)
            {
                if (car.LicensePlate == licensePlate)
                {
                    Console.WriteLine($"Found your car with license plate {licensePlate}. It is parked in the lot.");
                    return car;
                }
            }

            Console.WriteLine($"Could not find a car with license plate {licensePlate} in the parking lot.");
            return null;
        }

    }
}
