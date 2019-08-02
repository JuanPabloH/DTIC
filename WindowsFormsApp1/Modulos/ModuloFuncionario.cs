using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.GestionUsuarios;
using CapaPresentacion.PrestamoDevolucion;

namespace WindowsFormsApp1
{
    public partial class ModuloFuncionario : Form
    {
        public ModuloFuncionario()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Prestamos prestamos = new Prestamos();
            prestamos.Show();
        }
    }
}
