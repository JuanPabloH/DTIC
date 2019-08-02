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

namespace CapaPresentacion
{
    public partial class ReporteActividad : Form
    {
        public ReporteActividad()
        {
            InitializeComponent();
        }

        private void ReporteActividad_Load(object sender, EventArgs e)
        {
            CN_Equipo equipo = new CN_Equipo();
            List<string> salasList = new List<string>();
            salasList = equipo.listaSalas();
            comboBox1.DataSource = salasList;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            CN_Reporte reporte = new CN_Reporte();
            String fecha= dateTimePicker1.Value.ToString("yyyy/MM/dd");
            String nombreSala = comboBox1.Text;
            String codigo = textBox1.Text;
            DataTable reporteTabla = new DataTable();
            reporteTabla = reporte.reporte(fecha, nombreSala, codigo);
            if (reporteTabla.Rows.Count==0)
            {
                MessageBox.Show("No existen registros con los datos ingresados");
            }
            else
            {
                dataGridView1.DataSource = reporteTabla;
            }
        }

        
    }
}
