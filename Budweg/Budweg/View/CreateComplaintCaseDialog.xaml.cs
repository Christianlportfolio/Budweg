using Budweg.Model;
using Budweg.Viewmodel;
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
    /// Interaction logic for CreateComplaintCaseDialog.xaml
    /// </summary>
    public partial class CreateComplaintCaseDialog : Window
    {
        ComplaintCaseViewModel viewModel;

        public CreateComplaintCaseDialog(CaseRepository caseRepo, DamageTypeRepo damageRepo, CompanyRepository companyRepo)
        {
            InitializeComponent();
            viewModel = new ComplaintCaseViewModel(caseRepo, damageRepo, companyRepo);
            DataContext = viewModel;
        }
        
        private void btnCreateComplaintCase_Click(object sender, RoutedEventArgs e)
        {
            viewModel.CreateCase();
            MessageBox.Show("Reklamationssag oprettet");
            DialogResult = true;
        }

        private void cbSubmittedByCompany_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
