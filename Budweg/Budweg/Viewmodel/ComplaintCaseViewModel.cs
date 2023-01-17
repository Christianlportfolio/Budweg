using Budweg.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budweg.Viewmodel
{
    class ComplaintCaseViewModel : ObservableObject
    {
        private CompanyRepository companyRepo;

        private DamageTypeRepo damageRepo;

        private CaseRepository caseRepo;



        private ObservableCollection<Company> listOfCompanies;

        public ObservableCollection<Company> ListOfCompanies
        {
            get { return listOfCompanies; }
            set 
            { 
                listOfCompanies = value;
                OnPropertyChanged(nameof(ListOfCompanies));
            }
        }

        private ObservableCollection<DamageType> listOfDamageTypes;

        public ObservableCollection<DamageType> ListOfDamageTypes
        {
            get { return listOfDamageTypes; }
            set 
            { 
                listOfDamageTypes = value;
                OnPropertyChanged(nameof(ListOfDamageTypes));
            }
        }



        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        private string orderNumber;
        public string OrderNumber
        {
            get { return orderNumber; }
            set
            {
                orderNumber = value;
                OnPropertyChanged(nameof(OrderNumber));
            }
        }

        private string itemNumber;
        public string ItemNumber
        {
            get { return itemNumber; }
            set
            {
                itemNumber = value;
                OnPropertyChanged(nameof(ItemNumber));
            }
        }

        private string comment;
        public string Comment
        {
            get { return comment; }
            set
            {
                comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }

        private int complaintStatusId;
        public int ComplaintStatusId
        {
            get { return complaintStatusId; }
            set
            {
                complaintStatusId = value;
                OnPropertyChanged(nameof(ComplaintStatusId));
            }
        }

        private string caseFilleOutByName;
        public string CaseFilledOutByName
        {
            get { return caseFilleOutByName; }
            set
            {
                caseFilleOutByName = value;
                OnPropertyChanged(nameof(CaseFilledOutByName));
            }
        }


        private DateTime? installationDate;
        public DateTime? InstallationDate
        {
            get { return installationDate; }
            set
            {
                installationDate = value;
                OnPropertyChanged(nameof(InstallationDate));
            }
        }

        private string contactPersonName;
        public string ContactPersonName
        {
            get { return contactPersonName; }
            set
            {
                contactPersonName = value;
                OnPropertyChanged(nameof(ContactPersonName));
            }
        }


        private DamageType selectedDamageType;
        public DamageType SelectedDamageType
        {
            get { return selectedDamageType; }
            set
            {
                selectedDamageType = value;
                OnPropertyChanged(nameof(SelectedDamageType));
            }
        }


        private Company selectedCompany;

        public Company SelectedCompany
        {
            get { return selectedCompany; }
            set
            {
                selectedCompany = value;
                OnPropertyChanged(nameof(SelectedCompany));
            }
        }


        public void CreateCase(DateTime date, string orderNumber, string itemNumber, string comment, int complaintStatusId, string caseFilledOutByName, DateTime? installationDate, string contactPersonName, DamageType damageType, Company company)
        {
            ComplaintCase createdCase = new ComplaintCase(date, orderNumber, itemNumber, comment, complaintStatusId, caseFilledOutByName, installationDate, contactPersonName, damageType, company);
            caseRepo.AddCase(createdCase);
        }

        public void CreateCase()
        {
            CreateCase(Date, OrderNumber, ItemNumber, Comment, ComplaintStatusId, CaseFilledOutByName, InstallationDate, ContactPersonName, SelectedDamageType, SelectedCompany);
        }

        public void ReadCompanies()
        {
            ListOfCompanies = companyRepo.ReadCompanies();
        }

        public ComplaintCaseViewModel(CaseRepository caseRepo, DamageTypeRepo damageRepo, CompanyRepository companyRepo)
        {
            this.caseRepo = caseRepo;
            this.damageRepo = damageRepo;
            this.companyRepo = companyRepo;
            ReadCompanies();
            ListOfDamageTypes = damageRepo.GetAllDamageTypes();
        }
    }
}
