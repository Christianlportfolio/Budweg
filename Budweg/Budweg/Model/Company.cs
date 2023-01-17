using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budweg.Model
{
    public class Company
    {
        public string CompanyName { get; set; }
        public int CompanyId { get; set; }
        public string CVR { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }


        
        public Company(string company, string cvr, string phoneNumber, string email, string address, string city, string zipCode)
        {
            CompanyName = company;
            CVR = cvr;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            City = city;
            ZipCode = zipCode;
        }

        public Company(int companyId)
        {
            CompanyId = companyId;
        }

        public Company()
        {

        }

        public override string ToString()
        {
            return string.Format("Navn: {0} Adresse: {1} {2} {3}", CompanyName, Address, City, ZipCode);
        }
    }
}
