using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using ProyectoArrocha;

namespace ProyectoArrocha
{
    public partial class AdminProductos : Form
    {
        private string nombre;
        private string correo;

        public AdminProductos(string nombre, string email)
        {
            InitializeComponent();

            // Guardar datos de sesión/locales para usarlos en los handlers
            this.nombre = nombre ?? string.Empty;
            this.correo = email ?? string.Empty;

            // Mostrar el nombre en la interfaz si existe el control lbnom
            try
            {
                if (!string.IsNullOrEmpty(this.nombre) && this.Controls.ContainsKey("lbnom"))
                {
                    var lbl = this.Controls["lbnom"] as Label;
                    if (lbl != null) lbl.Text = this.nombre;
                }
            }
            catch
            {
                // Silenciar si el control no existe en tiempo de diseño.
            }

            CargarProductos();
        }

        // Método para cargar todos los productos en el DataGridView
        private void CargarProductos()
        {
            try
            {
                using (MySqlConnection conn = DataBase.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT IdProducto, Nombre, Descripcion, Precio, Stock, ImagenUrl FROM Productos";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        // Botón Agregar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                string.IsNullOrWhiteSpace(txtStock.Text))
            {
                MessageBox.Show("Por favor completa todos los campos.");
                return;
            }

            try
            {
                using (MySqlConnection conn = DataBase.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO Productos 
                             (Nombre, Descripcion, Precio, Stock, ImagenUrl, Activo) 
                             VALUES (@Nombre, @Descripcion, @Precio, @Stock, @ImagenUrl, 1)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@Nombre", MySqlDbType.VarChar).Value = txtNombre.Text.Trim();
                        cmd.Parameters.Add("@Descripcion", MySqlDbType.VarChar).Value = txtDescripcion.Text.Trim();
                        cmd.Parameters.Add("@Precio", MySqlDbType.Decimal).Value = Convert.ToDecimal(txtPrecio.Text);
                        cmd.Parameters.Add("@Stock", MySqlDbType.Int32).Value = Convert.ToInt32(txtStock.Text);
                        string rutaCruda = txtImagen.Text.Trim();
                        string rutaLimpia = rutaCruda.Replace("\"", "").Replace("\\", "/");
                        cmd.Parameters.Add("@ImagenUrl", MySqlDbType.VarChar).Value = rutaLimpia;

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Producto agregado correctamente ✅");
                CargarProductos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar producto: " + ex.Message);
            }
        }

        // Botón Eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idProducto = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IdProducto"].Value);

                try
                {
                    using (MySqlConnection conn = DataBase.GetConnection())
                    {
                        conn.Open();
                        string query = "DELETE FROM Productos WHERE IdProducto = @IdProducto";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.Add("@IdProducto", MySqlDbType.Int32).Value = idProducto;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Producto eliminado correctamente ❌");
                    CargarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar producto: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecciona un producto para eliminar.");
            }
        }

        // Método para limpiar los campos después de agregar
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtImagen.Clear();
        }

        private void pbperf_Click(object sender, EventArgs e)
        {
            // Usamos los campos locales que inicializó el constructor
            if (string.IsNullOrEmpty(this.correo) || string.IsNullOrEmpty(this.nombre))
            {
                MessageBox.Show("Por favor, inicie sesión para acceder a su perfil.", "Inicio de sesión requerido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir pantalla de login de forma modal para evitar múltiples instancias
                using (var login = new Login())
                {
                    var dr = login.ShowDialog(this);
                    // Si tras el login los datos de sesión se almacenan en una clase Session,
                    // se podrían actualizar las variables locales desde ahí:
                    // if (Session.IsLogged) { this.nombre = Session.Nombre; this.correo = Session.Correo; lbnom.Text = this.nombre; }
                }
                return;
            }

            // Abrir Perfil pasando nombre y correo
            Perfil perfil = new Perfil(this.nombre, this.correo);
            perfil.Owner = this;
            perfil.Show();
            this.Hide();
        }
    }    
}