using System.Windows.Forms;

namespace TuProyecto
{
    partial class FormProductos
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProductos));
            this.flowPanelProductos = new System.Windows.Forms.FlowLayoutPanel();
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
            // flowPanelProductos
            // 
            this.flowPanelProductos.AutoScroll = true;
            this.flowPanelProductos.Location = new System.Drawing.Point(10, 90);
            this.flowPanelProductos.Name = "flowPanelProductos";
            this.flowPanelProductos.Size = new System.Drawing.Size(990, 400);
            this.flowPanelProductos.TabIndex = 8;
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
            this.panel1.Size = new System.Drawing.Size(1018, 84);
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
            // FormProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 506);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowPanelProductos);
            this.Name = "FormProductos";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbcar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbperf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pblogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbdeli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbbusq)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowPanelProductos;
        private Panel panel1;
        private PictureBox pbcar;
        private PictureBox pbperf;
        private Label lbperf;
        private PictureBox pbham;
        private PictureBox pblogo;
        private PictureBox pbdeli;
        private Label lbdeli;
        private PictureBox pbbusq;
        private Label lblogo;
        private TextBox tbbusq;
    }
}

