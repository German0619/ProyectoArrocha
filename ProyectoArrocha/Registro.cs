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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void btreg_Click(object sender, EventArgs e)
        {
            string Nombre = tbnombre.Text;
            string Correo = tbcorreo.Text;
            string Identificación = tbid.Text;
            string Celular = tbcel.Text;
            string Contraseña = tbcont.Text;
            string confirmar = tbccont.Text;
            DateTime FechaNacimiento = dtp1.Value;
            string Sexo = "";

            if (cbmasc.Checked && !cbfem.Checked)
            {
                Sexo = "M";
            }
            else if (!cbmasc.Checked && cbfem.Checked)
            {
                Sexo = "F";
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un sexo válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Nombre == "" || Correo == "" || Identificación == "" || Celular == "" || Contraseña == "" || confirmar == "")
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Contraseña != confirmar)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dtp1.Value == DateTimePicker.MinimumDateTime)
            {
                MessageBox.Show("Por favor, seleccione su fecha de nacimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Sexo == "")
            {
                MessageBox.Show("Por favor, seleccione su sexo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection conn = DataBase.GetConnection())
            {
                try
                {
                    conn.Open();
                    string queryVerificar = "SELECT COUNT(*) FROM Usuarios WHERE Correo = @Correo";
                    using (MySqlCommand cmdVerificar = new MySqlCommand(queryVerificar, conn))
                    {
                        cmdVerificar.Parameters.AddWithValue("@Correo", Correo);
                        int count = Convert.ToInt32(cmdVerificar.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("El correo ya está registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string query = "INSERT INTO Usuarios (Nombre, Correo, Identificacion, Celular, Contrasena, Sexo, FechaNacimiento) VALUES (@Nombre, @Correo, @Identificacion, @Celular, @Contrasena, @Sexo, @FechaNacimiento)";
                    using (MySqlCommand cmdInsertar = new MySqlCommand(query, conn))
                    {
                        cmdInsertar.Parameters.AddWithValue("@Nombre", Nombre);
                        cmdInsertar.Parameters.AddWithValue("@Correo", Correo);
                        cmdInsertar.Parameters.AddWithValue("@Identificacion", Identificación);
                        cmdInsertar.Parameters.AddWithValue("@Celular", Celular);
                        cmdInsertar.Parameters.AddWithValue("@Contrasena", Contraseña);
                        cmdInsertar.Parameters.AddWithValue("Sexo", Sexo);
                        cmdInsertar.Parameters.AddWithValue("FechaNacimiento", FechaNacimiento);
                        cmdInsertar.ExecuteNonQuery();
                    }
                    MessageBox.Show("Usuario registrado con éxito");

                    Perfil perfil = new Perfil(Nombre, Correo);
                    perfil.Show();
                    this.Hide();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al registrar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }   
        private void btvolver_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
        private void dtp1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbmasc_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbfem_CheckedChanged(object sender, EventArgs e)
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
