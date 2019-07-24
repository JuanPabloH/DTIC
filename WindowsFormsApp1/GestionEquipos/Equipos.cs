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

namespace CapaPresentacion.GestionEquipos
{
    public partial class Equipos : Form
    {

        bool editSala = false;
        String codEdir = null;
        public Equipos()
        {
            InitializeComponent();
        }

        private void Equipos_Load(object sender, EventArgs e)
        {
            llenarTabla();
        }


       
        private void buttonActiveFormAdd_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            comboBox1.SelectedIndex = 0;
            panelForm.Show();
            this.Size= new Size(394, 507);
        }

        private void buttonCancelAdd_Click(object sender, EventArgs e)
        {
            panelForm.Show();
            this.Size = new Size(394, 366);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (editSala)
            {
                updateSala();
            }
            else
            {
                addSala();
            }
            


        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                String idEquipoElim = dataGridView1.CurrentRow.Cells["codigo_equipo"].Value.ToString();
                CN_Equipo equipo = new CN_Equipo();
                try
                {
                    equipo.Eliminar(idEquipoElim);
                    llenarTabla();
                    MessageBox.Show("El registro ha sido eliminado correctamente");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error:" + ex);
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione una fila");
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                CN_Equipo cnEquipo = new CN_Equipo();
                String nombreSala = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
                String descripcion = dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();
                String codEquipo = dataGridView1.CurrentRow.Cells["codigo_equipo"].Value.ToString();
                int index = comboBox1.FindStringExact(nombreSala);
                comboBox1.SelectedIndex = index;
                richTextBox1.Text = descripcion;
                panelForm.Show();
                
                this.Size = new Size(394, 507);
                editSala = true;
                codEdir = codEquipo;
            }
            else
            {
                MessageBox.Show("Por favor seleccione una fila");
            }

        }


        private void llenarTabla()
        {
            CN_Equipo equipo = new CN_Equipo();
            DataTable equipos = new DataTable();
            equipos = equipo.equipos();
            dataGridView1.DataSource = equipos;
            DataGridViewColumn columnId = dataGridView1.Columns[0];
            columnId.Visible = false;
            List<string> salasList = new List<string>();
            salasList = equipo.listaSalas();
            comboBox1.DataSource = salasList;
            dataGridView1.Columns[1].HeaderText = "Descripción";
            dataGridView1.Columns[2].HeaderText = "Sala";

        }


        private void addSala()
        {
            String descripcion = richTextBox1.Text;
            String nombreSala = comboBox1.Text;

            CN_Equipo equipo = new CN_Equipo();
            DataTable equipos = new DataTable();
            equipos = equipo.sala(nombreSala);
            DataRow fila = equipos.Rows[0];
            String idSala = fila["idSalaInformatica"].ToString();
            equipo.insertarEquipo(descripcion, idSala);
            llenarTabla();
            MessageBox.Show("Se agrego correctamente la sala");
        }

        private void updateSala()
        {
            CN_Equipo equipo = new CN_Equipo();
            DataTable equipos = new DataTable();
            String descripcion = richTextBox1.Text;
            String nombreSala = comboBox1.Text;
            equipos = equipo.sala(nombreSala);
            DataRow fila = equipos.Rows[0];
            
            String idSala = fila["idSalaInformatica"].ToString();
            equipo.Editar(descripcion, codEdir, idSala);
            llenarTabla();
            MessageBox.Show("Se agrego correctamente la sala");
            panelForm.Show();
            this.Size = new Size(394, 366);
            editSala = false;
            codEdir = null;

        }

        

    }
}
