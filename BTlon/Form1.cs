using BT_lớn.models;
using BT_lớn.repositories;
using System.ComponentModel;
using System.Data;

namespace BT_lớn
{
    public partial class Form1 : Form
    {
        string connstring = "Data Source=DESKTOP-NGP0K2Q\\SQLEXPRESS;Initial Catalog=\"apartment management\";Integrated Security=True;Trust Server Certificate=True";
        public Form1()
        {
            InitializeComponent();
            readNguoiThue();
            readPhong();
            readID_NguoiThue();
            readSoPhong_combobox();
            readHopDong();
        }

        private void ngườiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            hopdong_repo repo = new hopdong_repo();
            repo.DeleteHopdong(comboBox2.Text);
            readHopDong();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            phong_repo repo = new phong_repo();
            repo.DeletePhong(comboBox4.Text);
            readPhong();
            comboBox4.Text = "";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            models_nguoithue nguoithue = new models_nguoithue();
            Nguoithue_repo repo = new Nguoithue_repo();
            nguoithue.hoten = textBox1.Text;
            if (radioButton1.Checked)
            {
                nguoithue.gioitinh = "Nam";
            }
            else if (radioButton2.Checked)
            {
                nguoithue.gioitinh = "Nữ";
            }
            nguoithue.sDT = textBox2.Text;
            nguoithue.ID = textBox4.Text;
            nguoithue.email = textBox3.Text;
            nguoithue.phuongtien = comboBox1.Text;
            repo.AddNguoithue(nguoithue);
            readNguoiThue();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            models_nguoithue nguoithue = new models_nguoithue();
            Nguoithue_repo repo = new Nguoithue_repo();
            nguoithue.hoten = textBox1.Text;
            if (radioButton1.Checked)
            {
                nguoithue.gioitinh = "Nam";
            }
            else if (radioButton2.Checked)
            {
                nguoithue.gioitinh = "Nữ";
            }
            nguoithue.sDT = textBox2.Text;
            nguoithue.ID = textBox4.Text;
            nguoithue.email = textBox3.Text;
            nguoithue.phuongtien = comboBox1.Text;
            repo.UpdateNguoithue(nguoithue);
            readNguoiThue();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Nguoithue_repo repo = new Nguoithue_repo();
            repo.DeleteNguoithue(textBox4.Text);
            readNguoiThue();
        }

