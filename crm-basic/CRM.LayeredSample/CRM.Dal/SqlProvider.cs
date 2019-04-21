using System;
using System.Collections.Generic;
using System.Data.SqlClient; //sql connection için ekledik
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Commonn;
namespace CRM.Dal

{   //Ado.net ile veritabanı işlemlermizi metot vb. ne varsa hepsini bu class içinde çekelim.
    public class SqlProvider
    {
        #region fieldsAndConstructors
        // Field alanım:
        SqlConnection cnn;
        SqlCommand cmd;

        //Constructors:
        public SqlProvider(string commandText, bool isProcedure)
        {
            cnn = new SqlConnection(Tools.ConnectionString);

            cmd = new SqlCommand(commandText, cnn);

            cmd.CommandType = isProcedure ? System.Data.CommandType.StoredProcedure: System.Data.CommandType.Text; //Text -> Sql Sorgumuz...
        }

        #endregion

        #region Parameters
        public void AddParameter(string parameterName, object value)
        {
            cmd.Parameters.AddWithValue(parameterName, value);
        }
        #endregion

        #region ConnectionMethods
        public void OpenConnection()
        {
            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();
        }
        #endregion

        #region CloseConnection
        public void CloseConnection()
        {
            if (cnn.State == System.Data.ConnectionState.Open)
                cnn.Close();
        }
        #endregion

        #region ExecuteMethods
        //Select için;
        public SqlDataReader ExecuteReader()
        {
            OpenConnection();

            return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection); //veri çekme işlemim bittiğinde iletişimi hemen kapat.
            //closeconnection();
        }

        //Insert - Update - Delete için;
        public int ExecuteNonQuery()
        {
            int result = -1;

            try
            {
                OpenConnection();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = -1;
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        //Scalar için;
        //Insert - Update - Delete için;
        public object ExecuteScalar()
        {
            object result = -1;

            try
            {
                OpenConnection();
                result = cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                result = null;
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }
        #endregion
    }
}
