using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budweg.Model
{
    public class CompanyRepository
    {

        ObservableCollection<Company> companyList = new ObservableCollection<Company>();

        protected string connectionString = "Server=10.56.8.36;Database=P1DB12;User Id=P1-12;Password=OPENDB_12";

        public void AddCompany(Company createdCompany)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                // Installation date is missing in Database table
                SqlCommand cmd = new SqlCommand("INSERT INTO Company(CompanyName, CVR, PhoneNumber, Email, Address, City, ZipCode) " +
                                                "VALUES(@CompanyName, @CVR, @PhoneNumber, @Email, @Address, @City, @ZipCode) ", con);
                cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = createdCompany.CompanyName;
                cmd.Parameters.Add("@CVR", SqlDbType.VarChar).Value = createdCompany.CVR;
                cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = createdCompany.PhoneNumber;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = createdCompany.Email;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = createdCompany.Address;
                cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = createdCompany.City;
                cmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = createdCompany.ZipCode;
                cmd.ExecuteNonQuery();

                // Check if everything got executed properly IF statement
            }

        }


        public ObservableCollection<Company> ReadCompanies()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (companyList.Count > 0)
                {
                    companyList.Clear();
                }

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT CompanyId, CompanyName, CVR, PhoneNumber, Email, Address, City, ZipCode FROM Company", con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        companyList.Add(new Company()
                        {

                            CompanyId = int.Parse(dr["CompanyId"].ToString()),
                            CompanyName = dr["CompanyName"].ToString(),
                            CVR = dr["CVR"].ToString(),
                            PhoneNumber = dr["PhoneNumber"].ToString(),
                            Email = dr["Email"].ToString(),
                            Address = dr["Address"].ToString(),
                            City = dr["City"].ToString(),
                            ZipCode = dr["ZipCode"].ToString()
                        }); ;
                    }
                }
            }
            return companyList;
        }

        public Company ReadCompany(int companyId) //Ability to read a company by companyId
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT CompanyId, CompanyName, CVR, PhoneNumber, Email, Address, City, ZipCode FROM Company WHERE CompanyId = @companyId", con);
                cmd.Parameters.Add("@companyId", SqlDbType.BigInt).Value = companyId; //Binds value to the above @companyId and thereby sets the value to be compared.
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new Company()
                        {
                            CompanyId = int.Parse(dr["CompanyId"].ToString()),
                            CompanyName = dr["CompanyName"].ToString(),
                            CVR = dr["CVR"].ToString(),
                            PhoneNumber = dr["PhoneNumber"].ToString(),
                            Email = dr["Email"].ToString(),
                            Address = dr["Address"].ToString(),
                            City = dr["City"].ToString(),
                            ZipCode = dr["ZipCode"].ToString()
                        };
                    }
                }
            }
            return null;
        }
    }
}
