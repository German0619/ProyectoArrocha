using System;
using System.Drawing;
using System.Windows.Forms;
using TuProyecto;

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
            this.Click += ProductoCard_Click;
            parentForm = parent;
            // Propagar el click a los controles internos
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Click += ProductoCard_Click;
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

        private void ProductoCard_Click(object sender, EventArgs e)
        {
            parentForm.Hide();
            // Abre el formulario de detalles
            DetalleProducto detalles = new DetalleProducto(idProducto, nombreProducto, precioProducto, descripcionProducto, stockProducto, imagenProducto);
            detalles.ShowDialog();  // o Show(), según prefieras
        }

        private void ProductoCard_Load(object sender, EventArgs e)
        {
            // Aquí puedes inicializar algo si lo necesitas
        }
    }
}