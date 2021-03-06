﻿using System;
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

    public class TransactionsController : Controller
    {
        private Processing _service;

        public TransactionsController(Processing service)
        {
            _service = service;
        }

        //Вивести Transactions.log (GET)
        // GET: api/Transactions/log
        [HttpGet("log")]
        public IEnumerable<Transaction> GetLog()
        {
            return _service.GetTransactions();
        }

        //Вивести транзакції за останню хвилину(GET)
        // GET: api/Transactions
        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            return _service.GetTransactionsLastMinute();
        }

        //-Вивести транзакції за останню хвилину по одній конкретній машині(GET)
        // GET: api/Transactions/A
        [HttpGet("{id}")]
        public IEnumerable<Transaction> Get(string id)
        {
            return (_service.GetTransactionsLastMinute()).Where(x => x.IdentifierCar == id);
        }

        //Поповнити баланс машини(PUT)
        // PUT: api/Transactions/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]TopUpBalanceModel value)
        {
            IEnumerable<Car> cars = (_service.GetCars()).Where(x => x.Identifier == id);
            if (cars.Count() > 0)
                cars.First().TopUpBalance(value.Value);
        }
    }

    public class TopUpBalanceModel
    {
        public double Value { get; set; }
    }
}
