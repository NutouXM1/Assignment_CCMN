using BT_lớn.repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BT_lớn
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            readHoaDon();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void readHoaDon()
        {
            DataTable hoadonTable = new DataTable();
            hoadonTable.Columns.Add("Số CCCD");
            hoadonTable.Columns.Add("Họ tên");
            hoadonTable.Columns.Add("Số phòng");
            hoadonTable.Columns.Add("Số điện");
            hoadonTable.Columns.Add("Số nước");
            hoadonTable.Columns.Add("Số phương tiện");
            hoadonTable.Columns.Add("Ngày tạo");
            hoadonTable.Columns.Add("Tổng tiền");
            var repo = new hoadon_repo();
            var hoadons = repo.GetHoadons();
            foreach (var hoadon in hoadons)
            {
                hoadonTable.Rows.Add(hoadon.ID, hoadon.hoTen, hoadon.soPhong, hoadon.soDien, hoadon.soNuoc, hoadon.soPhuongTien, hoadon.ngayTao, hoadon.tongTien);
            }
            dataGridView1.DataSource = hoadonTable;
        }
    }
}
