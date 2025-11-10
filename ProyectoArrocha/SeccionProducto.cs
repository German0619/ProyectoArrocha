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
    public partial class SeccionProducto : Form
    {
        private string nombre;
        private decimal precio;
        private Image imagen;
        public SeccionProducto(string nombre, decimal precio, Image imagen)
        {
            InitializeComponent();
            this.nombre = nombre;
            this.precio = precio;
            this.imagen = imagen;
        }

        private void SeccionProducto_Load(object sender, EventArgs e)
        {
            lblNombre.Text = nombre;
            lblPrecio.Text = "$" + precio.ToString("0.00");
            if (imagen != null)
            {
                pbImagen.Image = imagen;
                pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void pbImagen_Click(object sender, EventArgs e)
        {

        }
    }
}
