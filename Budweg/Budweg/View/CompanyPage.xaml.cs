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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Budweg.View
{
    /// <summary>
    /// Interaction logic for CustomerPage.xaml
    /// </summary>
    public partial class CompanyPage : Page
    {
        public CompanyPage()
        {
            InitializeComponent();
        }




        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            CreateCompanyDialog createCustomerDialog = new CreateCompanyDialog();
            createCustomerDialog.ShowDialog();
        }
    }

   
}
