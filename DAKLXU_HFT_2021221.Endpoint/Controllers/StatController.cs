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
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IBrandLogic bl;
        IRentACarLogic rl;
        private readonly IHubContext<SignalRHub> hub;
        public StatController(IBrandLogic bl, IRentACarLogic rl, IHubContext<SignalRHub> hub)
        {
            this.bl = bl;
            this.rl = rl;
            this.hub = hub;
        }
        // GET: /stat/carorderbyprice/5
        [HttpGet("{id}")]
        public IEnumerable<Car> CarOrderByPrice(int id)
        {
            return bl.CarOrderByPrice(id);
        }

        // GET: /stat/carsorderbyKM/5
        [HttpGet("{id}")]
        public IEnumerable<Car> CarsOrderbyKM(int id)
        {
            return bl.CarsOrderbyKM(id);
        }

        // GET: /stat/mostvaluablecarowner/5
        [HttpGet("{id}")]
        public IEnumerable<RentACar> MostValuableCarOwner(int id)
        {
            return bl.MostValuableCarOwner(id);
        }

        // GET: /stat/mostrunnedkm/5
        [HttpGet("{id}")]
        public IEnumerable<Car> MostRunnedKM(int id)
        {
            return rl.MostRunnedKM(id);
        }

        // GET: /stat/groupbymodels/5
        [HttpGet("{id}")]
        public IEnumerable<KeyValuePair<string, double>> GroupByModels(int id)
        {
            return rl.GroupByModels(id);
        }
    }
}
