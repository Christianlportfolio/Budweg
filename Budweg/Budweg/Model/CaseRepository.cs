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
    public class CaseRepository
    {
        protected string connectionString = "Server=10.56.8.36;Database=P1DB12;User Id=P1-12;Password=OPENDB_12";
        ObservableCollection<ComplaintCase> complaintCases = new ObservableCollection<ComplaintCase>();
        DamageTypeRepo damageRepo;
        CompanyRepository companyRepo;

        public void AddCase(ComplaintCase createdCase)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                // Installation date is missing in Database table
                SqlCommand cmd = new SqlCommand("INSERT INTO ComplaintCase(CompanyId, Date, OrderNumber, ItemNumber, Comment, DamageTypeId, InstallationDate, ComplaintStatusId, ContactPersonName, CaseFilledOutByName) " +
                                                "VALUES(@CompanyId, @Date, @OrderNumber, @ItemNumber, @Comment, @DamageTypeId, @InstallationDate, @ComplaintStatusId, @ContactPersonName, @CaseFilledOutByName); SELECT SCOPE_IDENTITY() ", con);
                cmd.Parameters.Add("@CompanyId", SqlDbType.BigInt).Value = createdCase.Company.CompanyId;
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = createdCase.Date;
                cmd.Parameters.Add("@OrderNumber", SqlDbType.VarChar).Value = createdCase.OrderNumber;
                cmd.Parameters.Add("@ItemNumber", SqlDbType.VarChar).Value = createdCase.ItemNumber;
                cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = createdCase.Comment;
                cmd.Parameters.Add("@DamageTypeId", SqlDbType.TinyInt).Value = createdCase.DamageType.DamageTypeId;
                cmd.Parameters.Add("@InstallationDate", SqlDbType.DateTime).Value = createdCase.InstallationDate;
                cmd.Parameters.Add("@ComplaintStatusId", SqlDbType.TinyInt).Value = createdCase.ComplaintStatusId;
                cmd.Parameters.Add("@ContactPersonName", SqlDbType.VarChar).Value = createdCase.ContactPersonName;
                cmd.Parameters.Add("@CaseFilledOutByName", SqlDbType.VarChar).Value = createdCase.CaseFilledOutByName;
                createdCase.ComplaintId = int.Parse(cmd.ExecuteScalar().ToString());

                // Check if everything got executed properly IF statement
            }

        }

        public ObservableCollection<ComplaintCase> FetchCases()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT ComplaintId, CompanyId, Date, OrderNumber, ItemNumber, Comment, DamageTypeId, InstallationDate, ComplaintStatusId, ContactPersonName, CaseFilledOutByName FROM ComplaintCase", con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        complaintCases.Add(new ComplaintCase()
                        {
                            ComplaintId = int.Parse(dr["ComplaintId"].ToString()),
                            Date = DateTime.Parse(dr["Date"].ToString()),
                            OrderNumber = dr["OrderNumber"].ToString(),
                            ItemNumber = dr["ItemNumber"].ToString(),
                            Comment = dr["Comment"].ToString(),
                            ComplaintStatusId = int.Parse(dr["ComplaintStatusId"].ToString()),
                            CaseFilledOutByName = dr["CaseFilledOutByName"].ToString(),
                            InstallationDate = DateTime.Parse(dr["InstallationDate"].ToString()),
                            ContactPersonName = dr["ContactPersonName"].ToString(),
                            DamageType = damageRepo.Read((int.Parse(dr["DamageTypeId"].ToString()))),
                            Company = companyRepo.ReadCompany(int.Parse(dr["CompanyId"].ToString()))
                        });
                    }
                }
            }
            return complaintCases;
        }

        public void UpdateCase()
        {

        }

        public void DeleteCase(ComplaintCase complaintCase)
        {
            complaintCases.Remove(complaintCase);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM ComplaintCase WHERE ComplaintId = @ComplaintId", con);
                cmd.Parameters.Add("@ComplaintId", SqlDbType.NVarChar).Value = complaintCase.ComplaintId;

                cmd.ExecuteNonQuery();
            }
        }

        public CaseRepository(DamageTypeRepo damageRepo, CompanyRepository companyRepo)
        {
            this.damageRepo = damageRepo;
            this.companyRepo = companyRepo;
        }
    }
}
