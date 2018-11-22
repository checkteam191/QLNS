using QuanLyNhanSu.DAO;
using QuanLyNhanSu.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class FrmMain : Form
    {
        public FrmMain(int type)
        {
            InitializeComponent();
            LoadButton(type);
        }
        void LoadButton(int type)
        {
            if(type == 0)
            {
                barBangCap.Enabled = false;
                barBaoHiemXaHoi.Enabled = false;
                barBaoHiemYTe.Enabled = false;
                barDanhMucChucVu.Enabled = false;
                barDanhMucPhongBan.Enabled = false;
                barHopDongLaoDong.Enabled = false;
                barQuanLyNhanVien.Enabled = false;
                barQuaTrinhCongTac.Enabled = false;
                barQuaTrinhHocTap.Enabled = false;
                barThongKeDangVien.Enabled = false;
                barThongKeNhanVienSapNghiHuu.Enabled = false;
                barThongKeSinhNhatTheoThang.Enabled = false;
                barThongKeTheoNhanVien.Enabled = false;
                barThongTinDang.Enabled = false;
                barThongTinGiaDinh.Enabled = false;
                barThongTinKhenThuongKiLuat.Enabled = false;
                barThongTinTaiSan.Enabled = false;
                barUser.Enabled = false;
            }
        }
        
    }
}
