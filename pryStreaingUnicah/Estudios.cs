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
    public partial class Estudios : Form
    {
        //Instancia y variables
        StreamingUnicahEntities1 entityStreaming = new StreamingUnicahEntities1();
        long idEstudio = 0;
        bool editar = false;

        public Estudios()
        {
            InitializeComponent();
        }
        private void SelectAll()
        {
            var tableTiposPeliculas = from p in entityStreaming.Estudios
                                      select new
                                      {
                                          p.IdEstudios,
                                          p.NombreEstudio,
                                          p.FechaFundacion,
                                          p.FKPais,
                                          p.EstadoEstudio
                                      };
            dataGridView.DataSource = tableTiposPeliculas.CopyAnonymusToDataTable();
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Comprobacin de campos vacios.
            if (txtNombre.Text.Equals("") || txtEstadoEstudio.Text.Equals("") || txtFecha.Text.Equals("") || txtFkpais.Text.Equals(""))
            {
                MessageBox.Show("Por favor llenar todos los campos.");
                return;
            }

            if (editar)
            {

                var rowEstudio = entityStreaming.Estudios.FirstOrDefault(x => x.IdEstudios == idEstudio);
                rowEstudio.NombreEstudio = txtNombre.Text;
                rowEstudio.FechaFundacion = Convert.ToDateTime(txtFecha.Text);
                rowEstudio.FKPais = Convert.ToByte(txtFkpais.Text);
                rowEstudio.EstadoEstudio = Convert.ToBoolean(txtEstadoEstudio.Text);

                entityStreaming.SaveChanges();
            }
            else
            {
                /*
                    Inserccion de la informacion
                */

                //Intancia de la tabla
                Estudio tbEstudio = new Estudio();
                tbEstudio.NombreEstudio = txtNombre.Text;
                tbEstudio.FechaFundacion = Convert.ToDateTime(txtFecha.Text);
                tbEstudio.FKPais = Convert.ToByte(txtFkpais.Text);
                tbEstudio.EstadoEstudio = Convert.ToBoolean(txtEstadoEstudio.Text);

                entityStreaming.Estudios.Add(tbEstudio);
                //Confirma de la insercion
                entityStreaming.SaveChanges();
            }

            SelectAll();

            txtNombre.Text = "";
            txtEstadoEstudio.Text = "";
            txtFecha.Text = "";
            txtFkpais.Text = "";
            idEstudio = 0;
            editar = false;

            MessageBox.Show("Informacion guardada!");
        }

        private void Estudios_Load(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.RowCount > 0)
            {
                try
                {
                    idEstudio = Convert.ToInt64(dataGridView.SelectedCells[0].Value);

                    var rowEstudio = entityStreaming.Estudios.FirstOrDefault(x => x.IdEstudios == idEstudio);
                    txtNombre.Text = rowEstudio.NombreEstudio;
                    txtFecha.Text =  Convert.ToString(rowEstudio.FechaFundacion);
                    txtFkpais.Text = Convert.ToString(rowEstudio.FKPais);
                    txtEstadoEstudio.Text = Convert.ToString(rowEstudio.EstadoEstudio);

                    editar = true;
                }
                catch (Exception)
                {

                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtEstadoEstudio.Text = "";
            txtFecha.Text = "";
            txtFkpais.Text = "";
            idEstudio = 0;
            editar = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
