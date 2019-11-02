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
    public class controllerefiiing
    {
        common DA;
        public DataTable getdataefiling()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT [kode_efiling]
      ,[jenis]
      ,[info]
      ,[nama_file]
      ,[ukuran]
      ,[catatan]
      ,[file]
      ,[tgl_upload]
  FROM [db_si_notaris].[dbo].[tb_e_filing]";
            DA = new common();
            DA.openkoneksi();
            dt = DA.executequery(query);
            DA.closekoneksi();

            return dt;

        }

   
        public DataTable getnamaklien()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT [kode_order]    
        ,tpo.[kode_klien]
	    , tpk.nama_klien
        FROM [db_si_notaris].[dbo].[tb_order] tpo inner join [db_si_notaris].[dbo].[tb_klien] tpk on tpo.kode_klien=tpo.kode_klien";
            DA = new common();
            DA.openkoneksi();
            dt = DA.executequery(query);
            DA.closekoneksi();

            return dt;

        }
        public DataTable getdataefiling(string id)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT [kode_efiling]
      ,[jenis]
      ,[info]
      ,[nama_file]
      ,[ukuran]
      ,[catatan]
      ,[file]
      ,[tgl_upload]
  FROM [db_si_notaris].[dbo].[tb_e_filing]
  WHERE [kode_efiling] = @kode_efiling
";
            DA = new common();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@kode_efiling", id));

            DA.openkoneksi();
            dt = DA.executequery(query, param);
            DA.closekoneksi();

            return dt;

        }

        public bool Insertdataefiling(string kode, string jenis, string info,string nm_file,int ukuran, string catatan, byte[] file, string tgl)
        {
            try
            {
                DA = new common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_efiling", kode));
                param.Add(new SqlParameter("@jenis", jenis));
                param.Add(new SqlParameter("@info", info));
                param.Add(new SqlParameter("@nama_file", nm_file));
                param.Add(new SqlParameter("@ukuran", ukuran));
                param.Add(new SqlParameter("@catatan", catatan));
                param.Add(new SqlParameter("@file", file));
                param.Add(new SqlParameter("@tgl_upload", tgl));
                DA.openkoneksi();
                DA.executenonquery(@"INSERT INTO [db_si_notaris].[dbo].[tb_e_filing]
           ([kode_efiling]
           ,[jenis]
           ,[info]
           ,[nama_file]
           ,[ukuran]
           ,[catatan]
           ,[file]
           ,[tgl_upload])
     VALUES
           (@kode_efiling
           ,@jenis
           ,@info
           ,@nama_file
           ,@ukuran
           ,@catatan
           ,@file
           ,@tgl_upload)", param);
                DA.closekoneksi();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Updatedataefiling(string kode, string nama, string keterangan)
        {
            try
            {
                DA = new common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_layanan", kode));
                param.Add(new SqlParameter("@nama_layanan", nama));
                param.Add(new SqlParameter("@keterangan", keterangan));
                DA.openkoneksi();
                DA.executenonquery(@"UPDATE [db_si_notaris].[dbo].[tb_e_filing]
   SET [kode_efiling] = @kode_efiling
      ,[jenis] = @jenis
      ,[info] = @info
      ,[nama_file] = @nama_file
      ,[ukuran] = @ukuran
      ,[catatan] = @catatan
      ,[file] = @file
      ,[tgl_upload] = @tgl_upload
 WHERE [kode_efiling]= @kode_efiling", param);
                DA.closekoneksi();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Deletedataefiling(string p)
        {
            try
            {
                DA = new common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_efiling", p));
                DA.openkoneksi();
                DA.executenonquery("DELETE FROM [db_si_notaris].[dbo].[tb_e_filing] WHERE [kode_efiling]= @kode_efiling", param);
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
