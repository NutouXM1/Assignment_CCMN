using BT_lớn.models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace BT_lớn.repositories
{
    public class Nguoithue_repo
    {
        private readonly string conn = "Data Source=DESKTOP-NGP0K2Q\\SQLEXPRESS;Initial Catalog=\"apartment management\";Integrated Security=True;Trust Server Certificate=True";
        public List<models_nguoithue> GetNguoithues()
        {
            var nguoithue = new List<models_nguoithue>();
            try
            {
                using(SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    string query = "SELECT * FROM nguoithue";
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                var nguoithue1 = new models_nguoithue();
                                nguoithue1.ID = reader["ID"].ToString();
                                nguoithue1.hoten = reader["hoten"].ToString();
                                nguoithue1.gioitinh = reader["gioitinh"].ToString();
                                nguoithue1.sDT = reader["sDT"].ToString();
                                nguoithue1.email = reader["email"].ToString();
                                nguoithue1.phuongtien = reader["phuongtien"].ToString();
                                nguoithue.Add(nguoithue1);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return nguoithue;
        }
        public void AddNguoithue(models_nguoithue nguoithue)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    string query = "INSERT INTO nguoithue (ID, hoten, gioitinh, sDT, email, phuongtien) VALUES (@ID, @hoten, @gioitinh, @sDT, @email, @phuongtien)";
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", nguoithue.ID);
                        command.Parameters.AddWithValue("@hoten", nguoithue.hoten);
                        command.Parameters.AddWithValue("@gioitinh", nguoithue.gioitinh);
                        command.Parameters.AddWithValue("@sDT", nguoithue.sDT);
                        command.Parameters.AddWithValue("@email", nguoithue.email);
                        command.Parameters.AddWithValue("@phuongtien", nguoithue.phuongtien);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void UpdateNguoithue(models_nguoithue nguoithue)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    string query = "UPDATE nguoithue SET hoten = @hoten, gioitinh = @gioitinh, sDT = @sDT, email = @email, phuongtien = @phuongtien WHERE ID = @ID";
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", nguoithue.ID);
                        command.Parameters.AddWithValue("@hoten", nguoithue.hoten);
                        command.Parameters.AddWithValue("@gioitinh", nguoithue.gioitinh);
                        command.Parameters.AddWithValue("@sDT", nguoithue.sDT);
                        command.Parameters.AddWithValue("@email", nguoithue.email);
                        command.Parameters.AddWithValue("@phuongtien", nguoithue.phuongtien);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
         public void DeleteNguoithue(string ID)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    string query = "DELETE FROM nguoithue WHERE ID = @ID";
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", ID);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
