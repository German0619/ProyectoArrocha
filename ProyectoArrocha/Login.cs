using MySql.Data.MySqlClient;
using ProyectoArrocha;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuProyecto;

namespace ProyectoArrocha
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btis_Click(object sender, EventArgs e)
        {
            string Correo = tbcorreo.Text;
            string Contrasena = tbcont.Text;

            if (Correo == "" || Contrasena == "")
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (MySqlConnection conn = DataBase.GetConnection())
            {
                conn.Open();
                string query = "SELECT Nombre, Correo FROM Usuarios WHERE Correo = @Correo AND Contrasena = @Contrasena";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Correo", Correo);
                cmd.Parameters.AddWithValue("@Contrasena", Contrasena);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string Nombre = reader["Nombre"].ToString();
                    string Email = reader["Correo"].ToString();

                    Perfil perfil = new Perfil(Nombre, Email);
                    perfil.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Correo o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void lbreg_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.Show();
            this.Hide();
        }
        private void pblogo_Click(object sender, EventArgs e)
        {
            FormProductos frm = new FormProductos();
            frm.Show();
            this.Hide();

        }
        private void lblogo_Click(object sender, EventArgs e)
        {
            FormProductos frm = new FormProductos();
            frm.Show();
            this.Hide();

        }
    }
}