
using DAKLXU_HFT_2021221.Models;

using System;
using System.Threading;

namespace DAKLXU_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(12000);

            RestService rest = new RestService("http://localhost:17167");
        }
    }
}
