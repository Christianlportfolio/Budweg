using Budweg.View;
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

namespace Budweg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _NavigationFrame.Navigate(new ComplaintCasePage());

        }



     

        

        private void btnMenuItemCustomer_Click(object sender, RoutedEventArgs e)
        {
            CompanyPage companyPage = new CompanyPage();
            this._NavigationFrame.Navigate(companyPage);

            string headerTitle = "Kunder";
            LabelHeaderTitle.Content = headerTitle;

        }

        private void btnMenuItemComplaintCase_Click(object sender, RoutedEventArgs e)
        {
            ComplaintCasePage complaintCasePage = new ComplaintCasePage();
            _NavigationFrame.Navigate(complaintCasePage);

            string headerTitle = "Sager";
            LabelHeaderTitle.Content = headerTitle;
        }

        private void btnStatistic_Click(object sender, RoutedEventArgs e)
        {
            StatisticPage statisticPage = new StatisticPage();
            _NavigationFrame.Navigate(statisticPage);

            string headerTitle = "Statistik";
            LabelHeaderTitle.Content = headerTitle;
        }
    }
    
}
