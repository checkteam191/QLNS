using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.DAO
{
    public class TaiSanDAO
    {
        public static DataTable LoadTaiSan(int idnv)
        {
            string query = "select * from taisan where nhanvienid = " + idnv + "";

            return SqlServerHelper.ExecuteQuery(query);
        }
        public static int InsertTaiSan(int idnv, string ten, string ghichu)
        {
            string query = "INSERTTAISAN @IDNV , @TEN , @GHICHU ";

            return SqlServerHelper.ExecuteNonQuery(query, new object[] { idnv, ten, ghichu });
        }
        public static int UpdateTaiSan(int idtaisan, int idnv, string ten, string ghichu)
        {
            string query = "UPDATETAISAN @IDTAISAN , @IDNV , @TEN , @GHICHU ";

            return SqlServerHelper.ExecuteNonQuery(query, new object[] { idtaisan, idnv, ten, ghichu});
        }
        public static int DeleteTaiSan(int idtaisan)
        {
            string query = "DELETETAISAN @IDTAISAN ";

            try
            {
                return SqlServerHelper.ExecuteNonQuery(query, new object[] { idtaisan });
            }
            catch
            {
                return 0;
            }
        }
    }
}
