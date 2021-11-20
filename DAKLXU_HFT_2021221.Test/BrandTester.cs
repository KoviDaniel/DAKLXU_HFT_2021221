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
    class BrandTester
    {
        BrandLogic bl;

        [SetUp]
        public void Init() {
            var mockBrandRepo = new Mock<IBrandRepository>();
            RentACar fakeRent = new RentACar();
            fakeRent.RentCarID = 1;
            fakeRent.RentName = "Rent";
            fakeRent.Rating = 3;

            var brands = new List<Brand>() { 
                new Brand(){ 
                    BrandID = 1,
                    BrandName = "Volkswagen",
                    Cars = new List<Car>(){
                         new Car(){
                            CarID =1,
                            Model = "T5",
                            BrandId = 1,
                            Brand = bl.GetOne(1),
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
                            Brand = bl.GetOne(1),
                            RentCarID = 1,
                            RentACar = fakeRent,
                            RentPrice = 7000,
                            Colour = "Gray",
                            CarInsurance = false,
                            RunnedKM = 134000
                         }
                    }
                },
                new Brand(){ 
                    BrandID = 2,
                    BrandName = "Citroen",
                    Cars = new List<Car>(){ 
                        new Car(){
                            CarID = 3,
                            Model = "306",
                            BrandId = 2,
                            Brand = bl.GetOne(2),
                            RentCarID = 1,
                            RentACar = fakeRent,
                            RentPrice = 4500,
                            Colour = "Red",
                            CarInsurance = false,
                            RunnedKM = 245070
                        },
                        new Car(){
                            CarID =4,
                            Model = "406",
                            BrandId = 2,
                            Brand = bl.GetOne(2),
                            RentCarID = 1,
                            RentACar = fakeRent,
                            RentPrice = 6700,
                            Colour = "Yellow",
                            CarInsurance = true,
                            RunnedKM = 12000
                        }
                    }
                }
            }.AsQueryable();

            mockBrandRepo.Setup((t) => t.GetAll()).Returns(brands);
            bl = new BrandLogic(mockBrandRepo.Object);
        }

        //NON-CRUDS
        [Test]
        public void CarOrderByPriceTest() {
            
            RentACar fakeRent = new RentACar();
            fakeRent.RentCarID = 1;
            fakeRent.RentName = "Rent";
            fakeRent.Rating = 3;
            var expecteds = new List<Car>() {
                         new Car(){
                            CarID =1,
                            Model = "T5",
                            BrandId = 1,
                            Brand = bl.GetOne(1),
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
                            Brand = bl.GetOne(1),
                            RentCarID = 1,
                            RentACar = fakeRent,
                            RentPrice = 7000,
                            Colour = "Gray",
                            CarInsurance = false,
                            RunnedKM = 134000
                         }
            };

            List<string> result = new List<string>();
            List<string> expected = new List<string>();

            foreach (var item in bl.CarOrderByPrice(1))
            {
                result.Add(item.ToString());
            }
            foreach (var item in expecteds)
            {
                expected.Add(item.ToString());
            }

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void OwnerTest() {
            RentACar expected = new RentACar() { 
                RentCarID = 1,
                RentName= "Rent",
                Rating = 3
            };
            var result = (RentACar)bl.MostValuableCarOwner(1);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
