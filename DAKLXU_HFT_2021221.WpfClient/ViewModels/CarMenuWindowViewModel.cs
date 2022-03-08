using DAKLXU_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
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
    public class CarMenuWindowViewModel : ObservableRecipient
    {
        public RestCollection<Car> VMCars { get; set; }

        private Car selectedCar;

        public Car SelectedCar
        {
            get { return selectedCar; }
            set 
            {
                if (value != null) {
                    selectedCar = new Car()
                    {
                        CarID = value.CarID,
                        Brand = value.Brand,
                        BrandId = value.BrandId,
                        RentACar = value.RentACar,
                        RentCarID = value.RentCarID,
                        Model = value.Model,
                        RentPrice = value.RentPrice,
                        Colour = value.Colour,
                        CarInsurance = value.CarInsurance,
                        RunnedKM = value.RunnedKM
                    };
                    OnPropertyChanged();
                    (UpdateCarCommand as RelayCommand).NotifyCanExecuteChanged();
                    (DeleteCarCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateCarCommand { get; set; }
        public ICommand UpdateCarCommand { get; set; }
        public ICommand DeleteCarCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public CarMenuWindowViewModel()
        {
            if (!IsInDesignMode) {
                VMCars = new RestCollection<Car>("http://localhost:17167/", "car");

                CreateCarCommand = new RelayCommand(
                    ()=>VMCars.Add(new Car() { 
                        Brand = SelectedCar.Brand,
                        BrandId = SelectedCar.BrandId,
                        RentACar = SelectedCar.RentACar,
                        RentCarID = SelectedCar.RentCarID,
                        Model = SelectedCar.Model,
                        RentPrice = SelectedCar.RentPrice,
                        Colour = SelectedCar.Colour,
                        CarInsurance = SelectedCar.CarInsurance,
                        RunnedKM = SelectedCar.RunnedKM
                    })
                    );

                UpdateCarCommand = new RelayCommand(
                    ()=>VMCars.Update(SelectedCar),
                    ()=>SelectedCar!=null
                    );

                DeleteCarCommand = new RelayCommand(
                    () => VMCars.Delete(SelectedCar.CarID),
                    () => SelectedCar != null
                    );

                SelectedCar = new Car();
            }
        }
    }
}
