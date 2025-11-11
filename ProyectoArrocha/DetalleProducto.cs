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
        public DetalleProducto(string nombre, decimal precio, Image imagen)
        {
            InitializeComponent();
            lbperf.Text = Nombre.Split(' ')[0];
            this.nombre = nombre;
            this.precio = precio;
            this.imagen = imagen;
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
    }
    }
