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
    public class RentACarMenuWindowViewModel : ObservableRecipient
    {
        public RestCollection<RentACar> VMRents { get; set; }

        private RentACar selectedRent;

        public RentACar SelectedRent
        {
            get { return selectedRent; }
            set 
            {
                if (value != null)
                {
                    selectedRent = new RentACar() { 
                        RentCarID = value.RentCarID,
                        RentName = value.RentName,
                        Rating = value.Rating,
                        Cars = value.Cars
                    };
                    OnPropertyChanged();
                    (UpdateRentCommand as RelayCommand).NotifyCanExecuteChanged();
                    (DeleteRentCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateRentCommand { get; set; }
        public ICommand UpdateRentCommand { get; set; }
        public ICommand DeleteRentCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public RentACarMenuWindowViewModel()
        {
            if (!IsInDesignMode) {
                VMRents = new RestCollection<RentACar>("http://localhost:17167/", "rentacar");

                CreateRentCommand = new RelayCommand(
                    ()=>VMRents.Add(new RentACar() { 
                        RentName = SelectedRent.RentName,
                        Rating = SelectedRent.Rating
                    })
                    );

                UpdateRentCommand = new RelayCommand(
                    () => VMRents.Update(SelectedRent),
                    ()=>SelectedRent!=null
                    );

                DeleteRentCommand = new RelayCommand(
                    ()=>VMRents.Delete(SelectedRent.RentCarID),
                    ()=>SelectedRent!=null
                    );
            }
        }
    }
}
