using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;
using ProyectoArrocha;

namespace ProyectoArrocha
{
    public partial class DetalleProducto : Form
    {
        private string nombre;
        private decimal precio;
        private Image imagen;
        public string Correo { get; set; }
        public string Nombre { get; set; }
        private int IdUsuario;
        private int IdProducto;
        public DetalleProducto(string nombre, decimal precio, Image imagen)
        {
            InitializeComponent();
            this.nombre = nombre;
            this.precio = precio;
            this.imagen = imagen;
        }

        private void DetalleProducto_Load(object sender, EventArgs e)
        {
            lblNombre.Text = nombre;
            lblPrecio.Text = "$" + precio.ToString("0.00");
            if (imagen != null)
            {
                pbImagen.Image = imagen;
                pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tbCantidad.Text.Trim(), out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Por favor, ingresa una cantidad válida (solo números enteros mayores a 0).", "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbCantidad.Focus();
                return;
            }

            // Usa la sesión como fallback si Correo no fue enviada al formulario
            string correoUso = !string.IsNullOrEmpty(Correo) ? Correo : Session.Correo;

            if (string.IsNullOrEmpty(correoUso))
            {
                MessageBox.Show("Por favor, inicie sesión para añadir productos al carrito.", "Inicio de sesión requerido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login login = new Login();
                login.Show();
                this.Hide();
                return;
            }

            using (MySqlConnection conn = DataBase.GetConnection())
            {
                conn.Open();

                // Usa IdUsuario de la sesión si está disponible
                if (Session.IdUsuario > 0)
                {
                    IdUsuario = Session.IdUsuario;
                }
                else
                {
                    string queryUser = "SELECT IdUsuario FROM Usuarios WHERE Correo = @Correo";
                    using (MySqlCommand cmdUser = new MySqlCommand(queryUser, conn))
                    {
                        cmdUser.Parameters.AddWithValue("@Correo", correoUso);
                        object resUser = cmdUser.ExecuteScalar();
                        if (resUser == null)
                        {
                            MessageBox.Show("No se encontró el usuario en la base de datos. Inicie sesión nuevamente.", "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        IdUsuario = Convert.ToInt32(resUser);
                        // ✅ Actualizamos la sesión correctamente
                        Session.IniciarSesion(IdUsuario, Session.Nombre ?? "", correoUso);
                    }
                }


                if (IdProducto == 0)
                {
                    string queryProd = "SELECT IdProducto FROM Productos WHERE Nombre = @Nombre LIMIT 1";
                    using (MySqlCommand cmdProd = new MySqlCommand(queryProd, conn))
                    {
                        cmdProd.Parameters.AddWithValue("@Nombre", nombre);
                        object resProd = cmdProd.ExecuteScalar();
                        if (resProd == null)
                        {
                            MessageBox.Show("No se encontró el producto en la base de datos.", "Producto no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        IdProducto = Convert.ToInt32(resProd);
                    }
                }

                string queryCarrito = "SELECT IdCarrito FROM Carritos WHERE IdUsuario = @IdUsuario AND Estado = 'Activo'";
                MySqlCommand cmdCarrito = new MySqlCommand(queryCarrito, conn);
                cmdCarrito.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                object result = cmdCarrito.ExecuteScalar();
                int idCarrito;

                if (result == null)
                {
                    string crearCarrito = "INSERT INTO Carritos (IdUsuario, Estado) VALUES (@IdUsuario, 'Activo')";
                    using (MySqlCommand cmdNuevo = new MySqlCommand(crearCarrito, conn))
                    {
                        cmdNuevo.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                        cmdNuevo.ExecuteNonQuery();
                        long last = cmdNuevo.LastInsertedId;
                        idCarrito = (int)last;
                    }
                }
                else
                {
                    idCarrito = Convert.ToInt32(result);
                }

                string checkExist = @"SELECT COUNT(*) FROM DetallesCarrito WHERE IdCarrito = @IdCarrito AND IdProducto = @IdProducto";
                MySqlCommand cmdCheck = new MySqlCommand(checkExist, conn);
                cmdCheck.Parameters.AddWithValue("@IdCarrito", idCarrito);
                cmdCheck.Parameters.AddWithValue("@IdProducto", IdProducto);
                int existe = Convert.ToInt32(cmdCheck.ExecuteScalar());

                if (existe > 0)
                {
                    string updateQty = @"UPDATE DetallesCarrito SET Cantidad = Cantidad + @Cantidad WHERE IdCarrito = @IdCarrito AND IdProducto = @IdProducto";
                    MySqlCommand cmdUpdate = new MySqlCommand(updateQty, conn);
                    cmdUpdate.Parameters.AddWithValue("@Cantidad", cantidad);
                    cmdUpdate.Parameters.AddWithValue("@IdCarrito", idCarrito);
                    cmdUpdate.Parameters.AddWithValue("@IdProducto", IdProducto);
                    cmdUpdate.ExecuteNonQuery();
                }
                else
                {
                    string insertarDetalle = @"INSERT INTO DetallesCarrito (IdCarrito, IdProducto, Cantidad) VALUES (@IdCarrito, @IdProducto, @Cantidad)";
                    MySqlCommand cmdInsertar = new MySqlCommand(insertarDetalle, conn);
                    cmdInsertar.Parameters.AddWithValue("@IdCarrito", idCarrito);
                    cmdInsertar.Parameters.AddWithValue("@IdProducto", IdProducto);
                    cmdInsertar.Parameters.AddWithValue("@Cantidad", cantidad);
                    cmdInsertar.ExecuteNonQuery();
                }

                MessageBox.Show("Producto añadido al carrito correctamente ✅", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

                    string correoUso = !string.IsNullOrEmpty(Correo) ? Correo : Session.Correo;
                    cmd.Parameters.AddWithValue("@Correo", correoUso);
                    object result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("No se encontró el usuario o no tiene carrito activo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    int idUsuario = Convert.ToInt32(result);

                    Carrito carrito = new Carrito(idUsuario, string.IsNullOrEmpty(Nombre) ? Session.Nombre : Nombre);
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
            string correoUso = !string.IsNullOrEmpty(Correo) ? Correo : Session.Correo;
            string nombreUso = !string.IsNullOrEmpty(Nombre) ? Nombre : Session.Nombre;

            if (string.IsNullOrEmpty(correoUso) || string.IsNullOrEmpty(nombreUso))
            {
                MessageBox.Show("Por favor, inicie sesión para acceder a su perfil.", "Inicio de sesión requerido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login login = new Login();
                login.Show();
                this.Hide();
                return;
            }
            Perfil perfil = new Perfil(nombreUso, correoUso);
            perfil.Owner = this;
            perfil.Show();
            this.Hide();
        }
    }
}
