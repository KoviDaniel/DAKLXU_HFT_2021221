using DAKLXU_HFT_2021221.Logic;
using DAKLXU_HFT_2021221.Models;
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
    class RentACarTester
    {
        RentACarLogic rl;

        [SetUp]
        public void Init() {
            var mockRentRepo = new Mock<IRentACarRepository>();
            Brand fakeBrand = new Brand();
            fakeBrand.BrandID = 1;
            fakeBrand.BrandName = "Volkswagen";
            rl = new RentACarLogic(mockRentRepo.Object);

            var rentACar = new List<RentACar>() { 
                new RentACar(){ 
                    RentCarID = 1,
                    RentName = "Rent-A-Car",
                    Rating = 3,
                    Cars = new List<Car>(){ 
                        new Car(){
                            CarID =1,
                            Model = "T5",
                            BrandId = 1,
                            Brand = fakeBrand,
                            RentCarID = 1,
                            RentACar = rl.GetOne(1),
                            RentPrice = 12300,
                            Colour = "Darkblue",
                            CarInsurance = true,
                            RunnedKM = 24500
                         },
                        new Car(){
                            CarID =2,
                            Model = "Passat",
                            BrandId = 1,
                            Brand = fakeBrand,
                            RentCarID = 1,
                            RentACar = rl.GetOne(1),
                            RentPrice = 7000,
                            Colour = "Gray",
                            CarInsurance = false,
                            RunnedKM = 134000
                        }
                    }
                },
                new RentACar(){ 
                    RentCarID = 2,
                    RentName = "Autókölcsönző",
                    Rating = 4,
                    Cars = new List<Car>(){ 
                        new Car(){
                            CarID =3,
                            Model = "Polo",
                            BrandId = 1,
                            Brand = fakeBrand,
                            RentCarID = 2,
                            RentACar = rl.GetOne(2),
                            RentPrice = 3000,
                            Colour = "Red",
                            CarInsurance = true,
                            RunnedKM = 200000
                        }
                    }
                }
            }.AsQueryable();

            mockRentRepo.Setup((t)=>t.GetAll()).Returns(rentACar);
        }


        [Test]
        public void RentACar_MostRunnedKMTest() {
            List<string> expected = new List<string>();
            List<string> result = new List<string>();

            Brand fakeBrand = new Brand();
            fakeBrand.BrandID = 1;
            fakeBrand.BrandName = "Volkswagen";

            Car car = new Car() {
                CarID = 2,
                Model = "Passat",
                BrandId = 1,
                Brand = fakeBrand,
                RentCarID = 1,
                RentACar = rl.GetOne(1),
                RentPrice = 7000,
                Colour = "Gray",
                CarInsurance = false,
                RunnedKM = 134000
            };

            foreach (var item in rl.MostRunnedKM(1))
            {
                result.Add(item.ToString());
            }
            expected.Add(car.ToString());

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GroupByModelsTest() {
            var result = rl.GroupByModels(2);

            var expected = new List<KeyValuePair<string, double>>() { 
                new KeyValuePair<string, double>("Volkswagen", 3000)
            };

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
