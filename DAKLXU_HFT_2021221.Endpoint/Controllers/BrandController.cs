using DAKLXU_HFT_2021221.Logic;
using DAKLXU_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
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
        public BrandController(IBrandLogic bl)
        {
            this.bl = bl;
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
        }

        // PUT /brand/5
        [HttpPut/*("{id}")*/]
        public void Put(/*int id,*/ [FromBody] Brand value)
        {
            this.bl.BrandUpdate(/*id,*/ value);
        }

        // DELETE /brand/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.bl.Remove(id);
        }
    }
}
