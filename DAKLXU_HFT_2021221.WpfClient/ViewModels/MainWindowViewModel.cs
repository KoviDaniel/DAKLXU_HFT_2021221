using DAKLXU_HFT_2021221.WpfClient.Services;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DAKLXU_HFT_2021221.WpfClient.ViewModels
{
    public class MainWindowViewModel
    {
        IBrandMenuService brandMenuService;
        ICarMenuService carMenuService;
        IRentACarMenuService rentACarMenuService;

        public ICommand BrandMenuOpenerCommand { get; set; }
        public ICommand CarMenuOpenerCommand { get; set; }
        public ICommand RentACarMenuOpenerCommand { get; set; }

        static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
            : this(IsInDesignMode ? null : Ioc.Default.GetService<IBrandMenuService>(),
                  Ioc.Default.GetService<ICarMenuService>(),
                  Ioc.Default.GetService<IRentACarMenuService>())
        {

        }

        public MainWindowViewModel(IBrandMenuService bService, ICarMenuService cService, IRentACarMenuService rService)
        {
            if (!IsInDesignMode)
            {
                this.brandMenuService = bService;
                this.carMenuService = cService;
                this.rentACarMenuService = rService;

                BrandMenuOpenerCommand = new RelayCommand(
                    () => brandMenuService.OpenBrandMenuWindow()
                    );
                CarMenuOpenerCommand = new RelayCommand(
                    () => carMenuService.OpenCarMenuWindow()
                    );
                RentACarMenuOpenerCommand = new RelayCommand(
                    () => rentACarMenuService.OpenRentACarMenuWindow()
                    );
            }
        }
    }
}
