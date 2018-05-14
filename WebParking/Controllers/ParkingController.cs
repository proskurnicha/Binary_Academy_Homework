using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebParking.Services;

namespace WebParking.Controllers
{
    [Produces("application/json")]
    [Route("api/Parking")]
    public class ParkingController : Controller
    {
        private ProcessingParking _service;

        public ParkingController(ProcessingParking service)
        {
            _service = service;
        }

        //Кількість вільних місць
        // GET: api/Parking/free
        [HttpGet("free")]
        public int Get1()
        {
            return _service.GetCountFreePlace();
        }

        //-Кількість зайнятих місць(GET)
        [HttpGet("occupied")]
        public int Get2()
        {
            return _service.GetCountOqPlace();
        }

        //Загальний дохід(GET)
        [HttpGet("balance")]
        public double Get3()
        {
            return _service.GetBalance();
        }
    }
}
