using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Commonn;
using CRM.Entity;

namespace CRM.Dal
{
    public class customerDAL
    {
       

        public Result<List<Customer>> ListOfCustomer()
        {
            Result<List<Customer>> rlc = new Result<List<Customer>>();

            SqlProvider sqlProvider = new SqlProvider("Select * From Customers", false);

            SqlDataReader reader = sqlProvider.ExecuteReader();

            rlc.IsSucceeded = rlc != null;

            List<Customer> allCustomers = new List<Customer>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Customer c = new Customer()
                    {
                        Id = Convert.ToInt32(reader["Id"]), 
                        //--------------------------------------------------------- 
                        Name = reader["Name"].ToString(),
                        Surname = reader["Surname"].ToString(),
                        Adress = reader["Adress"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Mail = reader["Mail"].ToString(),
                        Country = reader["Country"].ToString(),
                        PhotoPath = reader["PhotoPath"].ToString(),
                        Gender = Convert.ToBoolean(reader["Gender"]),
                        CreateDate = Convert.ToDateTime(reader["CreateDate"]),
                         City = reader["City"].ToString()
                        
                    };
                    allCustomers.Add(c);
                }
            }
            reader.Close();
            rlc.TransactionResult = allCustomers;
            return rlc;
        }

        // Save Metodum :
        public Result Save(Customer instance)
        {
            Result result = new Result(); 

            int returnValue = 0;

            SqlProvider sqlProvider = new SqlProvider("Insert Into Customers (Name, Surname, Adress, Phone, Mail, City, Country, Gender, PhotoPath, CreateDate) Values (@Name, @Surname, @Adress, @Phone, @Mail, @City, @Country, @Gender, @PhotoPath, @CreateDate)", false);

            
            sqlProvider.AddParameter("@Name", instance.Name);
            sqlProvider.AddParameter("@Surname", instance.Surname);
            sqlProvider.AddParameter("@Adress", instance.Adress);
            sqlProvider.AddParameter("@Phone", instance.Phone);
            sqlProvider.AddParameter("@Mail", instance.Mail);
            sqlProvider.AddParameter("@City", instance.City);
            sqlProvider.AddParameter("@Country", instance.Country);
            sqlProvider.AddParameter("@Gender", instance.Gender);
            sqlProvider.AddParameter("@PhotoPath", instance.PhotoPath);
            sqlProvider.AddParameter("@CreateDate", instance.CreateDate);

            returnValue = sqlProvider.ExecuteNonQuery();
            result.IsSucceeded = returnValue != -1;

            
            return result;
        }


        // Update Metodum : 
        public Result Update(Customer newinstance)
        {
            Result result = new Result(); 

            int returnValue = 0;

            SqlProvider sqlProvider = new SqlProvider("Update Customers Set Name = @Name, Surname = @Surname, Adress=@Adress, Phone = @Phone, Mail=@Mail,City = @City, Country=@Country, Gender=@Gender,PhotoPath=@PhotoPath,CreateDate=@CreateDate Where Id=@Id", false);

            sqlProvider.AddParameter("@Id", newinstance.Id);
            sqlProvider.AddParameter("@Name", newinstance.Name);
            sqlProvider.AddParameter("@Surname", newinstance.Surname);
            sqlProvider.AddParameter("@Adress", newinstance.Adress);
            sqlProvider.AddParameter("@Phone", newinstance.Phone);
            sqlProvider.AddParameter("@Mail", newinstance.Mail);
            sqlProvider.AddParameter("@City", newinstance.City);
            sqlProvider.AddParameter("@Country", newinstance.Country);
            sqlProvider.AddParameter("@Gender", newinstance.Gender);
            sqlProvider.AddParameter("@PhotoPath", newinstance.PhotoPath);
            sqlProvider.AddParameter("@CreateDate", newinstance.CreateDate);

            returnValue = sqlProvider.ExecuteNonQuery();
            result.IsSucceeded = returnValue != -1;
            
            return result;
        }


       
        public Result Delete(Object instanceId)
        {
            Result result = new Result(); 

            int returnValue = 0;

            SqlProvider sqlProvider = new SqlProvider("Delete From Customers Where Id=@Id", false);

            sqlProvider.AddParameter("@Id", instanceId);
            returnValue = sqlProvider.ExecuteNonQuery();
            result.IsSucceeded = returnValue != -1;


            return result;
        }
    }
}
