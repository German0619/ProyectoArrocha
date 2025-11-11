using MySql.Data.MySqlClient;
using ProyectoArrocha;
using System;
using System.Windows.Forms;
using TuProyecto;

namespace ProyectoArrocha
{
    public partial class Login : Form
    {
        private string Correo;
        private string Nombre;
        public Login()
        {
            InitializeComponent();
        }

        private void btis_Click(object sender, EventArgs e)
        {
            string correo = tbcorreo.Text.Trim();
            string contrasena = tbcont.Text;

            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection conn = DataBase.GetConnection())
            {
                conn.Open();
                string query = "SELECT IdUsuario, Nombre, Correo FROM Usuarios WHERE Correo = @Correo AND Contrasena = @Contrasena";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Correo", correo);
                cmd.Parameters.AddWithValue("@Contrasena", contrasena);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Session.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    Session.Nombre = reader["Nombre"].ToString();
                    Session.Correo = reader["Correo"].ToString();

                    Perfil perfil = new Perfil(Session.Nombre, Session.Correo);
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

        private void pbcar_Click(object sender, EventArgs e)
        {
            if (!Session.IsLogged)
            {
                MessageBox.Show("Por favor, inicie sesión para abrir el carrito.", "Inicio de sesión requerido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login login = new Login();
                login.Show();
                this.Hide();
                return;
            }

            using (MySqlConnection conn = DataBase.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT IdUsuario FROM Usuarios WHERE Correo = @Correo";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Correo", Session.Correo);
                    object result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("No se encontró el usuario o no tiene carrito activo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    int idUsuario = Convert.ToInt32(result);

                    Carrito carrito = new Carrito(idUsuario, Session.Nombre);
                    carrito.Owner = this;
                    carrito.Show();
                    this.Hide();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al abrir el carrito: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}