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
    public partial class CalidadCamisas : Form
    {
        delegate bool delEvaluacion(double valor);
        DataTable dataTableEvaluacion = new DataTable();

        public CalidadCamisas()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            float calidad = 0;
            delEvaluacion evaluacion;
            /*
                Condiciones para saber si se aceptara el valor 
            */
            //Ancho del cuerpo debe de estar entre 21 y 23 cm
            evaluacion = (x) => (x >= 21 && x <= 23);
            calidad += evaluacion(Convert.ToDouble(txtAnchoCuerpo.Text)) ? 1 : 0;

            //Manga tiene que estar entre 17.72 y 19.25
            evaluacion = (x) => (x >= 17.75 && x <= 19.25);
            calidad += evaluacion(Convert.ToDouble(txtManga.Text)) ? 1 : 0;

            //Cierre manga entre 3.25 y 3.75
            evaluacion = (x) => (x >= 3.25 && x <= 3.75);
            calidad += evaluacion(Convert.ToDouble(txtCierreManga.Text)) ? 1 : 0;

            //Largo entre 29 y 31
            evaluacion = (x) => (x >= 29 && x <= 31);
            calidad += evaluacion(Convert.ToDouble(txtLargoCuerpo.Text)) ? 1 : 0;

            //Abertura entre 7 y 8
            evaluacion = (x) => (x >= 7 && x <= 8);
            calidad += evaluacion(Convert.ToDouble(txtAbertura.Text)) ? 1 : 0;

            dataTableEvaluacion.Rows.Add(new object[] {txtAnchoCuerpo.Text, txtManga.Text,txtCierreManga.Text,
            txtLargoCuerpo.Text,txtAbertura.Text,(calidad / 5) * 100});

            //Ingreso de la informacion en el DATA GRID
            dataGridEvaluacion.DataSource = dataTableEvaluacion;
        }

        private void CalidadCamisas_Load(object sender, EventArgs e)
        {
            dataTableEvaluacion.Columns.Add("Ancho de cuerpo");
            dataTableEvaluacion.Columns.Add("Manga");
            dataTableEvaluacion.Columns.Add("Cierre manga");
            dataTableEvaluacion.Columns.Add("Largo cuerpo");
            dataTableEvaluacion.Columns.Add("Abertura cuello");
            dataTableEvaluacion.Columns.Add("Calidad");
        }
    }
}
