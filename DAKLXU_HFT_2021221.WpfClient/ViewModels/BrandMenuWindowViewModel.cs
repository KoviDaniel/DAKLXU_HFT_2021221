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
    public class BrandMenuWindowViewModel : ObservableRecipient
    {
        public RestCollection<Brand> Brands { get; set; }

        private Brand selectedBrand;

        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set {
                if (value != null) {
                    selectedBrand = new Brand()
                    {
                        BrandID = value.BrandID,
                        BrandName = value.BrandName,
                        Cars = value.Cars
                    };
                    OnPropertyChanged();
                    (UpdateBrandCommand as RelayCommand).NotifyCanExecuteChanged();
                    (DeleteBrandCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateBrandCommand { get; set; }
        public ICommand UpdateBrandCommand { get; set; }
        public ICommand DeleteBrandCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public BrandMenuWindowViewModel()
        {
            if (!IsInDesignMode) {
                Brands = new RestCollection<Brand>("http://localhost:17167/", "brand");

                CreateBrandCommand = new RelayCommand(
                    () => {
                        Brands.Add(new Brand()
                        {
                            BrandName = SelectedBrand.BrandName
                        });
                    });

                UpdateBrandCommand = new RelayCommand(
                    () =>
                    {
                        Brands.Update(SelectedBrand);
                    },
                    () => SelectedBrand != null
                    );

                DeleteBrandCommand = new RelayCommand(
                    () => Brands.Delete(SelectedBrand.BrandID),
                    () => SelectedBrand !=null
                    );

                SelectedBrand = new Brand();
            }
        }
    }
}
