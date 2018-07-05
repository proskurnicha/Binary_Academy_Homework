using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassLibrary;
using System.Web;
using WebParking.Services;
using System.Net.Http;
using System.Net;

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
            IEnumerable<Car> cars = _service.GetCars();
            if (cars == null)
                NotFound();

            return _service.GetCars();
        }

        // GET: api/Cars/5
        [HttpGet("{id}", Name = "Get")]
        public IEnumerable<Car> Get(string id)
        {
            IEnumerable<Car> cars = _service.GetCarsById(id);
            if (cars == null)
                NotFound();

            return _service.GetCarsById(id);
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
        public ActionResult Delete(string id)
        {
            if (_service.RemoveCarById(id))
                return StatusCode(204);

            return NotFound();
        }
    }
}
