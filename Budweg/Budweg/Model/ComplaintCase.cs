using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budweg.Model
{
    public class ComplaintCase
    {
        public int ComplaintId { get; set; }
        public DateTime Date { get; set; }
        public string OrderNumber { get; set; }
        public string ItemNumber { get; set; }
        public string Comment { get; set; }
        public int ComplaintStatusId { get; set; }
        public string CaseFilledOutByName { get; set; }
        public DateTime? InstallationDate { get; set; }
        public string ContactPersonName { get; set; }
        public DamageType DamageType { get; set; }
        public Company Company { get; set; }

     

        public ComplaintCase(int complaintId, DateTime date, string orderNumber, string itemNumber, string comment, int complaintStatusId, string casefilledoutbyName, DateTime? installationDate, string contactPersonName, DamageType damageTypeId, Company company)
        {
            ComplaintId = complaintId;
            OrderNumber = orderNumber;
            ItemNumber = itemNumber;
            Date = date;
            Comment = comment;
            ComplaintStatusId = complaintStatusId;
            CaseFilledOutByName = casefilledoutbyName;
            InstallationDate = installationDate;
            ContactPersonName = contactPersonName;
            DamageType = damageTypeId;
            Company = company;

        }

        public ComplaintCase(DateTime date, string orderNumber, string itemNumber, string comment, int complaintStatusId, string casefilledoutbyName, DateTime? installationDate, string contactPersonName, DamageType damageTypeId, Company company): this(-1, date, orderNumber, itemNumber, comment, complaintStatusId, casefilledoutbyName, installationDate, contactPersonName, damageTypeId, company)
        {

        }

        public ComplaintCase()
        {
            OrderNumber = "";
            ItemNumber = "";
            Date = new DateTime();
            Comment = "";
            ComplaintStatusId = 0;
            CaseFilledOutByName = "";
            InstallationDate = new DateTime();
            ContactPersonName = "";
            DamageType = new DamageType(1);
            Company = new Company("","","","","","","");
        }
    }
}
