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
    public class controllerlayanan
    {
        common DA;
        public DataTable getdatalayanan()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT [kode_layanan]
      ,[nama_layanan]
      ,[keterangan]
  FROM [db_si_notaris].[dbo].[tb_layanan]
";
            DA = new common();
            DA.openkoneksi();
            dt = DA.executequery(query);
            DA.closekoneksi();

            return dt;

        }

        public DataTable getdatalayanan(string id)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT [kode_layanan]
      ,[nama_layanan]
      ,[keterangan]
  FROM [db_si_notaris].[dbo].[tb_layanan]
  WHERE [kode_layanan] = @kode_layanan 
";
            DA = new common();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@kode_layanan", id));

            DA.openkoneksi();
            dt = DA.executequery(query, param);
            DA.closekoneksi();

            return dt;

        }

        public bool Insertdatalayanan(string kode, string nama, string keterangan)
        {
            try
            {
                DA = new common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_layanan", kode));
                param.Add(new SqlParameter("@nama_layanan", nama));
                param.Add(new SqlParameter("@keterangan", keterangan));
                DA.openkoneksi();
                DA.executenonquery(@"INSERT INTO [db_si_notaris].[dbo].[tb_layanan]
           ([kode_layanan]
           ,[nama_layanan]
           ,[keterangan])
     VALUES
           (@kode_layanan
           ,@nama_layanan
           ,@keterangan)", param);
                DA.closekoneksi();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Updatedatalayanan(string kode, string nama, string keterangan)
        {
            try
            {
                DA = new common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_layanan", kode));
                param.Add(new SqlParameter("@nama_layanan", nama));
                param.Add(new SqlParameter("@keterangan", keterangan));
                DA.openkoneksi();
                DA.executenonquery(@"UPDATE [db_si_notaris].[dbo].[tb_layanan]
   SET [kode_layanan] = @kode_layanan
      ,[nama_layanan] = @nama_layanan
      ,[keterangan] = @keterangan
 WHERE [kode_layanan]= @kode_layanan", param);
                DA.closekoneksi();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Deletedatalayanan(string p)
        {
            try
            {
                DA = new common();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@kode_layanan", p));
                DA.openkoneksi();
                DA.executenonquery("DELETE FROM [dbo].[tb_layanan] WHERE [kode_layanan] = @kode_layanan", param);
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
