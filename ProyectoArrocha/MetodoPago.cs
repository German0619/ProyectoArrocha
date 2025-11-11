using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ProyectoArrocha
{
    public partial class MetodoPago : Form
    {
        private int IdUsuario;
        private int IdCarrito;
        private string Nombre;
        private string Correo;

        public MetodoPago(int idUsuario, int idCarrito, string nombre, string correo)
        {
            InitializeComponent();
            IdUsuario = idUsuario;
            IdCarrito = idCarrito;
            Nombre = nombre;
            Correo = correo;
            CargarDatosUsuario();
        }

        private void CargarDatosUsuario()
        {
            using (MySqlConnection conn = DataBase.GetConnection())
            {
                conn.Open();
                string query = "SELECT Nombre, Direccion, MetodoPago FROM Usuarios WHERE IdUsuario = @IdUsuario";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    tbNombre.Text = reader["Nombre"].ToString();
                    tbDireccion.Text = reader["Direccion"] != DBNull.Value ? reader["Direccion"].ToString() : "";

                    string metodo = reader["MetodoPago"] != DBNull.Value ? reader["MetodoPago"].ToString() : "";
                    if (!string.IsNullOrEmpty(metodo))
                    {
                        cbMetodoPago.SelectedItem = metodo;
                    }
                }
                reader.Close();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbNombre.Text) || string.IsNullOrEmpty(tbDireccion.Text) || cbMetodoPago.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection conn = DataBase.GetConnection())
            {
                conn.Open();

                // Guardar/actualizar datos del usuario
                string queryActualizar = @"UPDATE Usuarios SET Nombre = @Nombre, Direccion = @Direccion, MetodoPago = @MetodoPago WHERE IdUsuario = @IdUsuario";
                MySqlCommand cmd = new MySqlCommand(queryActualizar, conn);
                cmd.Parameters.AddWithValue("@Nombre", tbNombre.Text);
                cmd.Parameters.AddWithValue("@Direccion", tbDireccion.Text);
                cmd.Parameters.AddWithValue("@MetodoPago", cbMetodoPago.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                cmd.ExecuteNonQuery();

                // Cambiar el estado del carrito a Pagado
                string queryCarrito = "UPDATE Carritos SET Estado = 'Pagado' WHERE IdCarrito = @IdCarrito";
                MySqlCommand cmdCarrito = new MySqlCommand(queryCarrito, conn);
                cmdCarrito.Parameters.AddWithValue("@IdCarrito", IdCarrito);
                cmdCarrito.ExecuteNonQuery();
            }

            MessageBox.Show("Pago realizado con éxito.", "Transacción completada", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Volver al perfil
            Perfil perfil = new Perfil(Nombre, Correo);
            perfil.Show();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
