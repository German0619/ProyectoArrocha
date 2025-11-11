using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ProyectoArrocha
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            pblogo.Click += Pblogo_Click;
            lblogo.Click += Lblogo_Click;
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
                string query = @"SELECT u.IdUsuario, u.Nombre, u.Correo, r.NombreRol
                                 FROM Usuarios u
                                 JOIN Roles r ON u.IdRol = r.IdRol
                                 WHERE u.Correo = @Correo AND u.Contrasena = @Contrasena AND u.Activo = 1";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Correo", correo);
                cmd.Parameters.AddWithValue("@Contrasena", contrasena);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int idUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    string nombre = reader["Nombre"].ToString();
                    string email = reader["Correo"].ToString();
                    string rol = reader["NombreRol"].ToString();

                    // Guardar sesión
                    Session.IniciarSesion(idUsuario, nombre, email);

                    // Abrir formulario según rol
                    if (rol == "Admin")
                    {
                        AdminProductos adminForm = new AdminProductos(nombre, email);
                        adminForm.Show();
                    }
                    else
                    {
                        Perfil perfil = new Perfil(nombre, email);
                        perfil.Show();
                    }

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

        private void pbcar_Click(object sender, EventArgs e)
        {
            if (!Session.IsLoggedIn)
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

        private void Login_Load(object sender, EventArgs e)
        {

        }

        // Handler para hacer click en la imagen del logo desde Login
        private void Pblogo_Click(object sender, EventArgs e)
        {
            // Abre FormProductos; si hay sesión, se pasa para mostrar nombre/correo
            FormProductos frm = new FormProductos();
            frm.Owner = this;
            frm.Show();
            this.Hide();
        }

        // Handler para hacer click en la etiqueta del logo desde Login
        private void Lblogo_Click(object sender, EventArgs e)
        {
            FormProductos frm = new FormProductos();
            frm.Owner = this;
            frm.Show();
            this.Hide();
        }
    }
}