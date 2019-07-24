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
namespace CapaPresentacion.GestionSalas
{
    public partial class Salas : Form
    {
        bool editar = false;
        String idSalaEdit = null;

        public Salas()
        {
            InitializeComponent();
        }

        private void Salas_Load(object sender, EventArgs e)
        {
            llenarTabla();
        }


        private void buttonRefreshT_Click(object sender, EventArgs e)
        {
            llenarTabla();
            textBoxUbicacion.Enabled = false;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            String nombre=textBoxNombre.Text;
            String ubicacion=textBoxUbicacion.Text;
            CN_Salas cnSalas = new CN_Salas();

            if (editar)
            {
                updateSala(cnSalas, nombre, ubicacion);
                editar = false;
                idSalaEdit = null;
            }
            else
            {
                editar = false;
                addSala(cnSalas, nombre, ubicacion);
                panelForm.Hide();
                this.Size = new Size(410, 385);
            }
            
        }
        //Prueba

        private void buttonActiveFormAdd_Click(object sender, EventArgs e)
        {
            panelForm.Show();
            this.Size = new Size(410, 522);
        }


        private void buttonCancelAdd_Click(object sender, EventArgs e)
        {
            editar = false;
            idSalaEdit = null;
            panelForm.Hide();
            this.Size = new Size(410, 385);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            editar = true;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                textBoxNombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
                textBoxUbicacion.Text = dataGridView1.CurrentRow.Cells["ubicacion"].Value.ToString();
                idSalaEdit = dataGridView1.CurrentRow.Cells["idsalainformatica"].Value.ToString();
                panelForm.Show();
                this.Size = new Size(410, 522);
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }
        }


        private void buttonSearch_Click(object sender, EventArgs e)
        {
            String nombre = textBoxNameSearch.Text;
            DataTable sala = new DataTable();
            CN_Salas cnsalas = new CN_Salas();
            sala = cnsalas.ConsultarSala(nombre);
            if (sala.Rows.Count != 0)
            {
                dataGridView1.DataSource = sala;
                textBoxNameSearch.Text = "";
                ocultarColumnas(dataGridView1);

            }
            else
            {
                MessageBox.Show("No existe una sala con los daots ingresados");
            }
        }

        private void llenarTabla()
        {
            CN_Salas cnSalas = new CN_Salas();
            DataTable salas = new DataTable();
            salas = cnSalas.mostrarSalas();
            
            DataColumn columna = new DataColumn();
            salas.Columns.Add("Equipos", typeof(String));
            addColumnCant(salas);
            
            dataGridView1.DataSource = salas;
            ocultarColumnas(dataGridView1);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            

        }
        public void addColumnCant(DataTable salas)
        {
            CN_Salas cnSalas = new CN_Salas();
            foreach (DataRow row in salas.Rows)
            {
                String idSalaa = row["idsalainformatica"].ToString();
                String cant = cnSalas.cantEquipos(idSalaa);
                row[3] = cant;


            }
        }

        public void addSala(CN_Salas cnSalas,String nombre,String ubicacion)
        {
            try
            {
                cnSalas.InsertarSala(nombre, ubicacion);
                MessageBox.Show("La sala ha sido agrgada correctamente");
                llenarTabla();
                limpiarCampos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar la sala, el nombre ya se encuentra registrado");
            }
        }


        public void updateSala(CN_Salas cnSalas, String nombre, String ubicacion)
        {
            try
            {
                cnSalas.Editar(nombre, ubicacion,idSalaEdit);
                llenarTabla();
                MessageBox.Show("La sala ha sido actualizada correctamente");
                limpiarCampos();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la sala, el nombre ya se encuentra registrado");
            }
        }

        public void limpiarCampos()
        {
            textBoxNombre.Text = "";
         
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            editar = true;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if(MessageBox.Show("Recuerde que si elimina la sala se borrarán todos los registros de los equipos pertenecientes","Eliminar registro", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    String idSalaElim = dataGridView1.CurrentRow.Cells["idsalainformatica"].Value.ToString();
                    CN_Salas cnSalas = new CN_Salas();
                    try
                    {
                        cnSalas.Eliminar(idSalaElim);
                        llenarTabla();
                        MessageBox.Show("El registro ha sido eliminado correctamente");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrio un erros:" + ex);
                    }
                }

                
                
                

                
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }
        }

        
        private void ocultarColumnas(DataGridView dataGridView)
        {
            DataGridViewColumn columnId = dataGridView.Columns[0];
            columnId.Visible = false;

            dataGridView1.Columns[1].HeaderText = "Nombre";
            dataGridView1.Columns[2].HeaderText = "Ubicación";
            
        }
    }
}
