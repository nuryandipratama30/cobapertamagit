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
    public class controllerofficer
    {
        common DA;
        public DataTable getdataofficer()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT [kode_officer]
      ,[nama_officer]
      ,[telp]
      ,[alamat]
      ,[bagian]
      ,[status]
  FROM [db_si_notaris].[dbo].[tb_officer]
";
            DA = new common();
            DA.openkoneksi();
            dt = DA.executequery(query);
            DA.closekoneksi();

            return dt;

        }

        public DataTable getdataofficer(string id)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT [kode_officer]
      ,[nama_officer]
      ,[telp]
      ,[alamat]
      ,[bagian]
      ,[status]
  FROM [db_si_notaris].[dbo].[tb_officer]
  WHERE [kode_officer] = @kode_officer 

";
            DA = new common();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@kode_officer", id));

            DA.openkoneksi();
            dt = DA.executequery(query, param);
            DA.closekoneksi();

            return dt;

        }

        public bool Insertdataofficer(string kode,string nama, string telp, string almt,string bagian,string status)
        {
            try
            {
                DA = new common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_officer", kode));
                param.Add(new SqlParameter("@nama_officer", nama));
                param.Add(new SqlParameter("@telp", telp));
                param.Add(new SqlParameter("@alamat", almt));
                param.Add(new SqlParameter("@bagian", bagian));
                param.Add(new SqlParameter("@status", status));
                DA.openkoneksi();
                DA.executenonquery(@"INSERT INTO [dbo].[tb_officer]
           ([kode_officer]
           ,[nama_officer]
           ,[telp]
           ,[alamat]
           ,[bagian]
           ,[status])
     VALUES
           (@kode_officer
           ,@nama_officer
           ,@telp
           ,@alamat
           ,@bagian
           ,@status)", param);
                DA.closekoneksi();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Updatedataofficer(string kode, string nama, string telp, string almt, string bagian, string status)
        {
            try
            {
                DA = new common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_officer", kode));
                param.Add(new SqlParameter("nama_officer", nama));
                param.Add(new SqlParameter("@telp", telp));
                param.Add(new SqlParameter("@alamat", almt));
                param.Add(new SqlParameter("@bagian", bagian));
                param.Add(new SqlParameter("@status", status));
                DA.openkoneksi();
                DA.executenonquery(@"UPDATE [db_si_notaris].[dbo].[tb_officer]
   SET [kode_officer] = @kode_officer
      ,[nama_officer] = @nama_officer
      ,[telp] = @telp
      ,[alamat] = @alamat
      ,[bagian] = @bagian
      ,[status] = @status
       WHERE [kode_officer] = @kode_officer", param);
                DA.closekoneksi();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Deletedataofficer(string p)
        {
            try
            {
                DA = new common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_officer", p));
                DA.openkoneksi();
                DA.executenonquery("DELETE FROM [db_si_notaris].[dbo].[tb_officer] WHERE [kode_officer]=@kode_officer", param);
                DA.closekoneksi();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
