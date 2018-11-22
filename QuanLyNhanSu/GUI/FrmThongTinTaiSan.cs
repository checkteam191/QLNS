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
    public partial class FrmThongTinTaiSan : Form
    {
        BindingSource list = new BindingSource();
        public FrmThongTinTaiSan()
        {
            InitializeComponent();
            dgrTaiSan.DataSource = list;
            LoadcboNhanVien();
            AddTaiSanBinding();
        }
        void LoadTaiSan(int idnv)
        {
            list.DataSource = TaiSanDAO.LoadTaiSan(idnv);
        }
        void LoadcboNhanVien()
        {
            cboNhanVien.DataSource = NhanVienDAO.LoadCboNhanVien();
            cboNhanVien.DisplayMember = "HOTEN";
            cboNhanVien.ValueMember = "NHANVIENID";
        }
        void AddTaiSanBinding()
        {
            txbTenTaiSan.DataBindings.Add(new Binding("Text", dgrTaiSan.DataSource, "TEN", true, DataSourceUpdateMode.Never));
            txbGhiChu.DataBindings.Add(new Binding("Text", dgrTaiSan.DataSource, "GHICHU", true, DataSourceUpdateMode.Never));
        }

        private void cboNhanVien_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int idnv = (int)cboNhanVien.SelectedValue;
                LoadTaiSan(idnv);
            }
            catch
            {
                return;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int idnv = (int)cboNhanVien.SelectedValue;
                string ten = txbTenTaiSan.Text;
                string ghichu = txbGhiChu.Text;
                if (TaiSanDAO.InsertTaiSan( idnv, ten, ghichu) == 1)
                    MessageBox.Show("thành công");
                else
                    MessageBox.Show("thất bại");
                LoadTaiSan(idnv);
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
                int idtaisan = Convert.ToInt32(grvTaiSan.GetFocusedDataRow()["TAISANID"].ToString());
                int idnv = (int)cboNhanVien.SelectedValue;
                string ten = txbTenTaiSan.Text;
                string ghichu = txbGhiChu.Text;
                if (TaiSanDAO.UpdateTaiSan(idtaisan, idnv, ten, ghichu) == 1)
                    MessageBox.Show("thành công");
                else
                    MessageBox.Show("thất bại");
                LoadTaiSan(idnv);
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
                int idtaisan = Convert.ToInt32(grvTaiSan.GetFocusedDataRow()["TAISANID"].ToString());
                int idnv = (int)cboNhanVien.SelectedValue;           
                if (TaiSanDAO.DeleteTaiSan(idtaisan) == 1)
                    MessageBox.Show("thành công");
                else
                    MessageBox.Show("thất bại");
                LoadTaiSan(idnv);
            }
            catch
            {
                return;
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel |*.xls";
            saveFileDialog1.Title = "Save an Excel File";
            saveFileDialog1.ShowDialog();

            string FileName = saveFileDialog1.FileName.ToString();
            try
            {
                dgrTaiSan.ExportToXls(FileName);
                MessageBox.Show("Xuất file excel thành công");
            }
            catch
            {
                MessageBox.Show("Vui lòng đóng file cần ghi lại để quá trình ghi thành công");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
