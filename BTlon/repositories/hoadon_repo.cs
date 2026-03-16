using BT_lớn.models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BT_lớn.repositories
{
    public class hoadon_repo
    {
        private readonly string conn = "Data Source=DESKTOP-NGP0K2Q\\SQLEXPRESS;Initial Catalog=\"apartment management\";Integrated Security=True;Trust Server Certificate=True";
        public List<models_hoadon> GetHoadons()
        {
            var hoadon = new List<models_hoadon>();
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    string query = "SELECT * FROM hoadon";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var hoadon1 = new models_hoadon();
                                hoadon1.ID = reader["ID"].ToString();
                                hoadon1.hoTen = reader["hoTen"].ToString();
                                hoadon1.soPhong = reader["soPhong"].ToString();
                                hoadon1.soDien = Convert.ToInt32(reader["soDien"]);
                                hoadon1.soNuoc = Convert.ToInt32(reader["soNuoc"]);
                                hoadon1.soPhuongTien = Convert.ToInt32(reader["soPhuongTien"]);
                                hoadon1.ngayTao = Convert.ToDateTime(reader["ngayTao"]);
                                hoadon1.tongTien = Convert.ToInt32(reader["tongTien"]);
                                hoadon.Add(hoadon1);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return hoadon;
        }
        public void AddHoadon(models_hoadon hoadon)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    string query = "INSERT INTO hoadon (ID, hoTen, soPhong, soDien, soNuoc, soPhuongTien, ngayTao, tongTien) VALUES (@ID, @hoTen, @soPhong, @soDien, @soNuoc, @soPhuongTien, @ngayTao, @tongTien)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", hoadon.ID);
                        command.Parameters.AddWithValue("@hoTen", hoadon.hoTen);
                        command.Parameters.AddWithValue("@soPhong", hoadon.soPhong);
                        command.Parameters.AddWithValue("@soDien", hoadon.soDien);
                        command.Parameters.AddWithValue("@soNuoc", hoadon.soNuoc);
                        command.Parameters.AddWithValue("@soPhuongTien", hoadon.soPhuongTien);
                        command.Parameters.AddWithValue("@ngayTao", hoadon.ngayTao);
                        command.Parameters.AddWithValue("@tongTien", hoadon.tongTien);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
