using MySql.Data.MySqlClient;
using ProyectoArrocha;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuProyecto;

namespace ProyectoArrocha
{
    public partial class CambiarContraseña : Form
    {
        private string CorreoUsuario;
        public CambiarContraseña(string Correo, String Nombre)
        {
            InitializeComponent();
            lbperf.Text = Nombre.Split(' ')[0];
            CorreoUsuario = Correo;

            this.FormClosed += CambiarContraseña_FormClosed;
        }

        private void CambiarContraseña_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
            }
        }

        private void btcambiar_Click(object sender, EventArgs e)
        {
            string actual = tbactual.Text;
            string nueva = tbnueva.Text;
            string confirmar = tbconfirmar.Text;

            if (actual == "" || nueva == "" || confirmar == "")
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (nueva != confirmar)
            {
                {
                    MessageBox.Show("Las nuevas contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            using (MySqlConnection conn = DataBase.GetConnection())
            {
                conn.Open();
                string queryVerificar = "SELECT * FROM Usuarios WHERE Correo = @Correo AND Contrasena = @actual";
                MySqlCommand cmdVerificar = new MySqlCommand(queryVerificar, conn);
                cmdVerificar.Parameters.AddWithValue("@Correo", CorreoUsuario);
                cmdVerificar.Parameters.AddWithValue("@actual", actual);
                MySqlDataReader reader = cmdVerificar.ExecuteReader();

                if (!reader.Read())
                {
                    reader.Close();
                    MessageBox.Show("La contraseña actual es incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                reader.Close();

                string queryActualizar = "UPDATE Usuarios SET Contrasena = @nueva WHERE Correo = @Correo";
                MySqlCommand cmdActualizar = new MySqlCommand(queryActualizar, conn);
                cmdActualizar.Parameters.AddWithValue("@nueva", nueva);
                cmdActualizar.Parameters.AddWithValue("@Correo", CorreoUsuario);
                int filasAfectadas = cmdActualizar.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Contraseña actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (this.Owner != null)
                    {
                        this.Owner.Show();
                    }
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Error al actualizar la contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btcancel_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
            }
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
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