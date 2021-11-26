
using ConsoleTools;
using DAKLXU_HFT_2021221.Models;
using System;
using System.Collections.Generic;

namespace DAKLXU_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Rent-A-Car Database Client";
            System.Threading.Thread.Sleep(12000);
            RestService rest = new RestService("http://localhost:17167");
            bool exit = false;

            while (exit!=false)
            {
                int answer = MainMenu(ref exit);

                switch (answer) {
                    case 1:
                        int innerAnswer1 = CRUDMenu("CAR");
                        CarMenu(innerAnswer1, rest);
                        break;
                    case 2:
                        int innerAnswer2 = CRUDMenu("BRAND");
                        break;
                    case 3:
                        int innerAnswer3 = CRUDMenu("Rent-A-Car");
                        break;
                    case 4:
                        NonCRUDMenu(rest);
                        break;
                    case 5:
                        Console.WriteLine("Good bye");
                        break;
                    default:
                        Console.WriteLine("Default answer");
                        break;
                }
            }


        }

        static int MainMenu(ref bool exit) {
            Console.WriteLine("Welcome!\nPick an option from below");
            Console.WriteLine("---------------------------");
            Console.WriteLine("-  1  :  CAR CRUD         -");
            Console.WriteLine("-  2  :  BRAND CRUD       -");
            Console.WriteLine("-  3  :  Rent-A-Car CRUD  -");
            Console.WriteLine("-  4  :  NON-CRUD         -");
            Console.WriteLine("-  5  :  EXIT             -");
            Console.WriteLine("---------------------------");
            int answer = int.Parse(Console.ReadLine());
            if (answer == 5) exit = true;
            return answer;
        }

        static int CRUDMenu(string name) {
            Console.WriteLine("Pick an option from below:");
            Console.WriteLine("---------------------------");
            Console.WriteLine($"-  1  :  {name} CREATE   -");
            Console.WriteLine($"-  2  :  {name} READ ALL -");
            Console.WriteLine($"-  3  :  {name} READ ONE -");
            Console.WriteLine($"-  4  :  {name} UPDATE   -");
            Console.WriteLine($"-  5  :  {name} DELETE   -");
            Console.WriteLine("---------------------------");
            return int.Parse(Console.ReadLine());
        }

        static void NonCRUDMenu(RestService rest) {
            Console.WriteLine("Pick an option from below:");
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"-  1  :  CarOrderByPrice        -");
            Console.WriteLine($"-  2  :  CarsOrderbyKM          -");
            Console.WriteLine($"-  3  :  MostValuableCarOwner   -");
            Console.WriteLine($"-  4  :  MostRunnedKM           -");
            Console.WriteLine($"-  5  :  GroupByModels          -");
            Console.WriteLine("----------------------------------");
            int answer = int.Parse(Console.ReadLine());
            switch (answer) {
                
                case 1:
                    Console.WriteLine("Wich brand do you choose? Pick ID");
                    int i = int.Parse(Console.ReadLine());
                    rest.Get<Car>($"stat/carorderbyprice/{i}");
                    break;
                case 2:
                    Console.WriteLine("Wich brand do you choose? Pick ID");
                    int i2 = int.Parse(Console.ReadLine());
                    rest.Get<Car>($"stat/carsorderbykm/{i2}");
                    break;
                case 3:
                    Console.WriteLine("Wich brand do you choose? Pick ID");
                    int i3 = int.Parse(Console.ReadLine());
                    rest.Get<RentACar>($"stat/mostvaluablecarowner/{i3}");
                    break;
                case 4:
                    Console.WriteLine("Wich rent-a-car do you choose? Pick ID");
                    int i4 = int.Parse(Console.ReadLine());
                    rest.Get<Car>($"stat/mostrunnedkm/{i4}");
                    break;
                case 5:
                    Console.WriteLine("Wich rent-a-car do you choose? Pick ID");
                    int i5 = int.Parse(Console.ReadLine());
                    rest.Get<KeyValuePair<string, double>>($"stat/groupbymodels/{i5}");
                    break;
                default:
                    Console.WriteLine("Default answer NONCRUD");
                    break;
            }
        }

        static void CarMenu(int answer, RestService rest) {
            switch (answer) {
                case 1:
                    Console.WriteLine("Inserting a car");
                    Car car = new Car();
                    Console.WriteLine("Model:");
                    string model = Console.ReadLine();
                    car.Model = model;
                    Console.WriteLine("Rent price:");
                    int rentP = int.Parse(Console.ReadLine());
                    car.RentPrice = rentP;
                    Console.WriteLine("Colour:");
                    string col = Console.ReadLine();
                    car.Colour = col;
                    Console.WriteLine("Car insurance (y/n) :");
                    string ins = Console.ReadLine();
                    bool insurance;
                    if (ins == "y")
                    {
                        insurance = true;
                    }
                    else 
                    {
                        insurance = false;
                    }
                    car.CarInsurance = insurance;
                    Console.WriteLine("Runned KM");
                    int km = int.Parse(Console.ReadLine());
                    car.RunnedKM = km;
                    Console.WriteLine("Brand ID:");
                    int bID = int.Parse(Console.ReadLine());
                    Console.WriteLine("Rent-a-car ID:");
                    int rID = int.Parse(Console.ReadLine());
                    car.BrandId = bID;
                    car.RentCarID = rID;

                    rest.Post<Car>(car, "car");
                    break;
                case 2:
                    rest.Get<Car>("car");
                    break;
                case 3:
                    Console.WriteLine("Wich car do you want? Pick an ID");
                    int cID = int.Parse(Console.ReadLine());
                    rest.Get<Car>($"car/{cID}");
                    break;
                case 4:
                    Console.WriteLine("Wich car do you want to update? Pick an ID");
                    int updateID = int.Parse(Console.ReadLine());
                    Car updateCar = new Car();
                    Console.WriteLine("Model:");
                    string modelU = Console.ReadLine();
                    updateCar.Model = modelU;
                    Console.WriteLine("Rent price:");
                    int rentPU = int.Parse(Console.ReadLine());
                    updateCar.RentPrice = rentPU;
                    Console.WriteLine("Colour:");
                    string colU = Console.ReadLine();
                    updateCar.Colour = colU;
                    Console.WriteLine("Car insurance (y/n) :");
                    string insU = Console.ReadLine();
                    bool insuranceU;
                    if (insU == "y")
                    {
                        insuranceU = true;
                    }
                    else
                    {
                        insuranceU = false;
                    }
                    updateCar.CarInsurance = insuranceU;
                    Console.WriteLine("Runned KM");
                    int kmU = int.Parse(Console.ReadLine());
                    updateCar.RunnedKM = kmU;
                    Console.WriteLine("Brand ID:");
                    int bIDU = int.Parse(Console.ReadLine());
                    Console.WriteLine("Rent-a-car ID:");
                    int rIDU = int.Parse(Console.ReadLine());
                    updateCar.BrandId = bIDU;
                    updateCar.RentCarID = rIDU;

                    rest.Put<Car>(updateCar, $"car/{updateID}");
                    break;
                case 5:
                    Console.WriteLine("Wich car do you want to delete? Pick an ID");
                    int dID = int.Parse(Console.ReadLine());
                    rest.Delete(dID, "car");
                    break;
                default:
                    Console.WriteLine("DEAFAULT ANSWER CarMenu");
                    break;
            }
        }
    }
}
