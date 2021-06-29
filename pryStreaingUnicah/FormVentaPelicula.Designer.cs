
namespace pryStreaingUnicah
{
    partial class FormVentaPelicula
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnIzquieda = new System.Windows.Forms.Button();
            this.btnDerecha = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gLlevar = new System.Windows.Forms.DataGridView();
            this.IdPelicula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombrePelicula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gEstrenos = new System.Windows.Forms.DataGridView();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gLlevar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gEstrenos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(294, 377);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(212, 23);
            this.btnConfirmar.TabIndex = 15;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnIzquieda
            // 
            this.btnIzquieda.Location = new System.Drawing.Point(359, 278);
            this.btnIzquieda.Name = "btnIzquieda";
            this.btnIzquieda.Size = new System.Drawing.Size(75, 23);
            this.btnIzquieda.TabIndex = 14;
            this.btnIzquieda.Text = "<";
            this.btnIzquieda.UseVisualStyleBackColor = true;
            this.btnIzquieda.Click += new System.EventHandler(this.btnIzquieda_Click);
            // 
            // btnDerecha
            // 
            this.btnDerecha.Location = new System.Drawing.Point(359, 197);
            this.btnDerecha.Name = "btnDerecha";
            this.btnDerecha.Size = new System.Drawing.Size(75, 23);
            this.btnDerecha.TabIndex = 13;
            this.btnDerecha.Text = ">";
            this.btnDerecha.UseVisualStyleBackColor = true;
            this.btnDerecha.Click += new System.EventHandler(this.btnDerecha_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(437, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Peliculas a llevar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Peliculas estreno";
            // 
            // gLlevar
            // 
            this.gLlevar.AllowUserToAddRows = false;
            this.gLlevar.AllowUserToDeleteRows = false;
            this.gLlevar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gLlevar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdPelicula,
            this.NombrePelicula});
            this.gLlevar.Location = new System.Drawing.Point(440, 171);
            this.gLlevar.Name = "gLlevar";
            this.gLlevar.ReadOnly = true;
            this.gLlevar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gLlevar.Size = new System.Drawing.Size(346, 150);
            this.gLlevar.TabIndex = 10;
            // 
            // IdPelicula
            // 
            this.IdPelicula.HeaderText = "Cod. Pelicula";
            this.IdPelicula.Name = "IdPelicula";
            this.IdPelicula.ReadOnly = true;
            this.IdPelicula.Visible = false;
            // 
            // NombrePelicula
            // 
            this.NombrePelicula.HeaderText = "Nombre pelicula";
            this.NombrePelicula.Name = "NombrePelicula";
            this.NombrePelicula.ReadOnly = true;
            this.NombrePelicula.Width = 300;
            // 
            // gEstrenos
            // 
            this.gEstrenos.AllowUserToAddRows = false;
            this.gEstrenos.AllowUserToDeleteRows = false;
            this.gEstrenos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gEstrenos.Location = new System.Drawing.Point(14, 171);
            this.gEstrenos.Name = "gEstrenos";
            this.gEstrenos.ReadOnly = true;
            this.gEstrenos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gEstrenos.Size = new System.Drawing.Size(339, 150);
            this.gEstrenos.TabIndex = 9;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(549, 50);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(0, 13);
            this.lblFecha.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(523, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 16;
            // 
            // FormVentaPelicula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnIzquieda);
            this.Controls.Add(this.btnDerecha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gLlevar);
            this.Controls.Add(this.gEstrenos);
            this.Controls.Add(this.lblFecha);
            this.Name = "FormVentaPelicula";
            this.Text = "FormVentaPelicula";
            this.Load += new System.EventHandler(this.FormVentaPelicula_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gLlevar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gEstrenos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnIzquieda;
        private System.Windows.Forms.Button btnDerecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gLlevar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPelicula;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombrePelicula;
        private System.Windows.Forms.DataGridView gEstrenos;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label label3;
    }
}