using ProyectoArrocha;
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
    public partial class Perfil : Form
    {
        private String Correo;
        public Perfil(string Nombre, string Email)
        {
            InitializeComponent();
            lbnom.Text = Nombre;
            lbcorreo.Text = Email;
            Correo = Email;
        }

        private void btlout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
        private void btedit_Click(object sender, EventArgs e)
        {
            EditarCuenta editarCuenta = new EditarCuenta(Correo, lbnom.Text);
            editarCuenta.Owner = this;
            editarCuenta.Show();
            this.Hide();
        }

        private void btcamb_Click(object sender, EventArgs e)
        {
            CambiarContraseña cambiarContraseña = new CambiarContraseña(Correo, lbnom.Text);
            cambiarContraseña.Owner = this;
            cambiarContraseña.Show();
            this.Hide();
        }

        private void pbperf_Click(object sender, EventArgs e)
        {
           
        }

        private void pbcar_Click(object sender, EventArgs e)
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
    }
}