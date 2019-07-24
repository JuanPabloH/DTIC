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
using CapaPresentacion.GestionSalas;
using CapaPresentacion.GestionEquipos;

namespace WindowsFormsApp1
{
    public partial class ModuloAdmin : Form
    {
        
        public ModuloAdmin()
        {
            InitializeComponent();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.Show();
        }

        private void ModuloAdmin_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Salas salas = new Salas();
            salas.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Equipos equipos = new Equipos();
            equipos.Show();
        }
    }
}
