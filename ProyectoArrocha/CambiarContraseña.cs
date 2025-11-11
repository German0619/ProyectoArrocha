using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using TuProyecto;

namespace ProyectoArrocha
{
    public partial class CambiarContraseña : Form
    {
        private string CorreoUsuario;
        private string Correo;
        private string Nombre;
        public CambiarContraseña(string Correo, String Nombre)
        {
            InitializeComponent();
            lbperf.Text = Nombre.Split(' ')[0];
            CorreoUsuario = Correo;

            this.FormClosed += CambiarContraseña_FormClosed;
        }

        private void btcambiar_Click(object sender, EventArgs e)
        {
            string actual = tbactual.Text;
            string nueva = tbnueva.Text;
            string confirmar = tbconfirmar.Text;

            if (actual == "" || nueva == "" || confirmar == "")
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (nueva != confirmar)
            {
                {
                    MessageBox.Show("Las nuevas contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            using (MySqlConnection conn = DataBase.GetConnection())
            {
                conn.Open();
                string queryVerificar = "SELECT * FROM Usuarios WHERE Correo = @Correo AND Contrasena = @actual";
                MySqlCommand cmdVerificar = new MySqlCommand(queryVerificar, conn);
                cmdVerificar.Parameters.AddWithValue("@Correo", CorreoUsuario);
                cmdVerificar.Parameters.AddWithValue("@actual", actual);
                MySqlDataReader reader = cmdVerificar.ExecuteReader();

                if (!reader.Read())
                {
                    reader.Close();
                    MessageBox.Show("La contraseña actual es incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                reader.Close();

                string queryActualizar = "UPDATE Usuarios SET Contrasena = @nueva WHERE Correo = @Correo";
                MySqlCommand cmdActualizar = new MySqlCommand(queryActualizar, conn);
                cmdActualizar.Parameters.AddWithValue("@nueva", nueva);
                cmdActualizar.Parameters.AddWithValue("@Correo", CorreoUsuario);
                int filasAfectadas = cmdActualizar.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Contraseña actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (this.Owner != null)
                    {
                        this.Owner.Show();
                    }
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Error al actualizar la contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CambiarContraseña_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
            }
        }
        private void btcancel_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
            }
            this.Close();
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
            using (MySqlConnection conn = DataBase.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT IdUsuario FROM Usuarios WHERE Correo = @Correo";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Correo", Correo);
                    object result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("No se encontró el usuario o no tiene carrito activo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    int idUsuario = Convert.ToInt32(result);

                    Carrito carrito = new Carrito(idUsuario, Nombre);
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

        private void pbperf_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Correo) || string.IsNullOrEmpty(Nombre))
            {
                MessageBox.Show("Por favor, inicie sesión para acceder a su perfil.", "Inicio de sesión requerido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login login = new Login();
                login.Show();
                this.Hide();
                return;
            }
            Perfil perfil = new Perfil(Nombre, Correo);
            perfil.Owner = this;
            perfil.Show();
            this.Hide();
        }
    }
}