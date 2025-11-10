using MySql.Data.MySqlClient;
using ProyectoArrocha;
using System;
using System.Data;
using System.Windows.Forms;
using TuProyecto;

namespace ProyectoArrocha
{
    public partial class Carrito : Form
    {
        private int IdUsuario;
        private int IdCarrito;

        public Carrito(int idUsuario, String Nombre)
        {
            InitializeComponent();
            lbperf.Text = Nombre.Split(' ')[0];
            IdUsuario = idUsuario;
            CargarCarrito();
        }

        private void CargarCarrito()
        {
            using (MySqlConnection conn = DataBase.GetConnection())
            {
                conn.Open();

                // Obtener el carrito activo del usuario
                string queryCarrito = "SELECT IdCarrito FROM Carritos WHERE IdUsuario = @IdUsuario AND Estado = 'Activo'";
                MySqlCommand cmdCarrito = new MySqlCommand(queryCarrito, conn);
                cmdCarrito.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                object result = cmdCarrito.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("No hay un carrito activo.");
                    return;
                }

                IdCarrito = Convert.ToInt32(result);

                // Mostrar los productos del carrito
                string query = @"SELECT 
                                    dc.IdDetalle,
                                    p.Nombre AS Producto,
                                    p.Precio,
                                    dc.Cantidad,
                                    dc.Subtotal
                                FROM DetallesCarrito dc
                                INNER JOIN Productos p ON dc.IdProducto = p.IdProducto
                                WHERE dc.IdCarrito = @IdCarrito";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@IdCarrito", IdCarrito);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvCarrito.DataSource = table;

                // Calcular el total
                decimal total = 0;
                foreach (DataRow row in table.Rows)
                    total += Convert.ToDecimal(row["Subtotal"]);

                lblTotalMonto.Text = "$" + total.ToString("F2");
            }
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

        private void dgvCarrito_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvCarrito.Columns["Cantidad"].Index)
            {
                int idDetalle = Convert.ToInt32(dgvCarrito.Rows[e.RowIndex].Cells["IdDetalle"].Value);
                int cantidad = Convert.ToInt32(dgvCarrito.Rows[e.RowIndex].Cells["Cantidad"].Value);

                using (MySqlConnection conn = DataBase.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE DetallesCarrito SET Cantidad = @Cantidad WHERE IdDetalle = @IdDetalle";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@IdDetalle", idDetalle);
                    cmd.ExecuteNonQuery();
                }

                CargarCarrito();
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = DataBase.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Carritos SET Estado = 'Pagado' WHERE IdCarrito = @IdCarrito";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdCarrito", IdCarrito);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Compra realizada con éxito.", "Pago exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Perfil perfil = new Perfil("Usuario", "correo@ejemplo.com");
            perfil.Show();
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
    }
}
