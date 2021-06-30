using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryStreaingUnicah
{
    public partial class FormPerfilModulo : Form
    {
        StreamingUnicahIdentidades entity = new StreamingUnicahIdentidades();
        public FormPerfilModulo()
        {
            InitializeComponent();
        }


        private void FormPerfilModulo_Load(object sender, EventArgs e)
        {
            cmbModPrin.SelectedIndex = -1;

            //Llenado de los primeros dos combo box
            //Perfiles
            var tablaPerfil = from p in entity.Perfiles
                              where p.EstadoPerfil == true
                              select new
                              {
                                  p.IdPerfil,
                                  p.DescripcionPerfil
                              };
            DataTable dataTablePerfil = tablaPerfil.CopyAnonymusToDataTable();
            cmbPerfiles.DataSource = dataTablePerfil;
            cmbPerfiles.ValueMember = dataTablePerfil.Columns[0].ColumnName;
            cmbPerfiles.DisplayMember = dataTablePerfil.Columns[1].ColumnName;

            //Modulo principal
            var tablaModuloPrincipal = from mp in entity.ModuloPrincipal
                                       where mp.EstadoModuloPrin == true
                                       select new
                                       {
                                           mp.IdModuloPrincipal,
                                           mp.DescripcionModuloPrin
                                       };
            DataTable dataTableModuloPrincipal = tablaModuloPrincipal.CopyAnonymusToDataTable();

            cmbModPrin.DataSource = dataTableModuloPrincipal;
            cmbModPrin.ValueMember = dataTableModuloPrincipal.Columns[0].ColumnName;
            cmbModPrin.DisplayMember = dataTableModuloPrincipal.Columns[1].ColumnName;

        }

        private void cmbModPrin_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idModulo = Convert.ToInt32(cmbModPrin.SelectedValue);

                //obtener los datos para saber a que modulo de los modulos principales
                //se debe seleccionar
                var tablaModulo = from mod in entity.Modulos
                                  where mod.FKModuloPrincipal == idModulo
                                  select new
                                  {
                                      mod.IdModulos,
                                      mod.DescripcionModulo
                                  };

                DataTable dataTableModulo = tablaModulo.CopyAnonymusToDataTable();
                cmbModulo.DataSource = dataTableModulo;
                cmbModulo.ValueMember = dataTableModulo.Columns[0].ColumnName;
                cmbModulo.DisplayMember = dataTableModulo.Columns[1].ColumnName;

            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cmbPerfiles.SelectedIndex = cmbModPrin.SelectedIndex = cmbModulo.SelectedIndex = -1;
        }
        private void btnGurardar_Click(object sender, EventArgs e)
        {
            if (cmbPerfiles.SelectedIndex == -1 || cmbModPrin.SelectedIndex == -1 || cmbModulo.SelectedIndex == -1)
            {
                MessageBox.Show("En alguna lista no se selcciono una opcion.");
            }
            else
            {
                PerfilModulo perfilModulo = new PerfilModulo();
                perfilModulo.FKPerfilId = Convert.ToInt16(cmbPerfiles.SelectedValue);
                perfilModulo.FKModuloId = Convert.ToInt16(cmbModulo.SelectedValue);

                entity.PerfilModulo.Add(perfilModulo);
                entity.SaveChanges();

                MessageBox.Show("Nueva asigancion de perfile modulo completada.");
                cmbPerfiles.SelectedIndex = cmbModPrin.SelectedIndex = cmbModulo.SelectedIndex = -1;
            }
        }
    }
}
