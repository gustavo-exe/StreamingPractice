﻿
namespace pryStreaingUnicah
{
    partial class FormPerfilModulo
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGurardar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPerfiles = new System.Windows.Forms.ComboBox();
            this.cmbModulo = new System.Windows.Forms.ComboBox();
            this.cmbModPrin = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(254, 209);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGurardar
            // 
            this.btnGurardar.Location = new System.Drawing.Point(154, 209);
            this.btnGurardar.Name = "btnGurardar";
            this.btnGurardar.Size = new System.Drawing.Size(75, 23);
            this.btnGurardar.TabIndex = 14;
            this.btnGurardar.Text = "Guardar";
            this.btnGurardar.UseVisualStyleBackColor = true;
            this.btnGurardar.Click += new System.EventHandler(this.btnGurardar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Modulo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Modulo principal";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Perfil";
            // 
            // cmbPerfiles
            // 
            this.cmbPerfiles.FormattingEnabled = true;
            this.cmbPerfiles.Location = new System.Drawing.Point(154, 34);
            this.cmbPerfiles.Name = "cmbPerfiles";
            this.cmbPerfiles.Size = new System.Drawing.Size(238, 21);
            this.cmbPerfiles.TabIndex = 10;
            // 
            // cmbModulo
            // 
            this.cmbModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModulo.FormattingEnabled = true;
            this.cmbModulo.Location = new System.Drawing.Point(154, 137);
            this.cmbModulo.Name = "cmbModulo";
            this.cmbModulo.Size = new System.Drawing.Size(238, 21);
            this.cmbModulo.TabIndex = 9;
            // 
            // cmbModPrin
            // 
            this.cmbModPrin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModPrin.FormattingEnabled = true;
            this.cmbModPrin.Location = new System.Drawing.Point(154, 91);
            this.cmbModPrin.Name = "cmbModPrin";
            this.cmbModPrin.Size = new System.Drawing.Size(238, 21);
            this.cmbModPrin.TabIndex = 8;
            this.cmbModPrin.SelectedIndexChanged += new System.EventHandler(this.cmbModPrin_SelectedIndexChanged);
            // 
            // FormPerfilModulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 257);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGurardar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPerfiles);
            this.Controls.Add(this.cmbModulo);
            this.Controls.Add(this.cmbModPrin);
            this.Name = "FormPerfilModulo";
            this.Text = "FormPerfilModulo";
            this.Load += new System.EventHandler(this.FormPerfilModulo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGurardar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPerfiles;
        private System.Windows.Forms.ComboBox cmbModulo;
        private System.Windows.Forms.ComboBox cmbModPrin;
    }
}