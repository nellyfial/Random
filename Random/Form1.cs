using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Random
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=5lgo8sik\\SQLEXPRESS;Initial Catalog=StudentSystem;Integrated Security=True;TrustServerCertificate=True";
            string query = "SELECT TOP 5 stu_id, name, age FROM stu";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    bool hasData = false;

                    while (reader.Read())
                    {
                        hasData = true;

                        string id = reader["stu_id"].ToString();
                        string name = reader["name"].ToString();
                        string age = reader["age"].ToString();

                        //show individual MessageBox for each student
                        MessageBox.Show($"ID: {id}\nName: {name}\nAge: {age}", "Student Information System");
                    }

                    reader.Close();

                    if (!hasData)
                    {
                        MessageBox.Show("No data found!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}
