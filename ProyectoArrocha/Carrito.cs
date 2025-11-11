using MySql.Data.MySqlClient;
using ProyectoArrocha;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProyectoArrocha
{
    public partial class Carrito : Form
    {
        private int IdUsuario;
        private int IdCarrito;
        private string Correo;
        private string Nombre;

        public Carrito(int idUsuario, string Nombre)
        {
            InitializeComponent();
            lbperf.Text = Nombre.Split(' ')[0];
            IdUsuario = idUsuario;
            CargarCarrito();

            dgvCarrito.CellClick += dgvCarrito_CellClick; 
        }

        private void CargarCarrito()
        {
            using (MySqlConnection conn = DataBase.GetConnection())
            {
                conn.Open();

                string queryCarrito = "SELECT IdCarrito FROM Carritos WHERE IdUsuario = @IdUsuario AND Estado = 'Activo'";
                MySqlCommand cmdCarrito = new MySqlCommand(queryCarrito, conn);
                cmdCarrito.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                object result = cmdCarrito.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("No hay un carrito activo para este usuario.");
                    return;
                }

                IdCarrito = Convert.ToInt32(result);

                string query = @"SELECT dc.IdDetalle, p.ImagenUrl, p.Nombre AS Producto, p.Precio, dc.Cantidad, (p.Precio * dc.Cantidad) AS Subtotal FROM DetallesCarrito dc INNER JOIN Productos p ON dc.IdProducto = p.IdProducto WHERE dc.IdCarrito = @IdCarrito";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@IdCarrito", IdCarrito);
                DataTable table = new DataTable();
                adapter.Fill(table);

                if (!table.Columns.Contains("Imagen"))
                    table.Columns.Add("Imagen", typeof(Image));

                foreach (DataRow row in table.Rows)
                {
                    string ruta = row["ImagenUrl"].ToString();
                    if (!string.IsNullOrEmpty(ruta) && File.Exists(ruta))
                    {
                        try
                        {
                            row["Imagen"] = Image.FromFile(ruta);
                        }
                        catch 
                        {
                            row["Imagen"] = null; 
                        }
                    }
                }            

                dgvCarrito.DataSource = table;

                ConfigurarColumnas();

                decimal total = 0;
                foreach (DataRow row in table.Rows)
                    total += Convert.ToDecimal(row["Subtotal"]);

                lblTotalMonto.Text = "$" + total.ToString("F2");
            }
        }

        private void ConfigurarColumnas()
        {
            dgvCarrito.RowTemplate.Height = 90;
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCarrito.Columns["IdDetalle"].Visible = false;
            dgvCarrito.Columns["ImagenUrl"].Visible = false;

            dgvCarrito.Columns["Imagen"].DisplayIndex = 0;
            dgvCarrito.Columns["Imagen"].HeaderText = "Producto";
            ((DataGridViewImageColumn)dgvCarrito.Columns["Imagen"]).ImageLayout = DataGridViewImageCellLayout.Zoom;

            dgvCarrito.Columns["Producto"].HeaderText = "Nombre";
            dgvCarrito.Columns["Precio"].HeaderText = "Precio ($)";
            dgvCarrito.Columns["Cantidad"].HeaderText = "Cantidad";
            dgvCarrito.Columns["Subtotal"].HeaderText = "Subtotal ($)";

            if (!dgvCarrito.Columns.Contains("Aumentar"))
            {
                DataGridViewButtonColumn btnMas = new DataGridViewButtonColumn
                {
                    Name = "Aumentar",
                    HeaderText = "",
                    Text = "+",
                    UseColumnTextForButtonValue = true,
                    Width = 40
                };
                dgvCarrito.Columns.Add(btnMas);
            }

            if (!dgvCarrito.Columns.Contains("Disminuir"))
            {
                DataGridViewButtonColumn btnMenos = new DataGridViewButtonColumn
                {
                    Name = "Disminuir",
                    HeaderText = "",
                    Text = "–",
                    UseColumnTextForButtonValue = true,
                    Width = 40
                };
                dgvCarrito.Columns.Add(btnMenos);
            }
        }


        private void dgvCarrito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int idDetalle = Convert.ToInt32(dgvCarrito.Rows[e.RowIndex].Cells["IdDetalle"].Value);

            if (dgvCarrito.Columns[e.ColumnIndex].Name == "Aumentar")
            {
                ActualizarCantidad(idDetalle, 1);
            }
            else if (dgvCarrito.Columns[e.ColumnIndex].Name == "Disminuir")
            {
                ActualizarCantidad(idDetalle, -1);
            }
        }

        private void ActualizarCantidad(int idDetalle, int cambio)
        {
            using (MySqlConnection conn = DataBase.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE DetallesCarrito dc INNER JOIN Productos p ON dc.IdProducto = p.IdProducto SET dc.Cantidad = GREATEST(dc.Cantidad + @Cambio, 1), dc.Subtotal = p.Precio * GREATEST(dc.Cantidad + @Cambio, 1) WHERE dc.IdDetalle = @IdDetalle";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Cambio", cambio);
                cmd.Parameters.AddWithValue("@IdDetalle", idDetalle);
                cmd.ExecuteNonQuery();
            }

            CargarCarrito();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.CurrentRow == null) return;
            int idDetalle = Convert.ToInt32(dgvCarrito.CurrentRow.Cells["IdDetalle"].Value);

            using (MySqlConnection conn = DataBase.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM DetallesCarrito WHERE IdDetalle = @IdDetalle";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdDetalle", idDetalle);
                cmd.ExecuteNonQuery();
            }

            CargarCarrito();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            MetodoPago metodoPago = new MetodoPago(IdUsuario, IdCarrito, Nombre, Correo);
            metodoPago.Owner = this;
            metodoPago.Show();
            this.Hide();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormProductos frm = new FormProductos(Nombre, Correo);
            frm.Show();
            this.Close();
        }

        private void pbperf_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Correo) || string.IsNullOrEmpty(Nombre))
            {
                MessageBox.Show("Por favor, inicie sesión para acceder a su perfil.",
                                "Inicio de sesión requerido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                Login login = new Login();
                login.Show();
                this.Hide();
                return;
            }

            Perfil perfil = new Perfil(Nombre, Correo);
            perfil.Owner = this;
            perfil.Show();
            this.Hide();
        }
    }
}