        private void readNguoiThue()
        {
            DataTable nguoiTable = new DataTable();
            nguoiTable.Columns.Add("ID");
            nguoiTable.Columns.Add("Họ tên");
            nguoiTable.Columns.Add("Giới tính");
            nguoiTable.Columns.Add("SĐT");
            nguoiTable.Columns.Add("Email");
            nguoiTable.Columns.Add("Phương tiện");

            var repo = new Nguoithue_repo();
            var nguoithues = repo.GetNguoithues();
            foreach (var nguoithue in nguoithues)
            {
                nguoiTable.Rows.Add(nguoithue.ID, nguoithue.hoten, nguoithue.gioitinh, nguoithue.sDT, nguoithue.email, nguoithue.phuongtien);
            }
            dataGridView1.DataSource = nguoiTable;
        }
        private void readPhong()
        {
            DataTable phongTable = new DataTable();
            phongTable.Columns.Add("Số phòng");
            phongTable.Columns.Add("Trạng thái");
            var repo = new phong_repo();
            var phongs = repo.GetPhongs();
            foreach (var phong in phongs)
            {
                phongTable.Rows.Add(phong.soPhong, phong.trangThai);
            }
            dataGridView3.DataSource = phongTable;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            models_phong phong = new models_phong();
            phong_repo repo = new phong_repo();
            phong.soPhong = comboBox4.Text;
            if (radioButton3.Checked)
            {
                phong.trangThai = "Đã thuê";
            }
            else if (radioButton4.Checked)
            {
                phong.trangThai = "Chưa thuê";
            }
            repo.AddPhong(phong);
            readPhong();
            comboBox4.Text = "";
            readSoPhong_combobox();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void readID_NguoiThue()
        {
            DataTable nguoiTable = new DataTable();
            nguoiTable.Columns.Add("ID");
            var repo = new Nguoithue_repo();
            var nguoithues = repo.GetNguoithues();
            foreach (var nguoithue in nguoithues)
            {
                nguoiTable.Rows.Add(nguoithue.ID);
            }
            comboBox2.DataSource = nguoiTable;
            comboBox2.DisplayMember = "ID";
            comboBox8.DataSource = nguoiTable;
            comboBox8.DisplayMember = "ID";
        }

        private void readSoPhong_combobox()
        {
            DataTable phongTable = new DataTable();
            phongTable.Columns.Add("Số phòng");
            var repo = new phong_repo();
            var phongs = repo.GetPhongs();
            foreach (var phong in phongs)
            {
                phongTable.Rows.Add(phong.soPhong);
            }
            comboBox3.DataSource = phongTable;
            comboBox3.DisplayMember = "Số phòng";
            comboBox4.DataSource = phongTable;
            comboBox4.DisplayMember = "Số phòng";
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            models_phong phong = new models_phong();
            phong_repo repo = new phong_repo();
            phong.soPhong = comboBox4.Text;
            if (radioButton3.Checked)
            {
                phong.trangThai = "Đã thuê";
            }
            else if (radioButton4.Checked)
            {
                phong.trangThai = "Chưa thuê";
            }
            repo.UpdatePhong(phong);
            readPhong();
        }

        private void comboBox2_Leave(object sender, EventArgs e)
        {

        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            var repo = new Nguoithue_repo();
            var nguoithues = repo.GetNguoithues();
            foreach (var nguoithue in nguoithues)
            {
                if (nguoithue.ID == comboBox8.Text)
                {
                    textBox11.Text = nguoithue.hoten;
                    textBox6.Text = nguoithue.phuongtien;
                }
            }
        }

        private void readHopDong()
        {
            DataTable hopdongTable = new DataTable();
            hopdongTable.Columns.Add("Số CCCD");
            hopdongTable.Columns.Add("Họ tên");
            hopdongTable.Columns.Add("Số phòng");
            hopdongTable.Columns.Add("Ngày bắt đầu");
            hopdongTable.Columns.Add("Ngày kết thúc");
            hopdongTable.Columns.Add("Tiền cọc");
            hopdongTable.Columns.Add("Tiền thuê");
            var repo = new hopdong_repo();
            var hopdongs = repo.GetHopdongs();
            foreach (var hopdong in hopdongs)
            {
                hopdongTable.Rows.Add(hopdong.ID, hopdong.hoTen, hopdong.soPhong, hopdong.ngayBatDau, hopdong.ngayKetThuc, hopdong.tienCoc, hopdong.tienThue);
            }
            dataGridView2.DataSource = hopdongTable;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            models_hopdong hopdong = new models_hopdong();
            hopdong_repo repo = new hopdong_repo();
            hopdong.ID = comboBox2.Text;
            hopdong.soPhong = comboBox3.Text;
            hopdong.hoTen = textBox5.Text;
            hopdong.ngayBatDau = dateTimePicker1.Value;
            hopdong.ngayKetThuc = dateTimePicker2.Value;
            hopdong.tienCoc = int.Parse(textBox7.Text);
            hopdong.tienThue = int.Parse(textBox8.Text);
            repo.AddHopdong(hopdong);
            readHopDong();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            models_hopdong hopdong = new models_hopdong();
            hopdong_repo repo = new hopdong_repo();
            hopdong.ID = comboBox2.Text;
            hopdong.soPhong = comboBox3.Text;
            hopdong.hoTen = textBox5.Text;
            hopdong.ngayBatDau = dateTimePicker1.Value;
            hopdong.ngayKetThuc = dateTimePicker2.Value;
            hopdong.tienCoc = int.Parse(textBox7.Text);
            hopdong.tienThue = int.Parse(textBox8.Text);
            repo.UpdateHopdong(hopdong);
            readHopDong();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            comboBox2.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            comboBox3.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView2.CurrentRow.Cells[3].Value);
            dateTimePicker2.Value = Convert.ToDateTime(dataGridView2.CurrentRow.Cells[4].Value);
            textBox8.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            readNguoiThue();
            readPhong();
            readID_NguoiThue();
            readSoPhong_combobox();
            readHopDong();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var repo = new Nguoithue_repo();
            var nguoithues = repo.GetNguoithues();
            foreach (var nguoithue in nguoithues)
            {
                if (nguoithue.ID == comboBox2.Text)
                {
                    textBox5.Text = nguoithue.hoten;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[2].Value.ToString() == "Nam")
            {
                radioButton1.Checked = true;
            }
            else if (dataGridView1.CurrentRow.Cells[2].Value.ToString() == "Nữ")
            {
                radioButton2.Checked = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            models_hoadon hoadon = new models_hoadon();
            hoadon_repo repo = new hoadon_repo();
            hoadon.ID = comboBox8.Text;
            hoadon.hoTen = textBox11.Text;
            hoadon.soPhong = textBox9.Text;
            hoadon.soDien = int.Parse(textBox12.Text);
            hoadon.soNuoc = int.Parse(textBox13.Text);
            hoadon.soPhuongTien = int.Parse(textBox14.Text);
            hoadon.ngayTao = DateTime.Now;
            if (radioButton5.Checked)
            {
                hoadon.tongTien = hoadon.soDien * 2500 + hoadon.soNuoc * 1500 + hoadon.soPhuongTien * 50000 + 250000;
            }
            else if (radioButton6.Checked)
            {
                hoadon.tongTien = hoadon.soDien * 2500 + hoadon.soNuoc * 1500 + hoadon.soPhuongTien * 50000;
            }
            repo.AddHoadon(hoadon);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            var repo = new Nguoithue_repo();
            var repo2 = new hopdong_repo();
            var nguoithues = repo.GetNguoithues();
            var hopdongs = repo2.GetHopdongs();
            foreach (var nguoithue in nguoithues)
            {
                if (nguoithue.ID == comboBox8.Text)
                {
                    textBox11.Text = nguoithue.hoten;
                    textBox6.Text = nguoithue.phuongtien;
                }
            }
            foreach (var hopdong in hopdongs)
            {
                if (hopdong.ID == comboBox8.Text)
                {
                    textBox9.Text = hopdong.soPhong;
                }
            }
        }
    }
}
