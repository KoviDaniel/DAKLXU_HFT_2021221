using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAKLXU_HFT_2021221.WpfClient.Services
{
    public class BrandMenuViaWindow : IBrandMenuService
    {
        public void OpenBrandMenuWindow()
        {
            new BrandMenuWindow().ShowDialog();
        }
    }
}
