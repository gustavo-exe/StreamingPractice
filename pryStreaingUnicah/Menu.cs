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
    public partial class Menu : Form
    {
        long idUsuario = 0;
        StreamingUnicahIdentidades entity = new StreamingUnicahIdentidades();
        public Menu(long id_Usuario)
        {
            InitializeComponent();
            idUsuario = id_Usuario;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            //Consulta
            //Datos necesarios para saber que tipo de perfil de usuario es
            //y que coincidan con el usuario pasado desde el login.
            var tablaInformacionUsuario = from u in entity.Usuarios
                                          join per in entity.Perfiles on u.FKPerfil equals per.IdPerfil
                                          where u.IdUsuario == idUsuario
                                          select new
                                          {
                                              u.Usuario,
                                              u.FKPerfil,
                                              per.DescripcionPerfil
                                          };
            DataTable dataTableInformacion = tablaInformacionUsuario.CopyAnonymusToDataTable();

            //Obteniendo la llave para saber el tipo de perfil al que pertenece.
            short FKPerfil = Convert.ToInt16(dataTableInformacion.Rows[0].ItemArray[1]);

            var tablaPerfilModulo = from modulos in entity.PerfilModulo
                                    where modulos.FKPerfilId == FKPerfil
                                    select modulos;
            //Lista
            List<short> listaModulo = new List<short>();
            DataTable dataTablePerfilModulo =  tablaPerfilModulo.CopyAnonymusToDataTable();

            for (int i = 0; i < dataTablePerfilModulo.Rows.Count; i++)
            {
                listaModulo.Add(Convert.ToInt16(dataTablePerfilModulo.Rows[i].ItemArray[1]));
            }

            var tablaMdodulos = from pm in entity.Modulos
                                join md in entity.ModuloPrincipal on pm.FKModuloPrincipal equals md.IdModuloPrincipal
                                where listaModulo.Contains(pm.IdModulos)
                                & md.EstadoModuloPrin == true
                                & pm.EstadoModulo == true
                                orderby pm.FKModuloPrincipal
                                select new
                                {
                                    pm.DescripcionModulo,
                                    md.DescripcionModuloPrin,
                                    pm.FKModuloPrincipal,
                                    pm.IdModulos
                                };
            DataTable dataTableModulos = tablaMdodulos.CopyAnonymusToDataTable();
            DataRow dataTableRow = dataTableModulos.NewRow();

            dataTableRow[2] = "0";
            dataTableRow[3] = "0";

            dataTableModulos.Rows.Add(dataTableRow);

            short modPrincipalAnterior = 0;
            
            //Menu
            MenuStrip menuStrip = new MenuStrip();
            ToolStripMenuItem menuPrincipal = new ToolStripMenuItem();

            foreach (DataRow dataRow in dataTableModulos.Rows)
            {
                if (modPrincipalAnterior == Convert.ToInt16(dataRow[2]))
                {
                    ToolStripMenuItem subMenu = new ToolStripMenuItem(dataRow[0].ToString(), null, ChildClick);
                    subMenu.Name = dataRow[0].ToString();
                    menuPrincipal.DropDownItems.Add(subMenu);
                }
                else
                {
                    if (!menuPrincipal.Name.Equals(""))
                        menuStrip.Items.Add(menuPrincipal);
                    menuPrincipal = new ToolStripMenuItem(dataRow[1].ToString());

                    menuPrincipal.Name = dataRow[1].ToString();
                    ToolStripMenuItem subMenu = new ToolStripMenuItem(dataRow[0].ToString(), null, ChildClick);
                    subMenu.Name = dataRow[0].ToString();
                    menuPrincipal.DropDownItems.Add(subMenu);
                }
                modPrincipalAnterior = Convert.ToInt16(dataRow[2]);
            }
            this.Controls.Add(menuStrip);

        }

        public void ChildClick(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;

            var tipo = Type.GetType("pryStreaingUnicah." + menu.Name);

            var frm = Activator.CreateInstance(tipo);

            Form formulario = (Form)frm;

            formulario.Show();

        }
    }
}
