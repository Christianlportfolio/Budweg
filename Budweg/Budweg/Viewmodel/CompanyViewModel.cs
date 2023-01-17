using Budweg.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budweg.Viewmodel
{
    public class CompanyViewModel : ObservableObject
    {

        CompanyRepository companyRepo = new CompanyRepository();

        public string CompanyName { get; set; }
        public int CompanyId { get; set; }
        public string CVR { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        private ObservableCollection<Company> companies;

        public ObservableCollection<Company> Companies
        {
            get { return companies; }
            set 
            { 
                companies = value;
                OnPropertyChanged(nameof(Companies));
            }
        }



        public void CreateNewCompany(string company, string cvr, string phoneNumber, string email, string address, string city, string zipCode)
        {
            Company companyCreated = new Company(company, cvr, phoneNumber, email, address, city, zipCode);

            //companies.Add(companyCreated);
            companyRepo.AddCompany(companyCreated);

        }

        public void CreateNewCompany()
        {
            CreateNewCompany(CompanyName, CVR, PhoneNumber, Email, Address, City, ZipCode);
        }

    }
}
