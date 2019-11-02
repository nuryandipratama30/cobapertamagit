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
    public class controllermonitoringbpn
    {
        common DA;
        public DataTable getdataorder()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT tpo.[kode_order]
      ,tpk.[nama_klien]
      ,tpo.[layanan]
      ,tpo.[deskripsi]
      ,tpo.[tgl_order]
  FROM [db_si_notaris].[dbo].[tb_order] tpo inner join [db_si_notaris].[dbo].[tb_klien] tpk on tpo.kode_klien=tpk.kode_klien
";
            DA = new common();
            DA.openkoneksi();
            dt = DA.executequery(query);
            DA.closekoneksi();

            return dt;

        }

        public DataTable getdataorder(string id)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT [kode_order]
      ,[kode_klien]
      ,[kode_layanan]
      ,[kode_officer]
      ,[layanan]
      ,[deskripsi]
      ,[no_akta]
      ,[no_berkas]
      ,[sifat_akta]
      ,[status]
      ,[tgl_order]
      ,[biaya]
      ,[catatan]
  FROM [db_si_notaris].[dbo].[tb_order]
  WHERE [kode_order] = @kode_order";
            DA = new common();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@kode_order", id));
            DA.openkoneksi();
            dt = DA.executequery(query, param);
            DA.closekoneksi();

            return dt;

        }

        public bool Insertdataorder(string kodeO, string kodek, string kodel, string kodeof, string layanan, string deskripsi, string noakta, string nobrekas, string sifatakta, string status, string biaya, string catatan)
        {
            try
            {
                DA = new common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_order", kodeO));
                param.Add(new SqlParameter("@kode_officer", kodeof));
                param.Add(new SqlParameter("@layanan", layanan));
                param.Add(new SqlParameter("@kode_layanan", kodel));
                param.Add(new SqlParameter("@kode_klien", kodek));
                param.Add(new SqlParameter("@deskripsi", deskripsi));
                param.Add(new SqlParameter("@no_akta", noakta));
                param.Add(new SqlParameter("@no_berkas", nobrekas));
                param.Add(new SqlParameter("@sifat_akta", sifatakta));
                param.Add(new SqlParameter("@status", status));
                param.Add(new SqlParameter("@biaya", biaya));
                param.Add(new SqlParameter("@catatan", catatan));
                DA.openkoneksi();
                DA.executenonquery(@"INSERT INTO [db_si_notaris].[dbo].[tb_order]
           ([kode_order]
           ,[kode_klien]
           ,[kode_layanan]
           ,[kode_officer]
           ,[layanan]
           ,[deskripsi]
           ,[no_akta]
           ,[no_berkas]
           ,[sifat_akta]
           ,[status]
           ,[tgl_order]
           ,[biaya]
           ,[catatan])
     VALUES
           (@kode_order
           ,@kode_klien
           ,@kode_layanan
           ,@kode_officer
           ,@layanan
           ,@deskripsi
           ,@no_akta
           ,@no_berkas
           ,@sifat_akta
           ,@status
           ,GetDate()
           ,@biaya
           ,@catatan)", param);
                DA.closekoneksi();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Updatedataorder(string kodeO, string kodek, string kodel, string kodeof, string layanan, string deskripsi, string noakta, string nobrekas, string sifatakta, string status, string biaya, string catatan)
        {
            try
            {
                DA = new common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_order", kodeO));
                param.Add(new SqlParameter("@kode_officer", kodeof));
                param.Add(new SqlParameter("@layanan", layanan));
                param.Add(new SqlParameter("@kode_layanan", kodel));
                param.Add(new SqlParameter("@kode_klien", kodek));
                param.Add(new SqlParameter("@deskripsi", deskripsi));
                param.Add(new SqlParameter("@no_akta", noakta));
                param.Add(new SqlParameter("@no_berkas", nobrekas));
                param.Add(new SqlParameter("@sifat_akta", sifatakta));
                param.Add(new SqlParameter("@status", status));
                param.Add(new SqlParameter("@biaya", biaya));
                param.Add(new SqlParameter("@catatan", catatan));
                DA.openkoneksi();
                DA.executenonquery(@"UPDATE [db_si_notaris].[dbo].[tb_order]
   SET [kode_order] = @kode_order
      ,[kode_klien] = @kode_klien
      ,[kode_layanan] = @kode_layanan
      ,[kode_officer] = @kode_officer
      ,[layanan] = @layanan
      ,[deskripsi] = @deskripsi
      ,[no_akta] = @no_akta
      ,[no_berkas] = @no_berkas
      ,[sifat_akta] = @sifat_akta
      ,[status] = @status
      ,[biaya] = @biaya
      ,[catatan] = @catatan
 WHERE [kode_order]= @kode_order", param);
                DA.closekoneksi();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Deletedataorder(string p)
        {
            try
            {
                DA = new common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_order", p));
                DA.openkoneksi();
                DA.executenonquery("DELETE FROM [dbo].[tb_order] WHERE [kode_order] = @kode_order", param);
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
