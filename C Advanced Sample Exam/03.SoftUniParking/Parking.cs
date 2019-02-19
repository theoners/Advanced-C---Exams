﻿using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public int Count => cars.Count;

        public Parking(int capacity)
        {
            this.cars = new List<Car>();
            this.capacity = capacity;
        }

        public string AddCar(Car car)
        {
            if (cars.FirstOrDefault(x=>x.RegistrationNumber==car.RegistrationNumber)!=null)
            {
                return "Car with that registration number, already exists!";
            }
            else if (capacity==this.Count)
            {
                return "Parking is full!";
            }

            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            var currentCar = cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);

            if (currentCar==null)
            {
                return "Car with that registration number, doesn't exist!";
            }

            cars.Remove(currentCar);
            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            return cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registrationNumber in registrationNumbers)
            {
                cars.RemoveAll(x=>x.RegistrationNumber==registrationNumber);
            }
        }
    }
}
