using System;
using System.Drawing;
using System.Windows.Forms;
using ProyectoArrocha;

namespace ProyectoArrocha
{
    public partial class ProductoCard : UserControl
    {
        private string nombreProducto;
        private decimal precioProducto;
        private Image imagenProducto;
        private FormProductos parentForm;
        private int idProducto;
        private string descripcionProducto;
        private int stockProducto;
        public ProductoCard(FormProductos parent)
        {
            InitializeComponent();
            // Ya no suscribimos this.Click a ProductoCard_Click para evitar duplicados
            parentForm = parent;
            // Propagar el click a los controles internos
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Click += (s, e) => this.OnClick(e);
            }
        }

        public string NombreProducto { get; set; }

        // Método público para asignar la info
        public void CargarDatos(int id, string nombre, decimal precio, string descripcion, int stock, Image imagen)
        {
            nombreProducto = nombre;
            precioProducto = precio;
            imagenProducto = imagen;
            descripcionProducto = descripcion;
            stockProducto = stock;
            idProducto = id;

            // Asigna también la propiedad pública
            NombreProducto = nombre;

            lblNombre.Text = nombre;
            lblPrecio.Text = "$" + precio.ToString("0.00");
            pictureBox1.Image = imagen;
        }
    }
}