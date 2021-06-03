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
    public partial class Clasificacion : Form
    {
        //Intancia de base de datos y variables
        StreamingUnicahEntities1 entityStreaming = new StreamingUnicahEntities1();
        bool editar = false;
        long idClasificacion = 0;
        public Clasificacion()
        {
            InitializeComponent();
        }


        private void SelectAll()
        {
            var tableClasificaciones = from p in entityStreaming.Clasificaciones
                                      select new
                                      {
                                          p.IdClasificaciones,
                                          p.DescripcionClasficacion,
                                          p.EstadoClasificacion
                                      };
            dataGridView.DataSource = tableClasificaciones.CopyAnonymusToDataTable();
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void Clasificacion_Load(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            //Comprobacin de campos vacios.
            if (txtDescripcion.Text.Equals("") || txtEstado.Text.Equals(""))
            {
                MessageBox.Show("Por favor ingresar Todos los datos");
                return;
            }
           
            if (editar)
            {

                var rowClasificacion = entityStreaming.Clasificaciones.FirstOrDefault(x => x.IdClasificaciones == idClasificacion);
                rowClasificacion.DescripcionClasficacion = txtDescripcion.Text;
                rowClasificacion.EstadoClasificacion =Convert.ToBoolean(txtEstado.Text);

                entityStreaming.SaveChanges();
            }
            else
            {
                /*
                    Inserccion de la informacion
                */

                //Intancia de la tabla atraves de la clase
                Clasificacione tbClasificacion = new Clasificacione();
                tbClasificacion.DescripcionClasficacion = txtDescripcion.Text;
                tbClasificacion.EstadoClasificacion = Convert.ToBoolean(txtEstado.Text);
                entityStreaming.Clasificaciones.Add(tbClasificacion);
                //Confirma de la insercion
                entityStreaming.SaveChanges();
            }

            SelectAll();
            txtDescripcion.Text = "";
            txtEstado.Text = "";

            idClasificacion = 0;
            editar = false;

            MessageBox.Show("Informacion guardada!");

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
            txtEstado.Text = "";

            idClasificacion = 0;
            editar = false;
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.RowCount > 0)
            {
                try
                {
                    idClasificacion = Convert.ToInt64(dataGridView.SelectedCells[0].Value);
                    var rowClasificacion = entityStreaming.Clasificaciones.FirstOrDefault(x => x.IdClasificaciones == idClasificacion);
                    txtDescripcion.Text = rowClasificacion.DescripcionClasficacion;
                    txtEstado.Text = Convert.ToString(rowClasificacion.EstadoClasificacion);

                    editar = true;
                }
                catch (Exception)
                {

                }
            }
        }
    }
}

