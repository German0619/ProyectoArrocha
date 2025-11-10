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

namespace Proyecto_ds4
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
            EditarCuenta editarCuenta = new EditarCuenta(Correo);
            editarCuenta.Owner = this;
            editarCuenta.Show();
            this.Hide();
        }

        private void btcamb_Click(object sender, EventArgs e)
        {
            CambiarContraseña cambiarContraseña = new CambiarContraseña(Correo);
            cambiarContraseña.Owner = this;
            cambiarContraseña.Show();
            this.Hide();
        }
    }
}