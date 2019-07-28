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

namespace CapaPresentacion.PrestamoDevolucion
{
    public partial class Prestamos : Form
    {
        public Prestamos()
        {
            InitializeComponent();
        }

        private void Prestamos_Load(object sender, EventArgs e)
        {
            llenarTabla();
        }
        private void llenarTabla()
        {
            CN_PrestamoDev prestamoDev = new CN_PrestamoDev();
            DataTable prestamos = new DataTable();
            prestamos = prestamoDev.prestamosActivos();
            dataGridView1.DataSource = prestamos;
            List<string> salasList = new List<string>();
            salasList = prestamoDev.listaSalas();
            comboBoxSalas.DataSource = salasList;
            comboBoxSalas.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void comboBoxSalas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CN_PrestamoDev prestamoDev = new CN_PrestamoDev();
            List<string> equiposList = new List<string>();

            String idSalainf = idSala(comboBoxSalas.Text);
            equiposList = prestamoDev.listaEquipos(idSalainf);
            comboBoxEquipos.DataSource = equiposList;
            comboBoxEquipos.DropDownStyle = ComboBoxStyle.DropDownList;
            MessageBox.Show("idSala"+idSalainf);
        }

        private String idSala(String nombreSala)
        {
            CN_Equipo equipo = new CN_Equipo();
            DataTable equipos = new DataTable();
            equipos = equipo.sala(nombreSala);
            DataRow fila = equipos.Rows[0];
            String idSala = fila["idSalaInformatica"].ToString();
            return idSala;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String nombreSala = comboBoxSalas.Text;
            String nombreEquipo = comboBoxEquipos.Text;
            String codigo = textBoxCodigo.Text;
        }
    }
}
