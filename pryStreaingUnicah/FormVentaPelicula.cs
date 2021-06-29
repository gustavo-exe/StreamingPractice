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
    public partial class FormVentaPelicula : Form
    {
        StreamingUnicahIdentidades entity = new StreamingUnicahIdentidades();

        DataTable dataTableEstreno = new DataTable();

        public FormVentaPelicula()
        {
            InitializeComponent();
        }
        private void FormVentaPelicula_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Today.ToShortDateString();

            SelectTablaEstreno();
        }

        private void SelectTablaEstreno()
        {
            var tablaEstreno = from p in entity.Peliculas
                               where p.Estreno == true
                               select new
                               {
                                   p.IdPelicula,
                                   p.NombrePelicula,
                                   p.FechaLanzamiento
                               };
            dataTableEstreno = tablaEstreno.CopyAnonymusToDataTable();
            gEstrenos.DataSource = dataTableEstreno;
        }

        private void btnDerecha_Click(object sender, EventArgs e)
        {
            if (gEstrenos.SelectedRows.Count > 0)
            {
                int indice = gEstrenos.CurrentCell.RowIndex;
                long idPelicula = Convert.ToInt64(gEstrenos.Rows[indice].Cells[0].Value.ToString());
                string nombrePelicula = gEstrenos.Rows[indice].Cells[1].Value.ToString();

                //Se agregan los dettales de la fila selecciona en estreno
                //al otro data grid
                gLlevar.Rows.Add(idPelicula.ToString(), nombrePelicula);

                dataTableEstreno = (DataTable)gEstrenos.DataSource;

                //Eliminacion de la fila que se selecciono
                dataTableEstreno.Rows.RemoveAt(indice);
                gEstrenos.DataSource = dataTableEstreno;
            }
            else
            {
                MessageBox.Show("Seleccione un estreno");
            }
        }

        private void btnIzquieda_Click(object sender, EventArgs e)
        {
            if (gLlevar.SelectedRows.Count > 0)
            {
                int indice = gLlevar.CurrentCell.RowIndex;
                long idPelicula = Convert.ToInt64(gLlevar.Rows[indice].Cells[0].Value.ToString());
                string nombrePelicula = gLlevar.Rows[indice].Cells[1].Value.ToString();

                //Se agregan los dettales de la fila selecciona en estreno
                //al otro data grid
                dataTableEstreno.Rows.Add(idPelicula.ToString(), nombrePelicula,"");

                //Eliminacion de la fila que se selecciono
                gEstrenos.DataSource = dataTableEstreno;
                gLlevar.Rows.RemoveAt(indice);
            }
            else
            {
                MessageBox.Show("Seleccione un estreno");
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if(gLlevar.SelectedRows.Count > 0)
            {
                VentaPelicula tablaVentaPelicula = new VentaPelicula();
                tablaVentaPelicula.EstatusVenta = "Completa";
                tablaVentaPelicula.EstadoVenta = true;
                tablaVentaPelicula.IdUsuario = 2;
                tablaVentaPelicula.FechaVenta = DateTime.Now;

                entity.VentaPelicula.Add(tablaVentaPelicula);
                entity.SaveChanges();

                foreach ( DataGridViewRow dr in gLlevar.Rows)
                {
                    VentaDetallePelicula tablaDetallePelicula = new VentaDetallePelicula();
                    tablaDetallePelicula.FKIdPelicula = Convert.ToInt64(dr.Cells[0].Value);
                    tablaDetallePelicula.FKIdVenta = tablaVentaPelicula.IdVenta;

                    entity.VentaDetallePelicula.Add(tablaDetallePelicula);
                    entity.SaveChanges();
                }

                MessageBox.Show("Venta exitosa");

                //Limpieza del data grid
                for (int i = 0; i < gLlevar.Rows.Count; i++)
                {
                    gLlevar.Rows.RemoveAt(i);
                }

                SelectTablaEstreno();
            }
            else
            {
                MessageBox.Show("Seleccione al menos una pelicula");
            }
        }
    }
}
