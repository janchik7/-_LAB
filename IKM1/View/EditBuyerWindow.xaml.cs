﻿using IKM1.ViewModel;
using System;
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

namespace IKM1.View
{
    /// <summary>
    /// Логика взаимодействия для EditBuyerWindow.xaml
    /// </summary>
    public partial class EditBuyerWindow : Window
    {
        public EditBuyerWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
        }
    }
}
