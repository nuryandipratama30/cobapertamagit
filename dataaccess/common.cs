using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dataaccess
{
    public class common
    {
        private string kon = @"Data Source=R30\YANDI;Initial Catalog=db_si_notaris;Integrated Security=True";
        private static SqlConnection sqlcon;
        private static SqlCommand sqlcom;
        private static SqlTransaction sqltrans;

        public bool openkoneksi()
        {
            try
            {
                sqlcon = new SqlConnection(kon);
                sqlcon.Open();
                sqltrans = sqlcon.BeginTransaction();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public void closekoneksi()
        {
            try
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    sqltrans.Commit();
                    sqlcon.Close();
                }
            }
            catch (Exception ex)
            {
                if (sqltrans.Connection != null)
                {
                    sqltrans.Rollback();
                }
                throw new Exception(ex.Message, ex);
            }
        }

        public bool executenonquery(string query)
        {
            try
            {
                sqlcom = new SqlCommand(query, sqlcon, sqltrans);
                sqlcom.CommandType = CommandType.Text;
                sqlcom.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    if (sqltrans.Connection != null)
                    {
                        sqltrans.Rollback();
                    }
                    sqlcon.Close();
                }
                throw new Exception(ex.Message, ex);
            }
        }

        public bool executenonquery(string query, List<SqlParameter> param)
        {
            try
            {
                sqlcom = new SqlCommand(query, sqlcon, sqltrans);
                sqlcom.CommandType = CommandType.Text;
                sqlcom.Parameters.AddRange(param.ToArray());
                sqlcom.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    if (sqltrans.Connection != null)
                    {
                        sqltrans.Rollback();
                    }
                    sqlcon.Close();
                }
                throw new Exception(ex.Message, ex);
            }
        }

        public DataTable executequery(string query)
        {
            DataTable dt;
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                sqlcom = new SqlCommand(query, sqlcon, sqltrans);
                sqlcom.CommandType = CommandType.Text;
                dt = new DataTable();
                da.SelectCommand = sqlcom;
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    if (sqltrans.Connection != null)
                    {
                        sqltrans.Rollback();
                    }
                    sqlcon.Close();
                }
                throw new Exception(ex.Message, ex);
            }
        }

        public DataTable executequery(string query, List<SqlParameter> param)
        {
            DataTable dt;
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                sqlcom = new SqlCommand(query, sqlcon, sqltrans);
                sqlcom.CommandTimeout = 0;
                sqlcom.CommandType = CommandType.Text;
                sqlcom.Parameters.AddRange(param.ToArray());
                dt = new DataTable();
                da.SelectCommand = sqlcom;
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    if (sqltrans.Connection != null)
                    {
                        sqltrans.Rollback();
                    }
                    sqlcon.Close();
                }
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
