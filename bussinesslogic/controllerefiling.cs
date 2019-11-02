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
    public class controllerefiling
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
  FROM [db_si_notaris].[dbo].[tb_e_filing]
";
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

        public bool Insertdataklien(string kode, string nama, string email, string telp, string almt, string kab, string prov, string catatan)
        {
            try
            {
                DA = new common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_klien", kode));
                param.Add(new SqlParameter("@nama_klien", nama));
                param.Add(new SqlParameter("@telp", telp));
                param.Add(new SqlParameter("@email", email));
                param.Add(new SqlParameter("@alamat", almt));
                param.Add(new SqlParameter("@kab_kota", kab));
                param.Add(new SqlParameter("@provinsi", prov));
                param.Add(new SqlParameter("@catatan", catatan));
                DA.openkoneksi();
                DA.executenonquery(@"INSERT INTO [db_si_notaris].[dbo].[tb_klien]
           ([kode_klien]
           ,[nama_klien]
           ,[email]
           ,[telp]
           ,[alamat]
           ,[kab_kota]
           ,[provinsi]
           ,[tgl_daftar]
           ,[catatan])
     VALUES
           (@kode_klien
           ,@nama_klien
           ,@email
           ,@telp
           ,@alamat
           ,@kab_kota
           ,@provinsi
           ,GetDate()
           ,@catatan)", param);
                DA.closekoneksi();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Updatedataklien(string kode, string nama, string email, string telp, string almt, string kab, string prov, string catatan)
        {
            try
            {
                DA = new common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_klien", kode));
                param.Add(new SqlParameter("@nama_klien", nama));
                param.Add(new SqlParameter("@email", email));
                param.Add(new SqlParameter("@telp", telp));
                param.Add(new SqlParameter("@alamat", almt));
                param.Add(new SqlParameter("@kab_kota", kab));
                param.Add(new SqlParameter("@provinsi", prov));
                param.Add(new SqlParameter("@catatan", catatan));
                DA.openkoneksi();
                DA.executenonquery(@"UPDATE [db_si_notaris].[dbo].[tb_klien]
   SET [kode_klien] = @kode_klien
      ,[nama_klien] = @nama_klien
      ,[email] = @email
      ,[telp] = @telp
      ,[alamat] = @alamat
      ,[kab_kota] = @kab_kota
      ,[provinsi] = @provinsi
      ,[catatan] = @catatan
       WHERE [kode_klien] = @kode_klien", param);
                DA.closekoneksi();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Deletedataklien(string p)
        {
            try
            {
                DA = new common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_klien", p));
                DA.openkoneksi();
                DA.executenonquery(@"DELETE FROM [db_si_notaris].[dbo].[tb_klien]
 WHERE [kode_klien]=@kode_klien", param);
                DA.closekoneksi();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataTable getdatapropinsi()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT [id_provinsi]
      ,[nama_provinsi]
  FROM [db_si_notaris].[dbo].[tb_provinsi]
";
            DA = new common();
            DA.openkoneksi();
            dt = DA.executequery(query);
            DA.closekoneksi();

            return dt;

        }

        public DataTable getdatakabupaten(string id)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT [id_kabupaten]
      ,[nama_kabupaten]
      ,[id_provinsi]
  FROM [db_si_notaris].[dbo].[tb_kabupaten]
  WHERE [id_provinsi] = @id_provinsi

";
            DA = new common();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@id_provinsi", id));

            DA.openkoneksi();
            dt = DA.executequery(query, param);
            DA.closekoneksi();

            return dt;

        }
    }
}
