﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FirstFloor.ModernUI.Windows.Media;
using IKA.ViewModels;
using MessageBox = System.Windows.Forms.MessageBox;

namespace IKA.Views
{
    /// <summary>
    /// Interaction logic for FarKornaView.xaml
    /// </summary>
    public partial class HeadlightView
    {
        public HeadlightView()
        {
            InitializeComponent();
            this.DataContext = ViewModelsContainer.HeadlightViewModel;
        }
    }
}
