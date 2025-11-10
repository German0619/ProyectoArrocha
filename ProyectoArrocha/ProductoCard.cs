using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoArrocha
{
    public partial class ProductoCard : UserControl
    {
        private string nombreProducto;
        private decimal precioProducto;
        private Image imagenProducto;
        public string NombreProducto { get { return nombreProducto; } }


        public ProductoCard()
        {
            InitializeComponent();
            // Hace clic en cualquier parte del card
            this.Click += ProductoCard_Click;

            // También propaga el click de los controles internos
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Click += ProductoCard_Click;
            }
        }

        // Método público para asignar la info
        public void CargarDatos(string nombre, decimal precio, Image imagen)
        {
            nombreProducto = nombre;
            precioProducto = precio;
            imagenProducto = imagen;

            lblNombre.Text = nombre;
            lblPrecio.Text = "$" + precio.ToString("0.00");
            pictureBox1.Image = imagen;
            
        }
        private void ProductoCard_Click(object sender, EventArgs e)
        {
            // Abre el formulario de detalles
            //FormDetallesProducto detalles = new FormDetallesProducto(nombreProducto, precioProducto, imagenProducto);

            //detalles.ShowDialog();  // o Show(), como tú quieras
        }

    }

}
