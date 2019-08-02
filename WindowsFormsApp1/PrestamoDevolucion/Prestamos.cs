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
        

        private void comboBoxSalas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CN_PrestamoDev prestamoDev = new CN_PrestamoDev();
            List<string> equiposList = new List<string>();

            String idSalainf = idSala(comboBoxSalas.Text);
            equiposList = prestamoDev.listaEquipos(idSalainf);
            comboBoxEquipos.DataSource = equiposList;
            comboBoxEquipos.DropDownStyle = ComboBoxStyle.DropDownList;
            
        }

        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String nombreSala = comboBoxSalas.Text;
            String nombreEquipo = comboBoxEquipos.Text;
            String codigo = textBoxCodigo.Text;
            if (nombreEquipo=="")
            {
                MessageBox.Show("No existen equipos disponibles para la sala seleccionada");
            }
            else
            {
                CN_Usuario ob_user = new CN_Usuario();
                DataTable user = ob_user.ConsultarUsuarioCodPres(codigo);
                if (user.Rows.Count > 0)
                {
                    CN_Equipo cN_Equipo = new CN_Equipo();
                    DataTable equipo = new DataTable();
                    equipo = cN_Equipo.equipo(nombreEquipo, nombreSala);
                    String idUser = user.Rows[0]["idusuario"].ToString();
                    String codEquipo = equipo.Rows[0]["codigo_equipo"].ToString();
                    CN_PrestamoDev prestamo = new CN_PrestamoDev();

                    prestamo.prestamo(idUser, codEquipo);
                    MessageBox.Show("Prestamo exitoso");
                    llenarTabla();
                }
                else
                {
                    MessageBox.Show("Error al realizar el prestamo, por favor verifique que el código del usuario sea el correcto o que no tenga un prestamo activo");
                }
            }

            
        }

        private void buttonDevolver_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                String codigoEquipoDev=  dataGridView1.CurrentRow.Cells["codigo_equipo"].Value.ToString();
                String idUserDev=  dataGridView1.CurrentRow.Cells["idusuario"].Value.ToString();
                CN_PrestamoDev prestamoDev = new CN_PrestamoDev();
                prestamoDev.Editar(idUserDev, codigoEquipoDev);
                llenarTabla();
                MessageBox.Show("Equipo devuelto correctamente");
            }
            else
            {
                MessageBox.Show("Por favor seleccione un prestamo de la lista");
            }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            CN_PrestamoDev prestamoDev = new CN_PrestamoDev();
            DataTable prestamos = new DataTable();
            String codUser=textBoxCodUserF.Text;
            if (codUser!="")
            {
                prestamos = prestamoDev.prestamosUser(codUser);
                if (prestamos.Rows.Count>0)
                {
                    dataGridView1.DataSource = prestamos;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    List<string> salasList = new List<string>();
                    salasList = prestamoDev.listaSalas();
                    comboBoxSalas.DataSource = salasList;
                    comboBoxSalas.DropDownStyle = ComboBoxStyle.DropDownList;

                }
                else
                {
                    MessageBox.Show("El usuario ingresado no cuenta con prestamos activos");
                }
                
            }
            else
            {
                MessageBox.Show("Ingrese un codigo valido");
            }
            
        }

        private void llenarTabla()
        {
            CN_PrestamoDev prestamoDev = new CN_PrestamoDev();
            DataTable prestamos = new DataTable();
            prestamos = prestamoDev.prestamosActivos();
            dataGridView1.DataSource = prestamos;
            dataGridView1.Columns[0].Visible=false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            List<string> salasList = new List<string>();
            salasList = prestamoDev.listaSalas();
            comboBoxSalas.DataSource = salasList;
            comboBoxSalas.DropDownStyle = ComboBoxStyle.DropDownList;

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

        private void buttonRefreshT_Click(object sender, EventArgs e)
        {
            llenarTabla();
        }

        
    }
}
