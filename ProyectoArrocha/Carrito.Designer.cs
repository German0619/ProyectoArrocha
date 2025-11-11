namespace ProyectoArrocha
{
    partial class Carrito
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalMonto;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnVolver;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Carrito));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalMonto = new System.Windows.Forms.Label();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbcar = new System.Windows.Forms.PictureBox();
            this.pbperf = new System.Windows.Forms.PictureBox();
            this.lbperf = new System.Windows.Forms.Label();
            this.pbham = new System.Windows.Forms.PictureBox();
            this.pblogo = new System.Windows.Forms.PictureBox();
            this.pbdeli = new System.Windows.Forms.PictureBox();
            this.lbdeli = new System.Windows.Forms.Label();
            this.pbbusq = new System.Windows.Forms.PictureBox();
            this.lblogo = new System.Windows.Forms.Label();
            this.tbbusq = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbcar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbperf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pblogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbdeli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbbusq)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(34, 85);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(141, 37);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "Su carrito";
            // 
            // dgvCarrito
            // 
            this.dgvCarrito.AllowUserToAddRows = false;
            this.dgvCarrito.AllowUserToDeleteRows = false;
            this.dgvCarrito.AllowUserToResizeRows = false;
            this.dgvCarrito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarrito.BackgroundColor = System.Drawing.Color.White;
            this.dgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrito.Location = new System.Drawing.Point(40, 139);
            this.dgvCarrito.MultiSelect = false;
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.RowHeadersVisible = false;
            this.dgvCarrito.RowHeadersWidth = 51;
            this.dgvCarrito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarrito.Size = new System.Drawing.Size(937, 320);
            this.dgvCarrito.TabIndex = 1;
            this.dgvCarrito.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarrito_CellValueChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(640, 480);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(77, 32);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "Total:";
            // 
            // lblTotalMonto
            // 
            this.lblTotalMonto.AutoSize = true;
            this.lblTotalMonto.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalMonto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotalMonto.Location = new System.Drawing.Point(720, 480);
            this.lblTotalMonto.Name = "lblTotalMonto";
            this.lblTotalMonto.Size = new System.Drawing.Size(77, 32);
            this.lblTotalMonto.TabIndex = 3;
            this.lblTotalMonto.Text = "$0.00";
            // 
            // btnPagar
            // 
            this.btnPagar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPagar.ForeColor = System.Drawing.Color.White;
            this.btnPagar.Location = new System.Drawing.Point(834, 469);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(143, 48);
            this.btnPagar.TabIndex = 2;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.LightGray;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEliminar.Location = new System.Drawing.Point(40, 480);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(171, 37);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "Eliminar producto";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.Gainsboro;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnVolver.Location = new System.Drawing.Point(229, 480);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(114, 37);
            this.btnVolver.TabIndex = 0;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.pbcar);
            this.panel1.Controls.Add(this.pbperf);
            this.panel1.Controls.Add(this.lbperf);
            this.panel1.Controls.Add(this.pbham);
            this.panel1.Controls.Add(this.pblogo);
            this.panel1.Controls.Add(this.pbdeli);
            this.panel1.Controls.Add(this.lbdeli);
            this.panel1.Controls.Add(this.pbbusq);
            this.panel1.Controls.Add(this.lblogo);
            this.panel1.Controls.Add(this.tbbusq);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1029, 84);
            this.panel1.TabIndex = 67;
            // 
            // pbcar
            // 
            this.pbcar.Image = ((System.Drawing.Image)(resources.GetObject("pbcar.Image")));
            this.pbcar.Location = new System.Drawing.Point(963, 23);
            this.pbcar.Margin = new System.Windows.Forms.Padding(4);
            this.pbcar.Name = "pbcar";
            this.pbcar.Size = new System.Drawing.Size(41, 40);
            this.pbcar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbcar.TabIndex = 6;
            this.pbcar.TabStop = false;
            // 
            // pbperf
            // 
            this.pbperf.Image = ((System.Drawing.Image)(resources.GetObject("pbperf.Image")));
            this.pbperf.Location = new System.Drawing.Point(823, 27);
            this.pbperf.Name = "pbperf";
            this.pbperf.Size = new System.Drawing.Size(38, 35);
            this.pbperf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbperf.TabIndex = 9;
            this.pbperf.TabStop = false;
            this.pbperf.Click += new System.EventHandler(this.pbperf_Click);
            // 
            // lbperf
            // 
            this.lbperf.AutoSize = true;
            this.lbperf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbperf.ForeColor = System.Drawing.Color.White;
            this.lbperf.Location = new System.Drawing.Point(868, 36);
            this.lbperf.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbperf.Name = "lbperf";
            this.lbperf.Size = new System.Drawing.Size(0, 18);
            this.lbperf.TabIndex = 2;
            // 
            // pbham
            // 
            this.pbham.Image = ((System.Drawing.Image)(resources.GetObject("pbham.Image")));
            this.pbham.Location = new System.Drawing.Point(20, 21);
            this.pbham.Margin = new System.Windows.Forms.Padding(4);
            this.pbham.Name = "pbham";
            this.pbham.Size = new System.Drawing.Size(37, 37);
            this.pbham.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbham.TabIndex = 8;
            this.pbham.TabStop = false;
            // 
            // pblogo
            // 
            this.pblogo.Image = ((System.Drawing.Image)(resources.GetObject("pblogo.Image")));
            this.pblogo.Location = new System.Drawing.Point(77, 21);
            this.pblogo.Margin = new System.Windows.Forms.Padding(4);
            this.pblogo.Name = "pblogo";
            this.pblogo.Size = new System.Drawing.Size(49, 43);
            this.pblogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pblogo.TabIndex = 7;
            this.pblogo.TabStop = false;
            this.pblogo.Click += new System.EventHandler(this.pblogo_Click);
            // 
            // pbdeli
            // 
            this.pbdeli.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbdeli.Image = ((System.Drawing.Image)(resources.GetObject("pbdeli.Image")));
            this.pbdeli.InitialImage = null;
            this.pbdeli.Location = new System.Drawing.Point(606, 27);
            this.pbdeli.Margin = new System.Windows.Forms.Padding(4);
            this.pbdeli.Name = "pbdeli";
            this.pbdeli.Size = new System.Drawing.Size(45, 37);
            this.pbdeli.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbdeli.TabIndex = 1;
            this.pbdeli.TabStop = false;
            // 
            // lbdeli
            // 
            this.lbdeli.AutoSize = true;
            this.lbdeli.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdeli.ForeColor = System.Drawing.Color.White;
            this.lbdeli.Location = new System.Drawing.Point(659, 16);
            this.lbdeli.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbdeli.Name = "lbdeli";
            this.lbdeli.Size = new System.Drawing.Size(146, 54);
            this.lbdeli.TabIndex = 1;
            this.lbdeli.Text = "Delivery Recetario\r\n(507) 6815-1053\r\n(507) 6645-4943";
            // 
            // pbbusq
            // 
            this.pbbusq.Image = ((System.Drawing.Image)(resources.GetObject("pbbusq.Image")));
            this.pbbusq.Location = new System.Drawing.Point(563, 31);
            this.pbbusq.Margin = new System.Windows.Forms.Padding(4);
            this.pbbusq.Name = "pbbusq";
            this.pbbusq.Size = new System.Drawing.Size(31, 32);
            this.pbbusq.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbbusq.TabIndex = 5;
            this.pbbusq.TabStop = false;
            // 
            // lblogo
            // 
            this.lblogo.AutoSize = true;
            this.lblogo.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblogo.ForeColor = System.Drawing.Color.White;
            this.lblogo.Location = new System.Drawing.Point(134, 30);
            this.lblogo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblogo.Name = "lblogo";
            this.lblogo.Size = new System.Drawing.Size(98, 27);
            this.lblogo.TabIndex = 3;
            this.lblogo.Text = "ARROCHA";
            this.lblogo.Click += new System.EventHandler(this.lblogo_Click);
            // 
            // tbbusq
            // 
            this.tbbusq.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.tbbusq.Location = new System.Drawing.Point(261, 33);
            this.tbbusq.Margin = new System.Windows.Forms.Padding(4);
            this.tbbusq.Name = "tbbusq";
            this.tbbusq.Size = new System.Drawing.Size(294, 22);
            this.tbbusq.TabIndex = 0;
            this.tbbusq.Text = "¿Qué estás buscando?";
            // 
            // Carrito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1029, 555);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.lblTotalMonto);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvCarrito);
            this.Controls.Add(this.lblTitulo);
            this.Name = "Carrito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carrito de Compras";
            this.Load += new System.EventHandler(this.Carrito_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbcar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbperf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pblogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbdeli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbbusq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbcar;
        private System.Windows.Forms.PictureBox pbperf;
        private System.Windows.Forms.Label lbperf;
        private System.Windows.Forms.PictureBox pbham;
        private System.Windows.Forms.PictureBox pblogo;
        private System.Windows.Forms.PictureBox pbdeli;
        private System.Windows.Forms.Label lbdeli;
        private System.Windows.Forms.PictureBox pbbusq;
        private System.Windows.Forms.Label lblogo;
        private System.Windows.Forms.TextBox tbbusq;
    }
}