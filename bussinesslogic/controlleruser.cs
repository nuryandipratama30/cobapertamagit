using dataaccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace bussinesslogic
{
    public class controlleruser
    {
        common da;

        public DataTable getdatauserhak(string username,string pass)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Username", username));
            param.Add(new SqlParameter("@password", pass));
            string query = @"SELECT [Username]
      ,[password]
      ,[status]
    FROM [db_si_notaris].[dbo].[tb_user]
    WHERE [Username]=@Username and [password]=@password ";
            da = new common();
            da.openkoneksi();
            dt = da.executequery(query,param);
            da.closekoneksi();
            return dt;
        }



        public DataTable getdatauserhak()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT [Username]
      ,[password]
      ,[status]
    FROM [db_si_notaris].[dbo].[tb_user]";
            da = new common();
            da.openkoneksi();
            dt = da.executequery(query);
            da.closekoneksi();
            return dt;
        }

        public bool insertdatauserhak(string Id, string kode, string kd_obat, string jmlh_obt, string cara_pakai)
        {
            try
            {
                da = new common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@id_pemberian_obat", Id));
                param.Add(new SqlParameter("@kode_periksa", kode));
                param.Add(new SqlParameter("@kode_obat", kd_obat));
                param.Add(new SqlParameter("@jumlah_obat", Int32.Parse(jmlh_obt)));
                param.Add(new SqlParameter("@cara_pemakaian", cara_pakai));

                string query = @"INSERT INTO [db_klinik].[dbo].[tb_pemberian_obatt]
           ([id_pemberian_obat]
           ,[kode_periksa]
           ,[kode_obat]
           ,[jumlah_obat]
           ,[cara_pemakaian])
     VALUES
           (@id_pemberian_obat
           ,@kode_periksa
           ,@kode_obat
           ,@jumlah_obat
           ,@cara_pemakaian)
";
                da.openkoneksi();
                da.executenonquery(query, param);
                da.closekoneksi();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }




        public bool updatedatauserhak(string Id, string kode, string kd_obat, string jmlh_obt, string cara_pakai)
        {
            try
            {
                da = new common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@id_pemberian_obat", Id));
                param.Add(new SqlParameter("@kode_periksa", kode));
                param.Add(new SqlParameter("@kode_obat", kd_obat));
                param.Add(new SqlParameter("@jumlah_obat", Int32.Parse(jmlh_obt)));
                param.Add(new SqlParameter("@cara_pemakaian", cara_pakai));

                string query = @"UPDATE [db_klinik].[dbo].[tb_pemberian_obatt]
   SET [id_pemberian_obat]=@id_pemberian_obat
      ,[kode_periksa] = @kode_periksa
      ,[kode_obat] = @kode_obat
      ,[jumlah_obat] = @jumlah_obat
      ,[cara_pemakaian] = @cara_pemakaian
WHERE [id_pemberian_obat]=@id_pemberian_obat";
                da.openkoneksi();
                da.executenonquery(query, param);
                da.closekoneksi();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool deletedatauserhak(string id)
        {
            try
            {
                da = new common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@id_pemberian_obat", id));
                string query = @"DELETE FROM [db_klinik].[dbo].[tb_pemberian_obatt]
      WHERE [id_pemberian_obat] = @id_pemberian_obat";
                da.openkoneksi();
                da.executenonquery(query, param);
                da.closekoneksi();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
