using MySql.Data.MySqlClient;
using ProyectoArrocha;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TuProyecto
{
    public partial class FormProductos : Form
    {
        private List<ProductoCard> listaProductos = new List<ProductoCard>();
        private string Correo;
        private string Nombre;

        public FormProductos(string nombreUsuario = "", string correoUsuario = "")
        {
            InitializeComponent();

            Nombre = nombreUsuario;
            Correo = correoUsuario;

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

                    string query = "SELECT Nombre, Precio, ImagenUrl FROM Productos";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string nombre = reader["Nombre"].ToString();
                        decimal precio = Convert.ToDecimal(reader["Precio"]);

                        // Leer la URL de la imagen
                        string imagenUrl = reader["ImagenUrl"] == DBNull.Value
                            ? string.Empty
                            : reader["ImagenUrl"].ToString();

                        Image imagen = null;

                        if (!string.IsNullOrEmpty(imagenUrl))
                        {
                            try
                            {
                                if (File.Exists(imagenUrl))
                                {
                                    // Si es una ruta local en disco
                                    imagen = Image.FromFile(imagenUrl);
                                }
                                else if (imagenUrl.StartsWith("http"))
                                {
                                    // Si es una URL remota, puedes usar LoadAsync en el PictureBox
                                    // Aquí lo dejamos en null y lo cargas directamente en ProductoCard
                                }
                            }
                            catch
                            {
                                // Ignora errores de carga de imagen
                            }
                        }

                        // Crear la tarjeta de producto
                        ProductoCard card = new ProductoCard();
                        card.CargarDatos(nombre, precio, imagen);

                        listaProductos.Add(card);
                        flowPanelProductos.Controls.Add(card);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }


        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.ToLower().Trim();
            flowPanelProductos.Controls.Clear();

            foreach (var card in listaProductos)
            {
                if (card.NombreProducto.ToLower().Contains(filtro))
                {
                    flowPanelProductos.Controls.Add(card);
                }
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
                    cmd.Parameters.AddWithValue("@Correo", Correo);
                    object result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("No se encontró el usuario o no tiene carrito activo.",
                                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Error al abrir el carrito: " + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pbperf_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Correo) || string.IsNullOrEmpty(Nombre))
            {
                MessageBox.Show("Por favor, inicie sesión para acceder a su perfil.",
                                "Inicio de sesión requerido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

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