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

namespace Budweg.View
{
    /// <summary>
    /// Interaction logic for CreateCustomerDialog.xaml
    /// </summary>
    public partial class CreateCompanyDialog : Window
    {
        public CreateCompanyDialog()
        {
            InitializeComponent();
        }

        private void btnCreateCustomer_Click(object sender, RoutedEventArgs e)
        {
            viewModel.CreateNewCompany();
            MessageBox.Show("Ny kunde er oprettet: " + viewModel.CompanyName);
            DialogResult = true;
        }
    }
}
