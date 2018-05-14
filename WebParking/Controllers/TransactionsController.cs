using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebParking.Services;

namespace WebParking.Controllers
{
    [Produces("application/json")]
    [Route("api/Transactions")]
    //-Вивести Transactions.log (GET)
    //-Вивести транзакції за останню хвилину(GET)
    //-Вивести транзакції за останню хвилину по одній конкретній машині(GET)
    //-Поповнити баланс машини(PUT)
    public class TransactionsController : Controller
    {
        private Processing _service;

        public TransactionsController(Processing service)
        {
            _service = service;
        }

        // GET: api/Cars


        //Вивести транзакції за останню хвилину(GET)
        // GET: api/Transactions
        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            return _service.GetTransaction();
        }

        // GET: api/Transactions/5
        [HttpGet("{id}")]
        public IEnumerable<Transaction> Get(string id)
        {
            return (_service.GetTransaction()).Where(x => x.IdentifierCar == id);
        }

        // PUT: api/Transactions/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Transaction value)
        {
            IEnumerable<Car> cars = (_service.GetCars()).Where(x => x.Identifier == id);
            if (cars != null)
                cars.First().TopUpBalance(value.WrittenOffFunds);
        }
    }
}
