using Budweg.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budweg.Viewmodel
{
    public class CasesViewModel : ObservableObject
    {
        public ComplaintCase SelectedComplaintCase { get; set; }

        public DateTime Date
        {
            get { return SelectedComplaintCase.Date; }
            set 
            {
                SelectedComplaintCase.Date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public string OrderNumber
        {
            get { return SelectedComplaintCase.OrderNumber; }
            set 
            {
                SelectedComplaintCase.OrderNumber = value;
                OnPropertyChanged(nameof(OrderNumber));
            }
        }

        public string ItemNumber
        {
            get { return SelectedComplaintCase.ItemNumber; }
            set 
            {
                SelectedComplaintCase.ItemNumber = value;
                OnPropertyChanged(nameof(ItemNumber));
            }
        }

        public string Comment
        {
            get { return SelectedComplaintCase.Comment; }
            set 
            {
                SelectedComplaintCase.Comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }

        public int ComplaintStatusId
        {
            get { return SelectedComplaintCase.ComplaintStatusId; }
            set 
            {
                SelectedComplaintCase.ComplaintStatusId = value;
                OnPropertyChanged(nameof(ComplaintStatusId));
            }
        }

        public string CaseFilledOutByName
        {
            get { return SelectedComplaintCase.CaseFilledOutByName; }
            set 
            {
                SelectedComplaintCase.CaseFilledOutByName = value;
                OnPropertyChanged(nameof(CaseFilledOutByName));
            }
        } 



        public DateTime? InstallationDate
        {
            get { return SelectedComplaintCase.InstallationDate; }
            set 
            {
                SelectedComplaintCase.InstallationDate = value;
                OnPropertyChanged(nameof(InstallationDate));
            }
        }

        public string ContactPersonName
        {
            get { return SelectedComplaintCase.ContactPersonName; }
            set 
            {
                SelectedComplaintCase.ContactPersonName = value;
                OnPropertyChanged(nameof(ContactPersonName));
            }
        }

        public DamageType DamageTypeId
        {
            get { return SelectedComplaintCase.DamageType; }
            set 
            {
                SelectedComplaintCase.DamageType = value;
                OnPropertyChanged(nameof(DamageTypeId));
            }
        }

        public Company SelectedCompany
        {
            get { return SelectedComplaintCase.Company; }
            set 
            {
                SelectedComplaintCase.Company = value;
                OnPropertyChanged(nameof(SelectedCompany));
            }
        }

        public CasesViewModel(ComplaintCase complaintCase)
        {
            SelectedComplaintCase = complaintCase;
        }

        public CasesViewModel()
        {
            SelectedComplaintCase = new ComplaintCase();
        }
    }
}
