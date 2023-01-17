using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budweg.Model;

namespace Budweg.Viewmodel
{
    public class MainViewModel
    {
        private CompanyRepository companyRepo = new CompanyRepository();

        public CompanyRepository CompanyRepo
        {
            get { return companyRepo; }
            set { companyRepo = value; }
        }

        private DamageTypeRepo damageRepo = new DamageTypeRepo();

        public DamageTypeRepo DamageRepo
        {
            get { return damageRepo; }
            set { damageRepo = value; }
        }

        private CaseRepository caseRepo;

        public CaseRepository CaseRepo
        {
            get { return caseRepo; }
            set { caseRepo = value; }
        }


        private ObservableCollection<CasesViewModel> casesViewModels = new ObservableCollection<CasesViewModel>();

        public CasesViewModel SelectedComplaintCase { get; set; }

        public ObservableCollection<CasesViewModel> CasesViewModels
        {
            get { return casesViewModels; }
        }

        public MainViewModel()
        {
            caseRepo = new CaseRepository(damageRepo, companyRepo);

            foreach (ComplaintCase c in caseRepo.FetchCases())
            {
                casesViewModels.Add(new CasesViewModel(c));
            }
        }
    }
}
