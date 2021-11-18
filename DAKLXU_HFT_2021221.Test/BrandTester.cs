using DAKLXU_HFT_2021221.Logic;
using DAKLXU_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAKLXU_HFT_2021221.Test
{
    [TestFixture]
    class BrandTester
    {
        BrandLogic bl;

        [SetUp]
        public void Init() {
            var mockBrandRepo = new Mock<IBrandRepository>();
        }
    }
}
