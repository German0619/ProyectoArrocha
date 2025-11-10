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
        public ProductoCard()
        {
            InitializeComponent();
        }

        // Método público para asignar la info
        public void CargarDatos(string nombre, decimal precio, Image imagen)
        {
            lblNombre.Text = nombre;
            lblPrecio.Text = "$" + precio.ToString("F2");
            pictureBox1.Image = imagen;
        }

        private void ProductoCard_Load(object sender, EventArgs e)
        {

        }
    }
}
