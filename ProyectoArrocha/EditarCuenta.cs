using MySql.Data.MySqlClient;
using ProyectoArrocha;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuProyecto;

namespace ProyectoArrocha
{
    public partial class EditarCuenta : Form
    {
        private string CorreoUsuario;
        private string Correo;
        public EditarCuenta(string correo, String Nombre)
        {
            InitializeComponent();
            lbperf.Text = Nombre.Split(' ')[0];
            CorreoUsuario = correo;
            CargarDatosUsuario();

            this.FormClosed += EditarCuenta_FormClosed;
        }

        private void EditarCuenta_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
            }
        }

        private void CargarDatosUsuario()
        {
            using (MySqlConnection conn = DataBase.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Nombre, Correo, Celular, Sexo, FechaNacimiento FROM Usuarios WHERE Correo = @Correo";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Correo", CorreoUsuario);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        tbnombre.Text = reader.GetString("Nombre");
                        tbcel.Text = reader.GetString("Celular");
                        dtp1.Value = reader.GetDateTime("FechaNacimiento");
                        string sexo = reader["Sexo"].ToString();
                        cbmasc.Checked = (sexo == "M");
                        cbfem.Checked = (sexo == "F");
                    }
                    reader.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al cargar datos del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btrealizar_Click(object sender, EventArgs e)
        {
            string nuevoNombre = tbnombre.Text;
            string nuevoCelular = tbcel.Text;
            DateTime nuevaFechaNacimiento = dtp1.Value;
            string nuevoSexo = "";
            if (cbmasc.Checked && !cbfem.Checked)
            {
                nuevoSexo = "M";
            }
            else if (!cbmasc.Checked && cbfem.Checked)
            {
                nuevoSexo = "F";
            }
            else
            {
                MessageBox.Show("Seleccione solo uno: Masculino o Femenino.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection conn = DataBase.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE Usuarios SET Nombre = @Nombre, Celular = @Celular, Sexo = @Sexo, FechaNacimiento = @FechaNacimiento WHERE Correo = @Correo";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nombre", nuevoNombre);
                    cmd.Parameters.AddWithValue("@Celular", nuevoCelular);
                    cmd.Parameters.AddWithValue("@Sexo", nuevoSexo);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", nuevaFechaNacimiento);
                    cmd.Parameters.AddWithValue("@Correo", CorreoUsuario);
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Datos actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (this.Owner != null)
                        {
                            this.Owner.Show();
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se realizaron cambios.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al actualizar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void cbmasc_CheckedChanged(object sender, EventArgs e)
        {
            if (cbmasc.Checked)
            {
                cbfem.Checked = false;
            }
        }

        private void cbfem_CheckedChanged(object sender, EventArgs e)
        {
            if (cbfem.Checked) 
                {
                    cbmasc.Checked = false;
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
    }
}
