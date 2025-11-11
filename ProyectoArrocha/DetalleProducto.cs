using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuProyecto;

namespace ProyectoArrocha
{
    public partial class DetalleProducto : Form
    {
        private string nombre;
        private decimal precio;
        private Image imagen;
        public string Correo;
        public string Nombre;
        private string descripcion;
        private int stock;
        private int IdUsuario;
        private int IdProducto;
        public DetalleProducto(int idProducto, string nombre, decimal precio, string descripcion, int stock, Image imagen)
        {
            InitializeComponent();
            lbperf.Text = nombre.Split(' ')[0];
            this.nombre = nombre;
            this.precio = precio;
            this.descripcion = descripcion;
            this.stock = stock;
            this.imagen = imagen;
            IdProducto = idProducto;
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

        private void DetalleProducto_Load(object sender, EventArgs e)
        {
            lblNombre.Text = nombre;
            lblPrecio.Text = "$" + precio.ToString("0.00");
            lblStock.Text = "Disponibles: " + stock.ToString();
            tbDescripcion.Text = descripcion;
            if (imagen != null)
            {
                pbImagen.Image = imagen;
                pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void tbDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(lblCantidad.Text.Trim(), out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Por favor, ingresa una cantidad válida (solo números enteros mayores a 0).",
                                "Cantidad inválida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                lblCantidad.Focus();
                return;
            }

            using (MySqlConnection conn = DataBase.GetConnection())
            {
                conn.Open();
                string qUsuario = "SELECT IdUsuario FROM Usuarios WHERE Correo = @Correo";
                MySqlCommand cmdUsuario = new MySqlCommand(qUsuario, conn);
                cmdUsuario.Parameters.AddWithValue("@Correo", Correo);
                object result = cmdUsuario.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("Debe iniciar sesión para agregar al carrito.");
                    return;
                }

                int idUsuario = Convert.ToInt32(result);

                // Buscar carrito activo
                string queryCarrito = "SELECT IdCarrito FROM Carritos WHERE IdUsuario = @IdUsuario AND Estado = 'Activo'";
                MySqlCommand cmdCarrito = new MySqlCommand(queryCarrito, conn);
                cmdCarrito.Parameters.AddWithValue("@IdUsuario", idUsuario);

                object resultCarrito = cmdCarrito.ExecuteScalar();
                int idCarrito;

                if (resultCarrito == null)
                {
                    // Crear un nuevo carrito si no existe
                    string crearCarrito = "INSERT INTO Carritos (IdUsuario, Estado) VALUES (@IdUsuario, 'Activo')";
                    MySqlCommand cmdNuevo = new MySqlCommand(crearCarrito, conn);
                    cmdNuevo.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    cmdNuevo.ExecuteNonQuery();

                    idCarrito = (int)cmdNuevo.LastInsertedId;
                }
                else
                {
                    idCarrito = Convert.ToInt32(resultCarrito);
                }

                // Verificar si el producto ya está en el carrito
                string checkExist = @"SELECT COUNT(*) FROM DetallesCarrito 
                              WHERE IdCarrito = @IdCarrito AND IdProducto = @IdProducto";
                MySqlCommand cmdCheck = new MySqlCommand(checkExist, conn);
                cmdCheck.Parameters.AddWithValue("@IdCarrito", idCarrito);
                cmdCheck.Parameters.AddWithValue("@IdProducto", IdProducto);
                int existe = Convert.ToInt32(cmdCheck.ExecuteScalar());

                if (existe > 0)
                {
                    // Si ya existe, actualizar cantidad
                    string updateQty = @"UPDATE DetallesCarrito 
                                 SET Cantidad = Cantidad + @Cantidad 
                                 WHERE IdCarrito = @IdCarrito AND IdProducto = @IdProducto";
                    MySqlCommand cmdUpdate = new MySqlCommand(updateQty, conn);
                    cmdUpdate.Parameters.AddWithValue("@Cantidad", cantidad);
                    cmdUpdate.Parameters.AddWithValue("@IdCarrito", idCarrito);
                    cmdUpdate.Parameters.AddWithValue("@IdProducto", IdProducto);
                    cmdUpdate.ExecuteNonQuery();
                }
                else
                {
                    // Si no existe, insertar nuevo producto
                    string insertarDetalle = @"INSERT INTO DetallesCarrito (IdCarrito, IdProducto, Cantidad)
                                       VALUES (@IdCarrito, @IdProducto, @Cantidad)";
                    MySqlCommand cmdInsertar = new MySqlCommand(insertarDetalle, conn);
                    cmdInsertar.Parameters.AddWithValue("@IdCarrito", idCarrito);
                    cmdInsertar.Parameters.AddWithValue("@IdProducto", IdProducto);
                    cmdInsertar.Parameters.AddWithValue("@Cantidad", cantidad);
                    cmdInsertar.ExecuteNonQuery();
                }

                MessageBox.Show("Producto añadido al carrito correctamente",
                                "Éxito",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
