using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProyectoArrocha
{
    public partial class FormProductos : Form
    {
        private List<ProductoCard> listaProductos = new List<ProductoCard>();
        private string Correo => Session.Correo;
        private string Nombre => Session.Nombre;

        public FormProductos()
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(Nombre))
                lbperf.Text = Nombre.Split(' ')[0];

            this.Load += FormProductos_Load;
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            flowPanelProductos.Controls.Clear();
            listaProductos.Clear();

            try
            {
                using (MySqlConnection conn = DataBase.GetConnection())
                {
                    conn.Open();
                    // Trae también Id, Descripcion y Stock
                    string query = "SELECT IdProducto, Nombre, Precio, Descripcion, Stock, ImagenUrl FROM Productos";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader["IdProducto"] != DBNull.Value ? Convert.ToInt32(reader["IdProducto"]) : 0;
                            string nombre = reader["Nombre"].ToString();
                            decimal precio = reader["Precio"] != DBNull.Value ? Convert.ToDecimal(reader["Precio"]) : 0m;
                            string descripcion = reader["Descripcion"] == DBNull.Value ? string.Empty : reader["Descripcion"].ToString();
                            int stock = reader["Stock"] != DBNull.Value ? Convert.ToInt32(reader["Stock"]) : 0;
                            string imagenUrl = reader["ImagenUrl"] == DBNull.Value ? string.Empty : reader["ImagenUrl"].ToString();

                            Image imagen = null;
                            if (!string.IsNullOrEmpty(imagenUrl))
                            {
                                try
                                {
                                    string rutaAbsoluta = imagenUrl;
                                    if (!Path.IsPathRooted(imagenUrl))
                                        rutaAbsoluta = Path.Combine(Application.StartupPath, imagenUrl);

                                    if (File.Exists(rutaAbsoluta))
                                        imagen = Image.FromFile(rutaAbsoluta);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Error al cargar imagen: " + ex.Message);
                                }
                            }

                            ProductoCard card = new ProductoCard(this);
                            // Llamada con la firma correcta
                            card.CargarDatos(id, nombre, precio, descripcion, stock, imagen);
                            card.Click += (s, e) => AbrirDetalleProducto(id, nombre, precio, descripcion, stock, imagen);

                            listaProductos.Add(card);
                            flowPanelProductos.Controls.Add(card);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        private void AbrirDetalleProducto(int id, string nombre, decimal precio, string descripcion, int stock, Image imagen)
        {
            DetalleProducto detalle = new DetalleProducto(id, nombre, precio, descripcion, stock, imagen)
            {
                Nombre = this.Nombre,
                Correo = this.Correo
            };

            detalle.Owner = this;
            detalle.Show();
            this.Hide();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.ToLower().Trim();
            flowPanelProductos.Controls.Clear();

            foreach (var card in listaProductos)
            {
                if (card.NombreProducto.ToLower().StartsWith(filtro))
                {
                    flowPanelProductos.Controls.Add(card);
                }
            }
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
            if (!Session.IsLoggedIn)
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