using DAKLXU_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAKLXU_HFT_2021221.Logic
{
    public class CarLogic
    {
        #region CTOR & REPO (carRepo)
        ICarRepository carRepo;
        public CarLogic(ICarRepository carRepo)
        {
            this.carRepo = carRepo;
        }
        #endregion
    }
}
