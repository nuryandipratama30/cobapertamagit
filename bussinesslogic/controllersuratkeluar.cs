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
    public class controllersuratkeluar
    {
        common DA;
        public DataTable getdatasuratkeluar()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT tsm.[no_surat]
      ,tf.[nama_officer]
      ,tsm.[tgl_surat]
      ,tsm.[perihal]
      ,tsm.[tujuan_surat]
      ,tsm.[catatan]
  FROM [db_si_notaris].[dbo].[tb_surat_keluar] tsm inner join [db_si_notaris].[dbo].[tb_officer] tf on tf.kode_officer=tsm.kode_officer
";
            DA = new common();
            DA.openkoneksi();
            dt = DA.executequery(query);
            DA.closekoneksi();

            return dt;

        }

        public DataTable getdatasuratkeluar(string id)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT tsm.[no_surat]
      ,tf.[nama_officer]
      ,tsm.[tgl_surat]
      ,tsm.[perihal]
      ,tsm.[tujuan_surat]
      ,tsm.[catatan]
  FROM [db_si_notaris].[dbo].[tb_surat_keluar] tsm inner join [db_si_notaris].[dbo].[tb_officer] tf on tf.kode_officer=tsm.kode_officer
  WHERE [no_surat] = @no_surat

";
            DA = new common();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@no_surat", id));

            DA.openkoneksi();
            dt = DA.executequery(query, param);
            DA.closekoneksi();

            return dt;

        }

        public DataTable getkodeofficer(string id)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT [kode_officer],[nama_officer]
  FROM [db_si_notaris].[dbo].[tb_officer] where [nama_officer]=@nama_officer";
            DA = new common();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@nama_officer", id));

            DA.openkoneksi();
            dt = DA.executequery(query, param);
            DA.closekoneksi();

            return dt;

        }

        public bool Insertdatasuratkeluar(string no_surat, string kode_officer, string tgl, string perihal, string asal_surat, string catatan)
        {
            try
            {
                DA = new common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@no_surat", no_surat));
                param.Add(new SqlParameter("@kode_officer", kode_officer));
                param.Add(new SqlParameter("@tgl_surat", tgl));
                param.Add(new SqlParameter("@perihal", perihal));
                param.Add(new SqlParameter("@tujuan_surat", asal_surat));
                param.Add(new SqlParameter("@catatan", catatan));
                DA.openkoneksi();
                DA.executenonquery(@"INSERT INTO [db_si_notaris].[dbo].[tb_surat_keluar]
           ([no_surat]
           ,[kode_officer]
           ,[tgl_surat]
           ,[perihal]
           ,[tujuan_surat]
           ,[catatan])
     VALUES
           (@no_surat
           ,@kode_officer
           ,@tgl_surat
           ,@perihal
           ,@tujuan_surat
           ,@catatan)", param);
                DA.closekoneksi();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Updatedatasuratkeluar(string no_surat, string kode_officer, string tgl, string perihal, string asal_surat, string catatan)
        {
            try
            {
                DA = new common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@no_surat", no_surat));
                param.Add(new SqlParameter("@kode_officer", kode_officer));
                param.Add(new SqlParameter("@tgl_surat", tgl));
                param.Add(new SqlParameter("@perihal", perihal));
                param.Add(new SqlParameter("@tujuan_surat", asal_surat));
                param.Add(new SqlParameter("@catatan", catatan));
                DA.openkoneksi();
                DA.executenonquery(@"UPDATE [db_si_notaris].[dbo].[tb_surat_keluar]
   SET [no_surat] = @no_surat
      ,[kode_officer] = @kode_officer
      ,[tgl_surat] = @tgl_surat
      ,[perihal] = @perihal
      ,[tujuan_surat] = @tujuan_surat
      ,[catatan] = @catatan
 WHERE [no_surat] = @no_surat", param);
                DA.closekoneksi();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Deletedatasuratkeluar(string p)
        {
            try
            {
                DA = new common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@no_surat", p));
                DA.openkoneksi();
                DA.executenonquery(@"DELETE FROM [db_si_notaris].[dbo].[tb_surat_keluar]
 WHERE [no_surat]=@no_surat", param);
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
