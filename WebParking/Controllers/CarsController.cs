﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassLibrary;
using System.Web;
using WebParking.Services;

namespace WebParking.Controllers
{
    [Produces("application/json")]
    [Route("api/Cars")]
    public class CarsController : Controller
    {
        private Processing _service;

        public CarsController(Processing service)
        {
            _service = service;
        }

        // GET: api/Cars
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return _service.GetCars();
        }

        // GET: api/Cars/5
        [HttpGet("{id}", Name = "Get")]
        public IEnumerable<Car> Get(string id)
        {
            return (_service.GetCars()).Where(x => x.Identifier == id);
        }

        // POST: api/Cars
        [HttpPost]
        public Car Post([FromBody]Car car)
        {
            _service.AddCar(car);
            return car;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            (_service.GetCars()).RemoveAll(x => x.Identifier == id);
        }
    }
}
