namespace ProyectoArrocha
{
    partial class MetodoPago
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MetodoPago));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.tbDireccion = new System.Windows.Forms.TextBox();
            this.cbMetodoPago = new System.Windows.Forms.ComboBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
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
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(359, 106);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(251, 41);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Método de Pago";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(269, 176);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(59, 16);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(269, 229);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(67, 16);
            this.lblDireccion.TabIndex = 3;
            this.lblDireccion.Text = "Dirección:";
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Location = new System.Drawing.Point(269, 279);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(110, 16);
            this.lblMetodoPago.TabIndex = 4;
            this.lblMetodoPago.Text = "Método de pago:";
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(379, 176);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(200, 22);
            this.tbNombre.TabIndex = 5;
            // 
            // tbDireccion
            // 
            this.tbDireccion.Location = new System.Drawing.Point(379, 229);
            this.tbDireccion.Name = "tbDireccion";
            this.tbDireccion.Size = new System.Drawing.Size(300, 22);
            this.tbDireccion.TabIndex = 7;
            // 
            // cbMetodoPago
            // 
            this.cbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMetodoPago.Items.AddRange(new object[] {
            "Tarjeta de crédito",
            "Tarjeta de débito",
            "PayPal",
            "Efectivo a la entrega"});
            this.cbMetodoPago.Location = new System.Drawing.Point(409, 279);
            this.cbMetodoPago.Name = "cbMetodoPago";
            this.cbMetodoPago.Size = new System.Drawing.Size(200, 24);
            this.cbMetodoPago.TabIndex = 8;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.Red;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(379, 329);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 9;
            this.btnConfirmar.Text = "Confirmar Pago";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.LightGray;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Location = new System.Drawing.Point(529, 329);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
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
            this.panel1.Size = new System.Drawing.Size(1032, 84);
            this.panel1.TabIndex = 26;
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
            // MetodoPago
            // 
            this.ClientSize = new System.Drawing.Size(1032, 395);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.lblMetodoPago);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.tbDireccion);
            this.Controls.Add(this.cbMetodoPago);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "MetodoPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Método de Pago";
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

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.TextBox tbDireccion;
        private System.Windows.Forms.ComboBox cbMetodoPago;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
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
