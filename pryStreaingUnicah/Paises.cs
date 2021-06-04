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
    public partial class Paises : Form
    {
        //Intancia de base de datos y variables
        StreamingUnicahEntities1 entityStreaming = new StreamingUnicahEntities1();
        bool editar = false;
        long idPais = 0;
        public Paises()
        {
            InitializeComponent();
        }

        private void SelectAll()
        {
            var tablePais = from p in entityStreaming.Paises
                                       select new
                                       {
                                           p.IdPais,
                                           p.NombrePais,
                                           p.EstadoPais
                                       };
            dataGridView.DataSource = tablePais.CopyAnonymusToDataTable();
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void Paises_Load(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            //Comprobacin de campos vacios.
            if (txtCodigo.Text.Equals("") || txtNombrePais.Text.Equals("") || txtEstadoPais.Text.Equals(""))
            {
                MessageBox.Show("Por favor ingresar todos los datos");
                return;
            }

            if (editar)
            {
                
                var rowPais = entityStreaming.Paises.FirstOrDefault(x => x.IdPais == idPais);
                rowPais.IdPais = Convert.ToByte (txtCodigo.Text);
                rowPais.NombrePais = txtNombrePais.Text;
                rowPais.EstadoPais = Convert.ToBoolean(txtEstadoPais.Text);

                //MessageBox.Show(Convert.ToString(idPais) + Convert.ToString(rowPais.IdPais));
                entityStreaming.SaveChanges();
            }
            else
            {
                /*
                    Inserccion de la informacion
                */

                //Intancia de la tabla atraves de la clase
                Pais tbPais = new Pais();
                tbPais.IdPais = Convert.ToByte(txtCodigo.Text);
                tbPais.NombrePais = txtNombrePais.Text;
                tbPais.EstadoPais = Convert.ToBoolean(txtEstadoPais.Text);
                entityStreaming.Paises.Add(tbPais);
                //Confirma de la insercion
                entityStreaming.SaveChanges();
            }

            SelectAll();
            txtCodigo.Text = "";
            txtNombrePais.Text = "";
            txtEstadoPais.Text = "";

            idPais = 0;
            editar = false;

            MessageBox.Show("Informacion guardada!");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtNombrePais.Text = "";
            txtEstadoPais.Text = "";

            idPais = 0;
            editar = false;
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.RowCount > 0)
            {
                try
                {
                    idPais = Convert.ToInt64(dataGridView.SelectedCells[0].Value);
                    var rowPais = entityStreaming.Paises.FirstOrDefault(x => x.IdPais == idPais);
                    txtCodigo.Text = Convert.ToString(rowPais.IdPais);
                    txtNombrePais.Text = rowPais.NombrePais;

                    txtEstadoPais.Text = Convert.ToString(rowPais.EstadoPais);

                    editar = true;
                }
                catch (Exception)
                {

                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Destructor
            this.Dispose();
        }
    }
}
