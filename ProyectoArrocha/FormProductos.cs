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

            // EJEMPLO: si tu ProductoCard tiene método CargarDatos

            ProductoCard card1 = new ProductoCard();
            card1.CargarDatos("Ibuprofeno 400mg", 3.99m, null);

            ProductoCard card2 = new ProductoCard();
            card2.CargarDatos("Vitamina C 1000mg", 5.50m, null);

      

            flowPanelProductos.Controls.Add(card1);
            flowPanelProductos.Controls.Add(card2);
        }




    }
}
