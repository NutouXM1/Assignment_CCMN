using BT_lớn.models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace BT_lớn.repositories
{
    public class hopdong_repo
    {
        private readonly string conn = "Data Source=DESKTOP-NGP0K2Q\\SQLEXPRESS;Initial Catalog=\"apartment management\";Integrated Security=True;Trust Server Certificate=True";

        public List<models_hopdong> GetHopdongs()
        {
            var hopdongs = new List<models_hopdong>();
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    string query = "SELECT * FROM hopdong";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var hopdong1 = new models_hopdong();
                                hopdong1.ID = reader["ID"].ToString();
                                hopdong1.hoTen = reader["hoTen"].ToString();
                                hopdong1.soPhong = reader["soPhong"].ToString();
                                hopdong1.ngayBatDau = Convert.ToDateTime(reader["ngayBatDau"]);
                                hopdong1.ngayKetThuc = Convert.ToDateTime(reader["ngayKetThuc"]);
                                hopdong1.tienCoc = Convert.ToInt32(reader["tienCoc"]);
                                hopdong1.tienThue = Convert.ToInt32(reader["tienThue"]);
                                hopdongs.Add(hopdong1);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return hopdongs;
        }

        public void AddHopdong(models_hopdong hopdong)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    string query = "INSERT INTO hopdong (ID, hoTen, soPhong, ngayBatDau, ngayKetThuc, tienCoc, tienThue) VALUES (@ID, @hoTen, @soPhong, @ngayBatDau, @ngayKetThuc, @tienCoc, @tienThue)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", hopdong.ID);
                        command.Parameters.AddWithValue("@hoTen", hopdong.hoTen);
                        command.Parameters.AddWithValue("@soPhong", hopdong.soPhong);
                        command.Parameters.AddWithValue("@ngayBatDau", hopdong.ngayBatDau);
                        command.Parameters.AddWithValue("@ngayKetThuc", hopdong.ngayKetThuc);
                        command.Parameters.AddWithValue("@tienCoc", hopdong.tienCoc);
                        command.Parameters.AddWithValue("@tienThue", hopdong.tienThue);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateHopdong(models_hopdong hopdong)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    string query = "UPDATE hopdong SET hoTen = @hoTen, soPhong = @soPhong, ngayBatDau = @ngayBatDau, ngayKetThuc = @ngayKetThuc, tienCoc = @tienCoc, tienThue = @tienThue WHERE ID = @ID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", hopdong.ID);
                        command.Parameters.AddWithValue("@hoTen", hopdong.hoTen);
                        command.Parameters.AddWithValue("@soPhong", hopdong.soPhong);
                        command.Parameters.AddWithValue("@ngayBatDau", hopdong.ngayBatDau);
                        command.Parameters.AddWithValue("@ngayKetThuc", hopdong.ngayKetThuc);
                        command.Parameters.AddWithValue("@tienCoc", hopdong.tienCoc);
                        command.Parameters.AddWithValue("@tienThue", hopdong.tienThue);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteHopdong(string ID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    string query = "DELETE FROM hopdong WHERE ID = @ID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", ID);
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
