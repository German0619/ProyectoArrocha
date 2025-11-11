using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using ProyectoArrocha;

namespace ProyectoArrocha
{
    public partial class MetodoPago : Form
    {
        private int IdUsuario;
        private int IdCarrito;
        private string Nombre;
        public string Correo;

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
            if (string.IsNullOrEmpty(tbNombre.Text) ||
                string.IsNullOrEmpty(tbDireccion.Text) ||
                cbMetodoPago.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection conn = DataBase.GetConnection())
            {
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    //act datos del usuario
                    string queryActualizar = @" UPDATE Usuarios SET Nombre = @Nombre, Direccion = @Direccion, MetodoPago = @MetodoPago WHERE IdUsuario = @IdUsuario";
                    using (MySqlCommand cmd = new MySqlCommand(queryActualizar, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", tbNombre.Text);
                        cmd.Parameters.AddWithValue("@Direccion", tbDireccion.Text);
                        cmd.Parameters.AddWithValue("@MetodoPago", cbMetodoPago.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                        cmd.ExecuteNonQuery();
                    }

                    //verifica stock
                    string verificarStock = @"SELECT p.Nombre FROM Productos p INNER JOIN DetallesCarrito dc ON p.IdProducto = dc.IdProducto WHERE dc.IdCarrito = @IdCarrito AND p.Stock < dc.Cantidad";
                    using (MySqlCommand cmdVerif = new MySqlCommand(verificarStock, conn, transaction))
                    {
                        cmdVerif.Parameters.AddWithValue("@IdCarrito", IdCarrito);
                        using (var reader = cmdVerif.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                string productosFaltantes = "";
                                while (reader.Read())
                                    productosFaltantes += "- " + reader["Nombre"].ToString() + "\n";

                                reader.Close();
                                transaction.Rollback();
                                MessageBox.Show("No hay stock suficiente para los siguientes productos:\n" + productosFaltantes, "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    //descuenta stock y actualiza estado carrito
                    string queryDescontarStock = @" UPDATE Productos p INNER JOIN DetallesCarrito dc ON p.IdProducto = dc.IdProducto SET p.Stock = GREATEST(p.Stock - dc.Cantidad, 0) WHERE dc.IdCarrito = @IdCarrito";
                    using (MySqlCommand cmdStock = new MySqlCommand(queryDescontarStock, conn, transaction))
                    {
                        cmdStock.Parameters.AddWithValue("@IdCarrito", IdCarrito);
                        cmdStock.ExecuteNonQuery();
                    }

                    //actualiza estado carrito a pagado
                    string queryCarrito = "UPDATE Carritos SET Estado = 'Pagado' WHERE IdCarrito = @IdCarrito";
                    using (MySqlCommand cmdCarrito = new MySqlCommand(queryCarrito, conn, transaction))
                    {
                        cmdCarrito.Parameters.AddWithValue("@IdCarrito", IdCarrito);
                        cmdCarrito.ExecuteNonQuery();
                    }

                    // crea un nuevo carrito activo para el usuario
                    string nuevoCarrito = "INSERT INTO Carritos (IdUsuario, Estado) VALUES (@IdUsuario, 'Activo')";
                    using (MySqlCommand cmdNuevo = new MySqlCommand(nuevoCarrito, conn, transaction))
                    {
                        cmdNuevo.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                        cmdNuevo.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    MessageBox.Show("✅ Pago realizado con éxito. El stock ha sido actualizado.", "Transacción completada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Carrito carrito = new Carrito(IdUsuario, Nombre);
                    carrito.Owner = this;

                    carrito.Correo = this.Correo;

                    carrito.Show();
                    this.Close();

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error al procesar el pago: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
