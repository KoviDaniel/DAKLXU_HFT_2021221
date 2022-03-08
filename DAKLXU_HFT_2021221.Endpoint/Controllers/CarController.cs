using DAKLXU_HFT_2021221.Logic;
using DAKLXU_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DAKLXU_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarLogic cl;
        private readonly IHubContext<SignalRHub> hub;
        public CarController(ICarLogic cl, IHubContext<SignalRHub> hub)
        {
            this.cl = cl;
            this.hub = hub;
        }

        // GET: /car
        [HttpGet]
        public List<Car> Get()
        {
            return this.cl.GetAll();
        }

        // GET /car/5
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return this.cl.GetOne(id);
        }

        // POST /car
        [HttpPost]
        public void Post([FromBody] Car value)
        {
            this.cl.Insert(value);
            hub.Clients.All.SendAsync("CarCreated", value);
        }

        // PUT /car
        [HttpPut/*("{id}")*/]
        public void Put(/*int id,*/ [FromBody] Car value)
        {
            this.cl.CarUpdate(/*id,*/ value);
            hub.Clients.All.SendAsync("CarUpdated", value);
        }

        // DELETE /car/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var car = this.cl.GetOne(id);
            this.cl.Remove(/*cl.GetOne(id)*/id);
            hub.Clients.All.SendAsync("CarDeleted", car);
        }
    }
}
