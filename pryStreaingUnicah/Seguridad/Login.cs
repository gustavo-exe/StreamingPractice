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
    public partial class Login : Form
    {
        StreamingUnicahIdentidades entity = new StreamingUnicahIdentidades();
        public Login()
        {
            InitializeComponent();
        }

        private void txtIngresar_Click(object sender, EventArgs e)
        {
            //Validacion de campos vacios
            if (txtUsuario.Text == string.Empty) {
                MessageBox.Show("Ingrese el usuario");
                return;
            
            }else if(txtPassword.Text == string.Empty) {
                MessageBox.Show("Ingrese la contraseña");
                return;
            }

            // Instancia de la clase hash con el metodo para la encriptacion
            Hash hash = new Hash();
            string pass = hash.obtenerHash256(txtPassword.Text);

            //Si tiene una lista de valores o entidades devolvera la primera, si la lista esta vacia
            //o no encuantra ninguna coincidencia devolera null
            var tUsuario = entity.Usuarios.FirstOrDefault(x => x.Usuario == txtUsuario.Text && x.Contrasenia == pass);
            if (tUsuario == null) {
                MessageBox.Show("Usuario o Contrasenia incorrecto");
                return;
            }
            else {
                Menu formMenu = new Menu();
                this.Hide();
                formMenu.Show();
            }

        }
    }
}
