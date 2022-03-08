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
    public class BrandController : ControllerBase
    {
        IBrandLogic bl;
        private readonly IHubContext<SignalRHub> hub;
        public BrandController(IBrandLogic bl, IHubContext<SignalRHub> hub)
        {
            this.bl = bl;
            this.hub = hub;
        }

        // GET: /brand
        [HttpGet]
        public List<Brand> Get()
        {
            return this.bl.GetAll(); ;
        }

        // GET /brand/5
        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            return this.bl.GetOne(id);
        }

        // POST /brand
        [HttpPost]
        public void Post([FromBody] Brand value)
        {
            this.bl.Insert(value);
            hub.Clients.All.SendAsync("BrandCreated", value);
        }

        // PUT /brand/5
        [HttpPut/*("{id}")*/]
        public void Put(/*int id,*/ [FromBody] Brand value)
        {
            this.bl.BrandUpdate(/*id,*/ value);
            hub.Clients.All.SendAsync("BrandUpdated", value);
        }

        // DELETE /brand/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var brand = this.bl.GetOne(id);
            this.bl.Remove(id);
            hub.Clients.All.SendAsync("BrandDeleted", brand);
        }
    }
}
