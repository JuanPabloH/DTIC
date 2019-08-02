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
using CapaPresentacion.PrestamoDevolucion;

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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Prestamos prestamos = new Prestamos();
            prestamos.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            CapaPresentacion.ReporteActividad reporteActividad = new CapaPresentacion.ReporteActividad();
            reporteActividad.Show();
        }
    }
}
