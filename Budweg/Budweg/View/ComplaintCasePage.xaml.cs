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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Budweg.Viewmodel;

namespace Budweg.View
{
    /// <summary>
    /// Interaction logic for ComplaintCasePage.xaml
    /// </summary>
    public partial class ComplaintCasePage : Page
    {
        MainViewModel mvm = new MainViewModel();
       
        public ComplaintCasePage()
        {
            InitializeComponent();
            DataContext = mvm;
            //viewModel.GetCases();
        }


        private void btnCreateComplaintCase_Click(object sender, RoutedEventArgs e)
        {
            CreateComplaintCaseDialog createComplaintCase = new CreateComplaintCaseDialog((mvm as MainViewModel).CaseRepo, (mvm as MainViewModel).DamageRepo, (mvm as MainViewModel).CompanyRepo);

            createComplaintCase.ShowDialog();
        }

        private void lbComplaintCase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (lbComplaintCase != null)
            //{
            //    TbDamageType.Text = mvm.SelectedComplaintCase.DamageTypeId.DamageTypeDescription;
            //    TbInstallationDate.Text = mvm.SelectedComplaintCase.InstallationDate.ToString();
            //    /* TbCompanyName.Text = mvm.SelectedComplaintCase.SelectedCompany.CompanyName; */ //Change CompanyId name to maybe Selectedcompany?? Or CaseCompany??
            //    TbContactPerson.Text = mvm.SelectedComplaintCase.ContactPersonName;
            //    CbComplaintStatusId.SelectedItem = mvm.SelectedComplaintCase.ComplaintStatusId.ToString();
            //    TbComment.Text = mvm.SelectedComplaintCase.Comment;
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mvm.CaseRepo.DeleteCase(mvm.SelectedComplaintCase.SelectedComplaintCase);
            mvm.CasesViewModels.Remove(mvm.SelectedComplaintCase);
        }
    }
}
