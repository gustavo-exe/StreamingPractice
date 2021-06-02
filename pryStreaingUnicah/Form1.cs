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
    public partial class Form1 : Form
    {
        //Intancia de base de datos y variables
        StreamingUnicahIdentidades entityStreaming = new StreamingUnicahIdentidades();
        long idPelicula = 0;
        bool editar = false;
        public Form1()
        {
            InitializeComponent();
        }
        /*
            Ver todos los datos
         */

        private void SelectAll()
        {
            var tableTiposPeliculas = from p in entityStreaming.TiposPeliculas
                                      select new
                                      { 
                                        p.IdTipoPelicula,
                                        p.DescripcionTipoPelicula,
                                        p.EstadoTipoPelicula
                                      };
            dgTipoDePelicula.DataSource = tableTiposPeliculas.CopyAnonymusToDataTable();
            dgTipoDePelicula.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SelectAll();
        }

        /*
            Inserccion de datos y edicion
        */
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Comprobacin de campos vacios.
            if (txtDescTipoPelicula.Text.Equals("")) {
                MessageBox.Show("Por favor ingresar descripcion");
                return;
            }

            if (editar) {

                var rowTipoPelicula = entityStreaming.TiposPeliculas.FirstOrDefault(x => x.IdTipoPelicula == idPelicula);
                rowTipoPelicula.DescripcionTipoPelicula = txtDescTipoPelicula.Text;
                rowTipoPelicula.EstadoTipoPelicula = chkEstado.Checked;

                entityStreaming.SaveChanges();
            }
            else
            {
                /*
                    Inserccion de la informacion
                */

                //Intancia de la tabla
                TiposPeliculas tbTipoPelicula = new TiposPeliculas();
                tbTipoPelicula.DescripcionTipoPelicula = txtDescTipoPelicula.Text;
                tbTipoPelicula.EstadoTipoPelicula = chkEstado.Checked;
                entityStreaming.TiposPeliculas.Add(tbTipoPelicula);
                //Confirma de la insercion
                entityStreaming.SaveChanges();
            }

            SelectAll();
            txtDescTipoPelicula.Text = "";
            chkEstado.Checked = false;
            idPelicula = 0;
            editar = false;

            MessageBox.Show("Informacion guardada!");

        }

        //Validar la fila seleccionada.
        private void dgTipoDePelicula_SelectionChanged(object sender, EventArgs e)
        {
            if (dgTipoDePelicula.RowCount > 0)
            {
                try 
                {
                    idPelicula = Convert.ToInt64(dgTipoDePelicula.SelectedCells[0].Value);
                    var rowTipoPelicula = entityStreaming.TiposPeliculas.FirstOrDefault(x => x.IdTipoPelicula == idPelicula);
                    txtDescTipoPelicula.Text = rowTipoPelicula.DescripcionTipoPelicula;
                    chkEstado.Checked = rowTipoPelicula.EstadoTipoPelicula;
                    editar = true;
                }
                catch (Exception)
                {

                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtDescTipoPelicula.Text = "";
            chkEstado.Checked = false;
            idPelicula = 0;
            editar = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //Destructor
            this.Dispose();
        }
    }
}
