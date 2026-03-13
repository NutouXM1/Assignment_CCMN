using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BT_lớn.repositories
{
    public class phong_repo
    {
        private readonly string conn = "Data Source=DESKTOP-NGP0K2Q\\SQLEXPRESS;Initial Catalog=\"apartment management\";Integrated Security=True;Trust Server Certificate=True";

        public List<models.models_phong> GetPhongs()
        {
            var phongs = new List<models.models_phong>();
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    string query = "SELECT * FROM phong";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var phong = new models.models_phong();
                                phong.soPhong = reader["soPhong"].ToString();
                                phong.trangThai = reader["trangThai"].ToString();
                                phongs.Add(phong);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return phongs;
        }
        public void AddPhong(models.models_phong phong)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    string query = "INSERT INTO phong (soPhong, trangThai) VALUES (@soPhong, @trangThai)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@soPhong", phong.soPhong);
                        command.Parameters.AddWithValue("@trangThai", phong.trangThai);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void UpdatePhong(models.models_phong phong)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    string query = "UPDATE phong SET trangThai = @trangThai WHERE soPhong = @soPhong";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@soPhong", phong.soPhong);
                        command.Parameters.AddWithValue("@trangThai", phong.trangThai);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void DeletePhong(string soPhong)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    string query = "DELETE FROM phong WHERE soPhong = @soPhong";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@soPhong", soPhong);
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
