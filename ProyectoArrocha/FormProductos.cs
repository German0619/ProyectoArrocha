using ProyectoArrocha;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TuProyecto
{
    public partial class FormProductos : Form
    {
        public FormProductos()
        {
            InitializeComponent();
            this.Load += FormProductos_Load;
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            flowPanelProductos.Controls.Clear();

            try
            {
                using (SqlConnection conn = new SqlConnection("TU_CADENA_DE_CONEXION"))
                {
                    conn.Open();

                    string query = "SELECT Nombre, Precio, Imagen FROM Productos";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string nombre = reader["Nombre"].ToString();
                        decimal precio = Convert.ToDecimal(reader["Precio"]);

                        // Convertir imagen byte[] a Image
                        byte[] imgBytes = reader["Imagen"] as byte[];
                        Image imagen = null;

                        if (imgBytes != null && imgBytes.Length > 0)
                        {
                            MemoryStream ms = new MemoryStream(imgBytes);
                            imagen = Image.FromStream(ms);
                        }

                        // Crear la tarjeta de producto
                        ProductoCard card = new ProductoCard();
                        card.CargarDatos(nombre, precio, imagen);

                        flowPanelProductos.Controls.Add(card);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }
    }
}
