using System;
using System.Collections.Generic;
using CarsLib;
using Microsoft.AspNetCore.Mvc;
// using CarsApi.Handlers;

namespace CarsApi.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class CarsController : ControllerBase {

        static Car[] Cars = {};
        // DbHandler dbh = new DbHandler();

        public CarsController() {

        }

        [HttpGet]        
        public List<Car> Get () {
            throw new NotImplementedException();
        }

        [HttpGet("{rego}")]
        public Car GetCar(string rego) {
            throw new NotImplementedException();
        }
        
        [HttpPost]
        public int Post(Car newCar) {
            throw new NotImplementedException();
        }

        [HttpPut]
        public int PutUpdate(Car updateCar){
            throw new NotImplementedException();
        }

        [HttpDelete]
        public int Delete(Car deleteCar){
            throw new NotImplementedException();
        }
    }

}