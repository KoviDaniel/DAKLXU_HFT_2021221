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
    public class RentACarController : ControllerBase
    {
        IRentACarLogic rl;
        private readonly IHubContext<SignalRHub> hub;
        public RentACarController(IRentACarLogic rl, IHubContext<SignalRHub> hub)
        {
            this.rl = rl;
            this.hub = hub;
        }

        // GET: /rentacar
        [HttpGet]
        public List<RentACar> Get()
        {
            return this.rl.GetAll();
        }

        // GET /rentacar/5
        [HttpGet("{id}")]
        public RentACar Get(int id)
        {
            return this.rl.GetOne(id);
        }

        // POST /rentacar
        [HttpPost]
        public void Post([FromBody] RentACar value)
        {
            this.rl.Insert(value);
            hub.Clients.All.SendAsync("RentACarCreated", value);
        }

        // PUT /rentacar/5
        [HttpPut/*("{id}")*/]
        public void Put(/*int id,*/ [FromBody] RentACar value)
        {
            this.rl.RentACarUpdate(/*id,*/ value);
            hub.Clients.All.SendAsync("RentACarUpdated", value);
        }

        // DELETE /rentacar/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var rent = this.rl.GetOne(id);
            this.rl.Remove(/*rl.GetOne(id)*/id);
            hub.Clients.All.SendAsync("RentACarDeleted", rent);
        }
    }
}
