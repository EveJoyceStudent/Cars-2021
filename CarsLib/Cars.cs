using System;

namespace CarsLib
{
    public class Car
    {
        public string Registration { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int YearOfManufacture { get; set; }
        public int Speed { get; set; }

        public Car() {}
        public Car(string registration, string make, string model, int yearOfManufacture, int speed)
        {
            Registration = registration;
            Make = make;
            Model = model;
            //  added year limit to constructor
            if(yearOfManufacture>DateTime.Now.Year){
                YearOfManufacture = DateTime.Now.Year;
            } else {
                YearOfManufacture = yearOfManufacture;
            }
            //  added speed limits to constructor
            if(speed<=0){
                Speed = 0;
            } else if(speed>=150){
                Speed = 150;
            } else {
                Speed = speed;
            }
        }

        // increases the speed of a Car.  Cannot exceed 150.  If negative number is given, change it to positive
        public void IncreaseSpeed(int speed){
            if(speed<0){
                speed*=-1;
            }
            this.Speed+=speed;
            if(this.Speed>150){
                this.Speed=150;
            }
        }
        
        // decreases the speed of a Car.  Cannot go below 0.  If negative number is given, change it to positive
        public void DecreaseSpeed(int speed){
            if(speed>0){
                speed*=-1;
            }
            this.Speed+=speed;
            if(this.Speed<0){
                this.Speed=0;
            }
        }
        
        // Gets the current age by year of the the car based on current year and year of manufacture.  *Hint use DateTime.Now
        public int GetAge(){
            return DateTime.Now.Year-this.YearOfManufacture;
        }

    }
}
