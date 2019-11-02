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
    public class controllersuratmasuk
    {
        common DA;
        public DataTable getdatasuratmasuk()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT tsm.[no_surat]
      ,tf.[nama_officer]
      ,tsm.[tgl_surat]
      ,tsm.[perihal]
      ,tsm.[asal_surat]
      ,tsm.[disposisi]
      ,tsm.[catatan]
  FROM [db_si_notaris].[dbo].[tb_surat_masuk] tsm inner join [db_si_notaris].[dbo].[tb_officer] tf on tf.kode_officer=tsm.kode_officer
";
            DA = new common();
            DA.openkoneksi();
            dt = DA.executequery(query);
            DA.closekoneksi();

            return dt;

        }

        public DataTable getdatasuratmasuk(string id)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT tsm.[no_surat]
      ,tf.[nama_officer]
      ,tsm.[tgl_surat]
      ,tsm.[perihal]
      ,tsm.[asal_surat]
      ,tsm.[disposisi]
      ,tsm.[catatan]
  FROM [db_si_notaris].[dbo].[tb_surat_masuk] tsm inner join [db_si_notaris].[dbo].[tb_officer] tf on tf.kode_officer=tsm.kode_officer
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

        public bool Insertdatasuratmasukklien(string no_surat, string kode_officer, string tgl, string perihal, string asal_surat, string disposisi, string catatan)
        {
            try
            {
                DA = new common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@no_surat", no_surat));
                param.Add(new SqlParameter("@kode_officer", kode_officer));
                param.Add(new SqlParameter("@tgl_surat", tgl));
                param.Add(new SqlParameter("@perihal", perihal));
                param.Add(new SqlParameter("@asal_surat", asal_surat));
                param.Add(new SqlParameter("@disposisi", disposisi));
                param.Add(new SqlParameter("@catatan", catatan));
                DA.openkoneksi();
                DA.executenonquery(@"INSERT INTO [db_si_notaris].[dbo].[tb_surat_masuk]
           ([no_surat]
           ,[kode_officer]
           ,[tgl_surat]
           ,[perihal]
           ,[asal_surat]
           ,[disposisi]
           ,[catatan])
     VALUES
           (@no_surat
           ,@kode_officer
           ,@tgl_surat
           ,@perihal
           ,@asal_surat
           ,@disposisi
           ,@catatan)", param);
                DA.closekoneksi();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Updatedatasuratmasuk(string no_surat, string kode_officer, string tgl, string perihal, string asal_surat, string disposisi, string catatan)
        {
            try
            {
                DA = new common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@no_surat", no_surat));
                param.Add(new SqlParameter("@kode_officer", kode_officer));
                param.Add(new SqlParameter("@tgl_surat", tgl));
                param.Add(new SqlParameter("@perihal", perihal));
                param.Add(new SqlParameter("@asal_surat", asal_surat));
                param.Add(new SqlParameter("@disposisi", disposisi));
                param.Add(new SqlParameter("@catatan", catatan));
                DA.openkoneksi();
                DA.executenonquery(@"UPDATE [db_si_notaris].[dbo].[tb_surat_masuk]
   SET [no_surat] = @no_surat
      ,[kode_officer] = @kode_officer
      ,[tgl_surat] = @tgl_surat
      ,[perihal] = @perihal
      ,[asal_surat] = @asal_surat
      ,[disposisi] = @disposisi
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
        public bool Deletedatasuratmasuk(string p)
        {
            try
            {
                DA = new common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@no_surat", p));
                DA.openkoneksi();
                DA.executenonquery(@"DELETE FROM [db_si_notaris].[dbo].[tb_surat_masuk]
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
