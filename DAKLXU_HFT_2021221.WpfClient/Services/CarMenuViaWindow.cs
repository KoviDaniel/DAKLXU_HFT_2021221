﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAKLXU_HFT_2021221.WpfClient.Services
{
    public class CarMenuViaWindow : ICarMenuService
    {
        public void OpenCarMenuWindow()
        {
            new CarMenuWindow().ShowDialog();
        }
    }
}
