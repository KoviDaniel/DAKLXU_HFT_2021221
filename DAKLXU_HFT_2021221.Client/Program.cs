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

            while (exit!=true)
            {
                int answer = MainMenu(ref exit);

                switch (answer) {
                    case 1:
                        int innerAnswer1 = CRUDMenu("CAR");
                        CarMenu(innerAnswer1, rest);
                        break;
                    case 2:
                        int innerAnswer2 = CRUDMenu("BRAND");
                        BrandMenu(innerAnswer2, rest);
                        break;
                    case 3:
                        int innerAnswer3 = CRUDMenu("Rent-A-Car");
                        RentMenu(innerAnswer3, rest);
                        break;
                    case 4:
                        NonCRUDMenu(rest);
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Goodbye");
                        Console.ReadLine();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("INVALID ANSWER");
                        Console.WriteLine("Press ENTER to countinue...");
                        Console.ReadLine();
                        break;
                }
            }

        }

        static int MainMenu(ref bool exit) {
            Console.Clear();
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
            Console.Clear();
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
            Console.Clear();
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
                    Console.Clear();
                    Console.WriteLine("Wich brand do you choose? Pick ID");
                    int i = int.Parse(Console.ReadLine());
                    List<Car> carByPrice=rest.Get<Car>($"stat/carorderbyprice/{i}");
                    foreach (var j in carByPrice)
                    {
                        Console.WriteLine($"********************\nID : {j.CarID},\nModel : {j.Model},\nBrand ID : {j.BrandId},\nRent-a-car ID : {j.RentCarID},\nRent price : {j.RentPrice},\n" +
                        $"Colour : {j.Colour},\nInsurance : {j.CarInsurance},\nRunned kilometer : {j.RunnedKM}\n*********************");
                    }
                    Console.WriteLine("Press ENTER to countinue...");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Wich brand do you choose? Pick ID");
                    int i2 = int.Parse(Console.ReadLine());
                    List<Car> carByKM=rest.Get<Car>($"stat/carsorderbykm/{i2}");
                    foreach (var j in carByKM)
                    {
                        Console.WriteLine($"********************\nID : {j.CarID},\nModel : {j.Model},\nBrand ID : {j.BrandId},\nRent-a-car ID : {j.RentCarID},\nRent price : {j.RentPrice},\n" +
                        $"Colour : {j.Colour},\nInsurance : {j.CarInsurance},\nRunned kilometer : {j.RunnedKM}\n*********************");
                    }
                    Console.WriteLine("Press ENTER to countinue...");
                    Console.ReadLine();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Wich brand do you choose? Pick ID");
                    int i3 = int.Parse(Console.ReadLine());
                    List<RentACar> rent=rest.Get<RentACar>($"stat/mostvaluablecarowner/{i3}");
                    foreach (var r in rent)
                    {
                        Console.WriteLine("***********************");
                        Console.WriteLine($"Rent-A-Car ID : {r.RentCarID},\nrent name : {r.RentName},\nrating : {r.Rating}" +
                            $"cars : \n[");
                        foreach (var c in r.Cars)
                        {
                            Console.WriteLine($"\t____________________________\n\tID : {c.CarID},\n\tModel : {c.Model},\n\tBrand ID : {c.BrandId},\n\tRent-a-car ID : {c.RentCarID},\n\tRent price : {c.RentPrice},\n" +
                        $"\tColour : {c.Colour},\n\tInsurance : {c.CarInsurance},\n\tRunned kilometer : {c.RunnedKM}\n\t____________________________");
                        }
                        Console.WriteLine("]");
                        Console.WriteLine("***********************");
                    }
                    Console.WriteLine("Press ENTER to countinue...");
                    Console.ReadLine();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Wich rent-a-car do you choose? Pick ID");
                    int i4 = int.Parse(Console.ReadLine());
                    List<Car>cars=rest.Get<Car>($"stat/mostrunnedkm/{i4}");
                    foreach (var j in cars)
                    {
                        Console.WriteLine($"********************\nID : {j.CarID},\nModel : {j.Model},\nBrand ID : {j.BrandId},\nRent-a-car ID : {j.RentCarID},\nRent price : {j.RentPrice},\n" +
                        $"Colour : {j.Colour},\nInsurance : {j.CarInsurance},\nRunned kilometer : {j.RunnedKM}\n*********************");
                    }
                    Console.WriteLine("Press ENTER to countinue...");
                    Console.ReadLine();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Wich rent-a-car do you choose? Pick ID");
                    int i5 = int.Parse(Console.ReadLine());
                    var groupByModels=rest.Get<KeyValuePair<string, double>>($"stat/groupbymodels/{i5}");
                    foreach (var j in groupByModels)
                    {
                        Console.WriteLine("*************************************");
                        Console.WriteLine($"Márka : {j.Key} - Összár : {j.Value}");
                        Console.WriteLine("*************************************");
                    }
                    Console.WriteLine("Press ENTER to countinue...");
                    Console.ReadLine();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("INVALID ANSWER");
                    Console.WriteLine("Press ENTER to countinue...");
                    Console.ReadLine();
                    break;
            }
        }

        static void CarMenu(int answer, RestService rest) {
            switch (answer) {
                case 1:
                    Console.Clear();
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
                    Console.WriteLine("CAR INSERTED TO THE DATABASE");
                    Console.WriteLine("Press ENTER to countinue...");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.Clear();
                    List<Car> cars = rest.Get<Car>("car");
                    Console.Clear();
                    foreach (var i in cars)
                    {
                        Console.WriteLine($"********************\nID : {i.CarID},\nModel : {i.Model},\nBrand ID : {i.BrandId},\nRent-a-car ID : {i.RentCarID},\nRent price : {i.RentPrice},\n" +
                        $"Colour : {i.Colour},\nInsurance : {i.CarInsurance},\nRunned kilometer : {i.RunnedKM}\n*********************");
                    }
                    Console.WriteLine("Press ENTER to countinue...");
                    Console.ReadLine();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Wich car do you want? Pick an ID");
                    int cID = int.Parse(Console.ReadLine());
                    var getOne = rest.Get<Car>(cID, $"car");
                    Console.Clear();
                    Console.WriteLine($"********************\nID : {getOne.CarID},\nModel : {getOne.Model},\nBrand ID : {getOne.BrandId},\nRent-a-car ID : {getOne.RentCarID},\nRent price : {getOne.RentPrice},\n" +
                        $"Colour : {getOne.Colour},\nInsurance : {getOne.CarInsurance},\nRunned kilometer : {getOne.RunnedKM}\n*********************");
                    Console.WriteLine("Press ENTER to countinue...");
                    Console.ReadLine();
                    break;
                case 4:
                    Console.Clear();
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
                    Console.WriteLine("CAR HAS BEEN UPDATED");
                    Console.WriteLine("Press ENTER to countinue...");
                    Console.ReadLine();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Wich car do you want to delete? Pick an ID");
                    int dID = int.Parse(Console.ReadLine());
                    rest.Delete(dID, "car");
                    Console.WriteLine("CAR DELETED FROM DATABASE");
                    Console.WriteLine("Press ENTER to countinue...");
                    Console.ReadLine();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("INVALID ANSWER");
                    Console.WriteLine("Press ENTER to countinue...");
                    Console.ReadLine();
                    break;
            }
        }

        static void BrandMenu(int answer, RestService rest) {
            Console.Clear();
            switch (answer) {
                case 1:
                    Console.WriteLine("Inserting a brand");
                    Console.WriteLine("Name:");
                    string name = Console.ReadLine();
                    Brand brand = new Brand();
                    brand.BrandName = name;
                    rest.Post<Brand>(brand, "brand");
                    Console.WriteLine("New brand inserted to tha database");
                    Console.WriteLine("Press ENTER to countinue...");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Get all brands from database");
                    List<Brand> brands = rest.Get<Brand>("brand");
                    foreach (var i in brands)
                    {
                        Console.WriteLine("***********************");
                        Console.WriteLine($"Brand ID : {i.BrandID},\nbrand name : {i.BrandName},\n" +
                            $"cars : \n[");
                        foreach (var c in i.Cars)
                        {
                            Console.WriteLine($"\t____________________________\n\tID : {c.CarID},\n\tModel : {c.Model},\n\tBrand ID : {c.BrandId},\n\tRent-a-car ID : {c.RentCarID},\n\tRent price : {c.RentPrice},\n" +
                        $"\tColour : {c.Colour},\n\tInsurance : {c.CarInsurance},\n\tRunned kilometer : {c.RunnedKM}\n\t____________________________");
                        }
                        Console.WriteLine("]");
                        Console.WriteLine("***********************");
                    }
                    Console.WriteLine("Press ENTER to countinue...");
                    Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Which brand do you want? Pick an ID");
                    int id = int.Parse(Console.ReadLine());
                    Console.Clear();
                    Brand brandOne = rest.Get<Brand>(id, "brand");
                    Console.WriteLine("***********************");
                    Console.WriteLine($"Brand ID : {brandOne.BrandID},\nbrand name : {brandOne.BrandName},\n" +
                        $"cars : \n[");
                    foreach (var c in brandOne.Cars)
                    {
                        Console.WriteLine($"\t____________________________\n\tID : {c.CarID},\n\tModel : {c.Model},\n\tBrand ID : {c.BrandId},\n\tRent-a-car ID : {c.RentCarID},\n\tRent price : {c.RentPrice},\n" +
                    $"\tColour : {c.Colour},\n\tInsurance : {c.CarInsurance},\n\tRunned kilometer : {c.RunnedKM}\n\t____________________________");
                    }
                    Console.WriteLine("]");
                    Console.WriteLine("***********************");
                    Console.WriteLine("Press ENTER to countinue...");
                    Console.ReadLine();
                    break;
                case 4:
                    Console.WriteLine("Which brand do you want to update? Pick an ID:");
                    int idU = int.Parse(Console.ReadLine());
                    Console.WriteLine("Brand name:");
                    string uName = Console.ReadLine();
                    List<Car> uCars = new List<Car>();
                    Console.WriteLine("How many car do you want to insert?");
                    int p = int.Parse(Console.ReadLine());
                    for (int i = 0; i < p; i++)
                    {
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
                        uCars.Add(car);
                        i++;
                        Console.ReadLine();
                        Console.Clear();
                    }
                    Brand uBRand = new Brand();
                    uBRand.BrandName = uName;
                    uBRand.BrandID = idU;
                    uBRand.Cars = uCars;
                    rest.Put<Brand>(uBRand, $"brand/{idU}");
                    Console.WriteLine("Brand has been updated");
                    Console.WriteLine("Press ENTER to countinue...");
                    Console.ReadLine();
                    break;
                case 5:
                    Console.WriteLine("Which brand do you want to delete? Pick an ID:");
                    int idd = int.Parse(Console.ReadLine());
                    rest.Delete(idd, "brand");
                    Console.WriteLine("Brand has been deleted");
                    Console.WriteLine("Press ENTER to countinue...");
                    Console.ReadLine();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("INVALID ANSWER");
                    Console.WriteLine("Press ENTER to countinue...");
                    Console.ReadLine();
                    break;
            }
        }

        static void RentMenu(int answer, RestService rest) {
            Console.Clear();
            switch (answer) {
                case 1:
                    RentACar rent = new RentACar();
                    Console.WriteLine("Inserting a rent-a-car company");
                    Console.WriteLine("Name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Rating:");
                    int rating = int.Parse(Console.ReadLine());
                    rent.RentName = name;
                    rent.Rating = rating;
                    rest.Post<RentACar>(rent, "rentacar");
                    Console.WriteLine("Rent-A-Car company inserted to the database");
                    Console.WriteLine("Press ENTER to countinue...");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Get all Rent-A-Car company from the datatbase");
                    List<RentACar> rents = rest.Get<RentACar>("rentacar");
                    foreach (var r in rents)
                    {
                        Console.WriteLine("***********************");
                        Console.WriteLine($"Rent-A-Car ID : {r.RentCarID},\nrent name : {r.RentName},\nrating : {r.Rating}" +
                            $"\ncars : \n[");
                        foreach (var c in r.Cars)
                        {
                            Console.WriteLine($"\t____________________________\n\tID : {c.CarID},\n\tModel : {c.Model},\n\tBrand ID : {c.BrandId},\n\tRent-a-car ID : {c.RentCarID},\n\tRent price : {c.RentPrice},\n" +
                        $"\tColour : {c.Colour},\n\tInsurance : {c.CarInsurance},\n\tRunned kilometer : {c.RunnedKM}\n\t____________________________");
                        }
                        Console.WriteLine("]");
                        Console.WriteLine("***********************");
                    }
                    Console.WriteLine("Press ENTER to countinue...");
                    Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Which rent-a-car company do you want? Pick an ID:");
                    int i = int.Parse(Console.ReadLine());
                    RentACar re = rest.Get<RentACar>(i, "rentacar");
                    Console.WriteLine("***********************");
                    Console.WriteLine($"Rent-A-Car ID : {re.RentCarID},\nrent name : {re.RentName},\nrating : {re.Rating}" +
                        $"\ncars : \n[");
                    foreach (var c in re.Cars)
                    {
                        Console.WriteLine($"\t____________________________\n\tID : {c.CarID},\n\tModel : {c.Model},\n\tBrand ID : {c.BrandId},\n\tRent-a-car ID : {c.RentCarID},\n\tRent price : {c.RentPrice},\n" +
                    $"\tColour : {c.Colour},\n\tInsurance : {c.CarInsurance},\n\tRunned kilometer : {c.RunnedKM}\n\t____________________________");
                    }
                    Console.WriteLine("]");
                    Console.WriteLine("***********************");
                    Console.WriteLine("Press ENTER to countinue...");
                    Console.ReadLine();
                    break;
                case 4:
                    Console.WriteLine("Which rent-a-car company do you want to update? Pick an ID:");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Name:");
                    string nameU = Console.ReadLine();
                    Console.WriteLine("Rating:");
                    int ratingU = int.Parse(Console.ReadLine());
                    List<Car> uCars = new List<Car>(); 
                    Console.WriteLine("How many car do you want to insert?");
                    int p = int.Parse(Console.ReadLine());
                    for (int j = 0; j < p; j++)
                    {
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
                        uCars.Add(car);
                        j++;
                        Console.ReadLine();
                        Console.Clear();
                    }
                    RentACar rentU = new RentACar();
                    rentU.RentName = nameU;
                    rentU.Rating = ratingU;
                    rentU.RentCarID = id;
                    rentU.Cars = uCars;
                    rest.Put<RentACar>(rentU, $"rentacar/{id}");
                    Console.WriteLine("Press ENTER to countinue...");
                    Console.ReadLine();
                    break;
                case 5:
                    Console.WriteLine("Which rent-a-car company do you want to delete? Pick an ID:");
                    int idd = int.Parse(Console.ReadLine());
                    rest.Delete(idd, "rentacar");
                    Console.WriteLine("Rent-a-car has been deleted from the database");
                    Console.WriteLine("Press ENTER to countinue...");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("INVALID ANSWER");
                    Console.WriteLine("Press ENTER to countinue...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
