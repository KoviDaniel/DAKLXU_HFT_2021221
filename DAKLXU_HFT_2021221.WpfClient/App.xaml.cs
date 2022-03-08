using DAKLXU_HFT_2021221.WpfClient.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DAKLXU_HFT_2021221.WpfClient
{
    public partial class App : Application
    {
        public App()
        {
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                    .AddSingleton<IBrandMenuService, BrandMenuViaWindow>()
                    .AddSingleton<ICarMenuService, CarMenuViaWindow>()
                    .AddSingleton<IRentACarMenuService, RentACarMenuViaWindow>()
                    .BuildServiceProvider()
                );
        }
    }
}
