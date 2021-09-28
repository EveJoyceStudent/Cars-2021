using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CarsLib;

namespace CarsApi.Handlers
{
    public class DbHandler
    {
        static string connectionString = "Server=accttwo.czwzndcmtnya.us-east-1.rds.amazonaws.com;Database=CarsDB;User Id=admin;password=D4dd474b453";
        SqlConnection connection;

        public List<Car> GetCars(){
            List<Car> cars = new List<Car>();

            using (SqlConnection connection = new SqlConnection(connectionString)) {
            
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Car", connection);
                
                SqlDataReader result = command.ExecuteReader();
                
                // result of command.ExecuteReader is an object that can only be traversed one way
                while (result.Read())
                {
                    // convert the data from DB into the object neeeded
                    string registration = result.GetString(0);
                    string make = result.GetString(1);
                    string model = result.GetString(2);
                    int yearOfManufacture = result.GetInt32(3);
                    int speed = result.GetInt32(4);

                    cars.Add(new Car(registration, make, model, yearOfManufacture, speed));
                }
            }
            return cars;
        }

        public Car GetCarByRego(string rego){
            List<Car> carsList = this.GetCars();
            foreach(Car c in carsList) {
                if(c.Registration == rego) {
                    return c;
                }
            }
            return null;
        }

        public int AddCar(Car newCar){
            int rowsAffected;

            string query = "INSERT INTO Car VALUES (@registration, @make, @model, @yearOfManufacture, @speed)";

            using(SqlConnection connection = new SqlConnection(connectionString)) {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                 
                // SqlParameter is used to protect against SQL Injection
                SqlParameter registrationParam = new SqlParameter();
                registrationParam.ParameterName = "@registration";
                registrationParam.Value = newCar.Registration;

                SqlParameter makeParam = new SqlParameter();
                makeParam.ParameterName = "@make";
                makeParam.Value = newCar.Make;

                SqlParameter modelParam = new SqlParameter();
                modelParam.ParameterName = "@model";
                modelParam.Value = newCar.Model;

                SqlParameter yearOfManufactureParam = new SqlParameter();
                yearOfManufactureParam.ParameterName = "@yearOfManufacture";
                yearOfManufactureParam.Value = newCar.YearOfManufacture;

                SqlParameter speedParam = new SqlParameter();
                speedParam.ParameterName = "@speed";
                speedParam.Value = newCar.Speed;

                command.Parameters.Add(registrationParam);
                command.Parameters.Add(makeParam);
                command.Parameters.Add(modelParam);
                command.Parameters.Add(yearOfManufactureParam);
                command.Parameters.Add(speedParam);

                rowsAffected = command.ExecuteNonQuery();
            }
            return rowsAffected;
        }

        public int UpdateCar(Car updateCar){
            
            int rowsAffected;

            string query = "UPDATE Car SET MAKE=@make, MODEL=@model, YEAROFMANUFACTURE=@yearOfManufacture, SPEED=@speed WHERE REGISTRATION=@registration";

            using(SqlConnection connection = new SqlConnection(connectionString)) {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                // SqlParameter is used to protect against SQL Injection
                SqlParameter registrationParam = new SqlParameter();
                registrationParam.ParameterName = "@registration";
                registrationParam.Value = updateCar.Registration;

                SqlParameter makeParam = new SqlParameter();
                makeParam.ParameterName = "@make";
                makeParam.Value = updateCar.Make;

                SqlParameter modelParam = new SqlParameter();
                modelParam.ParameterName = "@model";
                modelParam.Value = updateCar.Model;

                SqlParameter yearOfManufactureParam = new SqlParameter();
                yearOfManufactureParam.ParameterName = "@yearOfManufacture";
                yearOfManufactureParam.Value = updateCar.YearOfManufacture;

                SqlParameter speedParam = new SqlParameter();
                speedParam.ParameterName = "@speed";
                speedParam.Value = updateCar.Speed;

                command.Parameters.Add(registrationParam);
                command.Parameters.Add(makeParam);
                command.Parameters.Add(modelParam);
                command.Parameters.Add(yearOfManufactureParam);
                command.Parameters.Add(speedParam);

                rowsAffected = command.ExecuteNonQuery();
            }
            return rowsAffected;
        }

        public int DeleteCar(Car deleteCar){
            int rowsAffected;

            string query = "DELETE FROM Car WHERE REGISTRATION=@registration AND MAKE=@make AND MODEL=@model AND YEAROFMANUFACTURE=@yearOfManufacture AND SPEED=@speed";

            using(SqlConnection connection = new SqlConnection(connectionString)) {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                // SqlParameter is used to protect against SQL Injection
                SqlParameter registrationParam = new SqlParameter();
                registrationParam.ParameterName = "@registration";
                registrationParam.Value = deleteCar.Registration;

                SqlParameter makeParam = new SqlParameter();
                makeParam.ParameterName = "@make";
                makeParam.Value = deleteCar.Make;

                SqlParameter modelParam = new SqlParameter();
                modelParam.ParameterName = "@model";
                modelParam.Value = deleteCar.Model;

                SqlParameter yearOfManufactureParam = new SqlParameter();
                yearOfManufactureParam.ParameterName = "@yearOfManufacture";
                yearOfManufactureParam.Value = deleteCar.YearOfManufacture;

                SqlParameter speedParam = new SqlParameter();
                speedParam.ParameterName = "@speed";
                speedParam.Value = deleteCar.Speed;

                command.Parameters.Add(registrationParam);
                command.Parameters.Add(makeParam);
                command.Parameters.Add(modelParam);
                command.Parameters.Add(yearOfManufactureParam);
                command.Parameters.Add(speedParam);

                rowsAffected = command.ExecuteNonQuery();
            }
            return rowsAffected;
        }
    }
}
