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
    class CRUDTester
    {
        CarLogic cl;
        BrandLogic bl;
        RentACarLogic rl;

        [SetUp]
        public void Init() {
            var mockCarRepo = new Mock<ICarRepository>();
            var mockBrandRepo = new Mock<IBrandRepository>();
            var mockRentRepo = new Mock<IRentACarRepository>();

            Brand fakeBrand = new Brand();
            fakeBrand.BrandID = 1;
            fakeBrand.BrandName = "Volkswagen";

            RentACar fakeRent = new RentACar();
            fakeRent.RentCarID = 1;
            fakeRent.RentName = "Car rent";
            fakeRent.Rating = 5;

            var cars = new List<Car>()
            {
                new Car(){ 
                    CarID =1,
                    Model = "T5",
                    BrandId = 1,
                    Brand = fakeBrand,
                    RentCarID = 1,
                    RentACar = fakeRent,
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
                    RentACar = fakeRent,
                    RentPrice = 7000,
                    Colour = "Gray",
                    CarInsurance = false,
                    RunnedKM = 134000
                }
            }.AsQueryable();
            fakeBrand.Cars = cars.ToList();
            fakeRent.Cars = cars.ToList();



            mockCarRepo.Setup((t) => t.GetAll()).Returns(cars);


            cl = new CarLogic(mockCarRepo.Object);
            bl = new BrandLogic(mockBrandRepo.Object);
            rl = new RentACarLogic(mockRentRepo.Object);
        }


        //Few CREATE test (car, brand, rent-a-car)
        [TestCase(null, 1)]
        [TestCase("", 1)]
        [TestCase("Car", -1)]
        public void CarInsertModelException(string name, int rentPrice)
        {
            Car c = new Car()
            {
                CarID = 3,
                BrandId = 1,
                RentCarID = 1,
                Model = name
                ,RentPrice = rentPrice
            };
            if (name == null)
            {
                Assert.Throws(typeof(ArgumentNullException), () => cl.Insert(c));
            }
            if (name == "")
            {
                Assert.Throws(typeof(ArgumentException), () => cl.Insert(c));
            }
            if (rentPrice < 0) {
                Assert.Throws(typeof(ArgumentOutOfRangeException), () => cl.Insert(c));
            }
        }

        [TestCase(null)]
        [TestCase("")]
        public void BrandInsertNameException(string name) {
            
            Brand b = new Brand() { 
                BrandID = 1,
                BrandName = name
            };
            if (name == null) {
                Assert.Throws(typeof(ArgumentNullException), () => bl.Insert(b));
            }
            if (name == "") {
                Assert.Throws(typeof(ArgumentException), () => bl.Insert(b));
            }
        }

        [TestCase(null, 3)]
        [TestCase("", 3)]
        [TestCase("Rent", 6)]
        public void RentACarInsertException(string name, double rating) {
            RentACar r = new RentACar() { 
                RentCarID = 1,
                RentName = name,
                Rating = (int)rating
            };
            if (name == null) Assert.Throws(typeof(ArgumentNullException), () => rl.Insert(r));
            if (name == "") Assert.Throws(typeof(ArgumentException), () => rl.Insert(r));
            if(rating <0 && rating >5) Assert.Throws(typeof(ArgumentOutOfRangeException), () => rl.Insert(r));
        }
    }
    
}

