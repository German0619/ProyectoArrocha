using MySql.Data.MySqlClient;
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

                    Carrito carrito = new Carrito(idUsuario, lbnom.Text);
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