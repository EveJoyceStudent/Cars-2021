using System;
using CarsLib;
using Xunit;

namespace CarsTests
{
    public class CarTests
    {
        Car car0;
        Car car1;
        Car car2;
        Car newCar3;
        Car futureCar4;
        Car[] carList;

        public CarTests(){
            car0 = new Car("13-954", "Toyota", "Truego AE86", 1986, 100);
            car1 = new Car("63-887", "Mazda", "RX-7", 1995, 0);
            car2 = new Car("26-037", "Nissan", "Skyline GT-R", 1994, 0);
            newCar3 = new Car("13-600","Subaru","WRX",2021,-100);
            futureCar4 = new Car("", "", "", 2022, 200);
            carList = new Car[]{car0, car1, car2, newCar3, futureCar4};
        }

        [Theory]
        [InlineData (0, 150, 150)]
        [InlineData (0, 50, 150)]
        [InlineData (0, 0, 100)]
        [InlineData (0, -10, 110)]
        [InlineData (0, -100, 150)]
        [InlineData (1, 0, 0)]
        [InlineData (3, 0, 0)]
        [InlineData (3, 10, 10)]
        [InlineData (4, 0, 150)]
        [InlineData (4, 10, 150)]
        public void IncreaseSpeedTest (int carIndex, int increaseSpeed, int expected) {
            carList[carIndex].IncreaseSpeed (increaseSpeed);
            Assert.Equal (expected, carList[carIndex].Speed);
        }

        [Theory]
        [InlineData (0, 150, 0)]
        [InlineData (0, 50, 50)]
        [InlineData (0, 0, 100)]
        [InlineData (0, -10, 90)]
        [InlineData (0, -100, 0)]
        [InlineData (1, 0, 0)]
        [InlineData (3, 0, 0)]
        [InlineData (3, 10, 0)]
        [InlineData (4, 0, 150)]
        [InlineData (4, 10, 140)]
        public void DecreaseSpeedTest (int carIndex, int decreaseSpeed, int expected) {
            carList[carIndex].DecreaseSpeed (decreaseSpeed);
            Assert.Equal (expected, carList[carIndex].Speed);
        }

        [Theory]
        [InlineData (0, 35)]
        [InlineData (1, 26)]
        [InlineData (2, 27)]
        [InlineData (3, 0)]
        [InlineData (4, -1)] // should this be 0?
        public void GetAge(int carIndex, int expected)
        {
            Assert.Equal (expected, carList[carIndex].GetAge());
        }
    }
}
