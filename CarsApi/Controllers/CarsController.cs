﻿using System;
using System.Collections.Generic;
using CarsLib;
using Microsoft.AspNetCore.Mvc;
using CarsApi.Handlers;

namespace CarsApi.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class CarsController : ControllerBase {

        DbHandler dbh = new DbHandler();

        public CarsController() {

        }

        [HttpGet]        
        public List<Car> Get () {
            return this.dbh.GetCars();
        }

        [HttpGet("{rego}")]
        public Car GetCar(string rego) {
            return this.dbh.GetCarByRego(rego);
        }
        
        [HttpPost]
        public string Post(Car newCar) {
            return this.dbh.AddCar(newCar);
        }

        [HttpPut]
        public string PutUpdate(Car updateCar){
            return this.dbh.UpdateCar(updateCar);
        }

        [HttpDelete]
        public string Delete(Car deleteCar){
            return this.dbh.DeleteCar(deleteCar);
        }
    }
}