﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WpfCommon.Utils
{
    public class DialogService
    {
        public bool? ShowDialog(ViewModel viewModel)
        {
            CustomWindow window = new CustomWindow(viewModel);
            return window.ShowDialog();
        }
    }
}
