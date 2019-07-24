using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
       
        CN_Login login = new CN_Login();
        ModuloAdmin mAdmin = new ModuloAdmin();
        ModuloBecario mBecario = new ModuloBecario();
        ModuloFuncionario mFuncionario = new ModuloFuncionario();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //prueba
        }

        private void textBoxEmail_Click(object sender, EventArgs e)
        {
            if(textBoxEmail.Text== "Correo electrónico")
            {
                textBoxEmail.Clear();
            }
            
        }

        private void textBoxPwd_Click(object sender, EventArgs e)
        {
            if(textBoxPwd.Text== "Contraseña")
            {
                textBoxPwd.Clear();
                textBoxPwd.PasswordChar = '*';
            }            
            
            
        }    

        private void textBoxPwd_Enter(object sender, EventArgs e)
        {

            if (textBoxPwd.Text == "Contraseña")
            {
                textBoxPwd.Clear();
                textBoxPwd.PasswordChar = '*';
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            String email = textBoxEmail.Text;
            String password = textBoxPwd.Text;
            DataTable resultado = new DataTable();
            resultado = consultarBD(email, password);
            if (resultado.Rows.Count==1)
            {
                String nombre = resultado.Rows[0][1].ToString();
                String apellido = resultado.Rows[0][2].ToString();
                if (resultado.Rows[0][4].ToString() == "1")
                {
                    //MessageBox.Show("Bienvenido "+nombre+" "+apellido+", Administrador");
                    mAdmin.Show();
                    this.Close();
                    
                }
                else if (resultado.Rows[0][4].ToString() == "2")
                {
                    //MessageBox.Show("Bienvenido " + nombre + " " + apellido + ", Funcionario");
                    mFuncionario.Show();
                    this.Close();
                }
                else if (resultado.Rows[0][4].ToString() == "3")
                {
                    //MessageBox.Show("Bienvenido " + nombre + " " + apellido + ", Becario");
                    mBecario.Show();
                    this.Close();
                }
                resultado.Reset();
            }
            else
            {
                MessageBox.Show("Datos Incorrectos", "Mesage de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private DataTable consultarBD(String email, String password)
        {
            DataTable consulta = new DataTable();
            consulta= login.mostrarUsuario(email, password);

            return consulta;
        }
    }
}
