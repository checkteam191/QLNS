using QuanLyNhanSu.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu.GUI
{
    public partial class FrmThongTinDang : Form
    {
        BindingSource list = new BindingSource();
        public FrmThongTinDang()
        {
            InitializeComponent();
            dgrThongTinDang.DataSource = list;
            dtpNgayKetNap.DateTime = DateTime.Now;
            LoadDang();
            LoadcboNhanVien();
            AddDangBinding();
        }
        void LoadDang()
        {
            list.DataSource = DangDAO.LoadDang();
        }
        void LoadcboNhanVien()
        {
            cboNhanVien.DataSource = NhanVienDAO.LoadCboNhanVien();
            cboNhanVien.DisplayMember = "HOTEN";
            cboNhanVien.ValueMember = "NHANVIENID";
        }
        void AddDangBinding()
        {
            dtpNgayKetNap.DataBindings.Add(new Binding("DateTime", dgrThongTinDang.DataSource, "NGAYKETNAP", true, DataSourceUpdateMode.Never));
            dtpNgayRaKhoiDang.DataBindings.Add(new Binding("DateTime", dgrThongTinDang.DataSource, "NGAYRAKHOIDANG", true, DataSourceUpdateMode.Never));
            cboNhanVien.DataBindings.Add(new Binding("SelectedValue", dgrThongTinDang.DataSource, "NHANVIENID", true, DataSourceUpdateMode.Never));
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int idnv = (int)cboNhanVien.SelectedValue;
                DateTime ngayketnap = dtpNgayKetNap.DateTime;
                DateTime ngayroikhoi = dtpNgayRaKhoiDang.DateTime;
                if (DangDAO.InsertDang(idnv, ngayketnap, ngayroikhoi) == 1)
                    MessageBox.Show("thành công");
                else
                    MessageBox.Show("thất bại");
                LoadDang();
            }
            catch
            {
                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int iddang = Convert.ToInt32(grvThongTinDang.GetFocusedDataRow()["THONGTINDANGID"].ToString());
                int idnv = (int)cboNhanVien.SelectedValue;
                DateTime ngayketnap = dtpNgayKetNap.DateTime;
                DateTime ngayroikhoi = dtpNgayRaKhoiDang.DateTime;
                if (DangDAO.UpdateDang(iddang, idnv, ngayketnap, ngayroikhoi) == 1)
                    MessageBox.Show("thành công");
                else
                    MessageBox.Show("thất bại");
                LoadDang();
            }
            catch
            {
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int iddang = Convert.ToInt32(grvThongTinDang.GetFocusedDataRow()["THONGTINDANGID"].ToString());
                if (DangDAO.DeleteDang(iddang) == 1)
                    MessageBox.Show("thành công");
                else
                    MessageBox.Show("thất bại");
                LoadDang();
            }
            catch
            {
                return;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
