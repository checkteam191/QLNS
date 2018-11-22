using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.DAO
{
    public class DangDAO
    {
        public static DataTable LoadDang()
        {
            string query = "SELECT THONGTINDANGID, NGAYKETNAP, NGAYRAKHOIDANG, T.NHANVIENID, HOTEN FROM THONGTINDANG T, NHANVIEN N WHERE N.NHANVIENID = T.NHANVIENID";

            return SqlServerHelper.ExecuteQuery(query);
        }
        public static int InsertDang(int idnv, DateTime ngayketnap, DateTime ngayroikhoi)
        {
            string query = "INSERTTHONGTINDANG @IDNV , @NGAYKETNAP , @NGAYROIKHOI ";

            return SqlServerHelper.ExecuteNonQuery(query, new object[] { idnv, ngayketnap, ngayroikhoi });
        }
        public static int UpdateDang(int iddang, int idnv, DateTime ngayketnap, DateTime ngayroikhoi)
        {
            string query = "UPDATETHONGTINDANG @THONGTINDANGID , @IDNV , @NGAYKETNAP , @NGAYROIKHOI ";

            return SqlServerHelper.ExecuteNonQuery(query, new object[] { iddang, idnv, ngayketnap, ngayroikhoi });
        }
        public static int DeleteDang(int iddang)
        {
            string query = "DELETETHONGTINDANG @THONGTINDANGID ";

            try
            {
                return SqlServerHelper.ExecuteNonQuery(query, new object[] { iddang });
            }
            catch
            {
                return 0;
            }
        }
    }
}
