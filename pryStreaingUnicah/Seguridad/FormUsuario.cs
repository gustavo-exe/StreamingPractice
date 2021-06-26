using pryStreaingUnicah.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryStreaingUnicah.Seguridad
{
    public partial class FormUsuario : Form
    {
        StreamingUnicahIdentidades entity = new StreamingUnicahIdentidades();
        public FormUsuario()
        {
            InitializeComponent();
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            SelectWhereEstado();
        }

        private void SelectWhereEstado()
        {
            var tablaPerfil = from p in entity.Perfiles
                              where p.EstadoPerfil == true
                              select new
                              {
                                  p.IdPerfil,
                                  p.DescripcionPerfil
                              };
            DataTable dataTablePerfil = tablaPerfil.CopyAnonymusToDataTable();

            cmbPerfil.DataSource = dataTablePerfil;
            cmbPerfil.DisplayMember = dataTablePerfil.Columns[1].ColumnName;
            cmbPerfil.ValueMember = dataTablePerfil.Columns[0].ColumnName;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Validaciones
            if (txtUsuario.Text.Equals(""))
            {
                MessageBox.Show("Ingrese el usuario");
                return;
            }

            if (txtNombre.Text.Equals(""))
            {
                MessageBox.Show("Ingrese el nombre completo");
                return;
            }

            if (dpFechaNac.Value == null || dpFechaNac.Text.Equals(""))
            {
                MessageBox.Show("Ingrese la fecha de nacimiento");
                return;
            }

            if (cmbPerfil.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el perfil");
                return;
            }

            if (txtContrasenia.Text == string.Empty)
            {
                MessageBox.Show("Ingrese Contrasenia");
                return;
            }

            //Insertar usuario
            try
            {
                //Intancia de indetidad
                Usuarios tablaUsuarios = new Usuarios();
                tablaUsuarios.Usuario = txtUsuario.Text;
                tablaUsuarios.NombreCompleto = txtNombre.Text;
                tablaUsuarios.FechaNacimeinto = dpFechaNac.Value;
                tablaUsuarios.FKPerfil = Convert.ToInt16(cmbPerfil.SelectedValue);
                tablaUsuarios.CorreoElectronico = txtCorreo.Text;
                tablaUsuarios.Estdo = chkEstado.Checked;
                
                //Encriptacion
                Hash hash = new Hash();
                tablaUsuarios.Contrasenia = hash.obtenerHash256(txtContrasenia.Text);

                //Guardado de cambios
                entity.Usuarios.Add(tablaUsuarios);
                entity.SaveChanges();
                MessageBox.Show("Datos guardados");

                //Limpieza de campos
                txtContrasenia.Text = txtCorreo.Text = txtNombre.Text = txtUsuario.Text = string.Empty;
                chkEstado.Checked = false;
                dpFechaNac.Value = DateTime.Today;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
