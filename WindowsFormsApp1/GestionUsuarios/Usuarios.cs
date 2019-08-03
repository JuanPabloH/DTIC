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
namespace WindowsFormsApp1.GestionUsuarios
{
    public partial class Usuarios : Form
    {
        bool editar = false;
        String codEdit = "";
        String idEdit = "";
        String corrEdit = "";
        
        
        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            comboBoxTipoUser.SelectedIndex=0;
            comboBoxPSeg.SelectedIndex = 0;
            CargarUsuarios();
        }
        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable usuario = new DataTable();
            CN_Usuario cnUser = new CN_Usuario();
            if (editar)
            {
                editarUser(usuario, cnUser);
                
            }
            else
            {
                editar = false;
                agregarUser(usuario, cnUser);
                
            }            
        }



        private void buttonCancelAdd_Click(object sender, EventArgs e)
        {
            panelForm.Hide();
            this.Size = new Size(570, 493);
        }

        private void buttonActiveFormAdd_Click(object sender, EventArgs e)
        {
            panelForm.Show();
            this.Size = new Size(895, 493);

        }
        

        private void textBoxContra_Click(object sender, EventArgs e)
        {
            
                textBoxContra.Clear();
                textBoxContra.PasswordChar = '*';
            
        }

        

        private void textBoxContra_Enter(object sender, EventArgs e)
        {
            textBoxContra.Clear();
            textBoxContra.PasswordChar = '*';
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            String codigo = textBoxCodSearch.Text;
            DataTable usuario = new DataTable();
            CN_Usuario cnUser = new CN_Usuario();
            usuario = cnUser.ConsultarUsuarioCod(codigo);
            if (usuario.Rows.Count != 0)
            {
                dataGridView1.DataSource = usuario;
                textBoxCodSearch.Text = "";
                ocultarColumnas(dataGridView1);
            }
            else
            {
                MessageBox.Show("No existe un usuario con el codigo ingresado");
            }
        }

        private void buttonRefreshT_Click(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            editar = true;

            if (dataGridView1.SelectedRows.Count > 0)
            {
                textBoxApellido.Text = dataGridView1.CurrentRow.Cells["apellido"].Value.ToString();
                textBoxNombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
                textBoxCodigo.Text = dataGridView1.CurrentRow.Cells["codigo"].Value.ToString();
                textBoxCorreo.Text = dataGridView1.CurrentRow.Cells["correo"].Value.ToString();
                textBoxRSeg.Text = dataGridView1.CurrentRow.Cells["respuestaPreg"].Value.ToString();
                textBoxTel.Text = dataGridView1.CurrentRow.Cells["telefono"].Value.ToString();
                String tipUser=  dataGridView1.CurrentRow.Cells["tipoUsuario"].Value.ToString();
                textBoxContra.PasswordChar = '*';
                textBoxContra.Text= dataGridView1.CurrentRow.Cells["contrasenia"].Value.ToString();
                textBoxContra.Enabled=false;
                
                codEdit= dataGridView1.CurrentRow.Cells["codigo"].Value.ToString();
                idEdit= dataGridView1.CurrentRow.Cells["idUsuario"].Value.ToString();
                corrEdit= dataGridView1.CurrentRow.Cells["correo"].Value.ToString();
                if (tipUser.Equals("2"))
                {
                    comboBoxTipoUser.SelectedIndex = 0;
                }
                else if(tipUser.Equals("3"))
                {
                    comboBoxTipoUser.SelectedIndex = 1;
                }
                else if (tipUser.Equals("4"))
                {
                    comboBoxTipoUser.SelectedIndex = 2;
                }

                panelForm.Show();
                this.Size = new Size(895, 493);
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            CN_Usuario cnUser = new CN_Usuario();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                String idUsuario = dataGridView1.CurrentRow.Cells["idUsuario"].Value.ToString();
                cnUser.Eliminar(idUsuario);
                MessageBox.Show("Usuario Eliminado correctamente");
                CargarUsuarios();
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }
        }


        private String validarTipoUser(String tU)
        {
            String tipoUser = "";
            if (tU == "Funcionario")
            {
                tipoUser = "2";
            }
            else if (tU == "Becario")
            {
                tipoUser = "3";
            }
            else
            {
                tipoUser = "4";
            }
            return tipoUser;
        }

        private void limpiarCampos()
        {
            textBoxCodigo.Text="";
            textBoxNombre.Text="";
            textBoxApellido.Text = "";
            textBoxCorreo.Text = "";
            textBoxContra.Text = "";
            textBoxTel.Text = "";            
            textBoxRSeg.Text = "";
            
        }

        

        private void CargarUsuarios()
        {
            CN_Usuario cnUser = new CN_Usuario();
            dataGridView1.DataSource = cnUser.mostrarUsuario();
            ocultarColumnas(dataGridView1);

            for(int i=0;i< dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
           

        }

        private void ocultarColumnas(DataGridView dataGridView1)
        {
            DataGridViewColumn columnId = dataGridView1.Columns[0];
            columnId.Visible = false;
            DataGridViewColumn columnContra = dataGridView1.Columns[5];
            columnContra.Visible = false;
            DataGridViewColumn columnPreg = dataGridView1.Columns[6];
            columnPreg.Visible = false;
            DataGridViewColumn columnResp = dataGridView1.Columns[7];
            columnResp.Visible = false;
            
            dataGridView1.Columns[1].HeaderText = "Codigo";
            dataGridView1.Columns[2].HeaderText = "Nombres";
            dataGridView1.Columns[3].HeaderText = "Apellidos";
            dataGridView1.Columns[4].HeaderText = "Correo";
            dataGridView1.Columns[8].HeaderText = "Telefono";
        }
        private void agregarUser(DataTable usuario,CN_Usuario cnUser)
        {
            String codigo = textBoxCodigo.Text;
            String nombre = textBoxNombre.Text;
            String apellido = textBoxApellido.Text;
            String correo = textBoxCorreo.Text;
            String contraseña = textBoxContra.Text;
            String telefono = textBoxTel.Text;
            String pregSEg = comboBoxPSeg.Text;
            String resPreg = textBoxRSeg.Text;
            String tU = comboBoxTipoUser.Text;
            String tipoUser = validarTipoUser(tU);

            usuario = cnUser.ConsultarUsuarioCod(codigo);
            if (usuario.Rows.Count == 0)
            {
                if (tipoUser=="4")
                {
                    cnUser.Insertar(codigo, nombre, apellido, correo, contraseña, pregSEg, resPreg, telefono, tipoUser);
                    MessageBox.Show("Usuario Registrado correctamente");
                    limpiarCampos();
                    CargarUsuarios();
                }
                else
                {
                    if (cnUser.ConsultarUsuarioCorreo(correo).Rows.Count == 0)
                    {
                        cnUser.Insertar(codigo, nombre, apellido, correo, contraseña, pregSEg, resPreg, telefono, tipoUser);
                        MessageBox.Show("Usuario Registrado correctamente");
                        limpiarCampos();
                        CargarUsuarios();
                    }
                    else
                    {
                        MessageBox.Show("El correo que intenta ingresar ya se encuentra registrado");
                    }
                }
                
                
            }
            else
            {
                MessageBox.Show("El codigo que intenta ingresar ya se encuentra registrado");
            }
        }

        private void editarUser(DataTable usuario, CN_Usuario cnUser)
        {
            String codigo = textBoxCodigo.Text;
            String nombre = textBoxNombre.Text;
            String apellido = textBoxApellido.Text;
            String correo = textBoxCorreo.Text;
            String contraseña = textBoxContra.Text;
            String telefono = textBoxTel.Text;
            String pregSEg = comboBoxPSeg.Text;
            String resPreg = textBoxRSeg.Text;
            String tU = comboBoxTipoUser.Text;
            String tipoUser = validarTipoUser(tU);
            if (codEdit.Equals(codigo) && corrEdit.Equals(correo))
            {
                actualizarUser(codigo, nombre, apellido, correo, contraseña, pregSEg, resPreg, telefono, tipoUser, idEdit);
            }
            else if(!(codEdit.Equals(codigo)|corrEdit.Equals(correo)))
            {
                if ((cnUser.ConsultarUsuarioCorreo(correo).Rows.Count == 0))
                {
                    if ((cnUser.ConsultarUsuarioCod(codigo).Rows.Count == 0))
                    {
                        actualizarUser(codigo, nombre, apellido, correo, contraseña, pregSEg, resPreg, telefono, tipoUser, idEdit);
                    }
                    else
                    {
                        MessageBox.Show("El codigo que intenta ingresar ya se encuentra registrado");
                    }
                }
                else
                {
                    MessageBox.Show("El correo que intenta ingresar ya se encuentra registrado");
                }

            }

            
        }

        private void actualizarUser(String codigo,String nombre, String apellido, String correo, String contraseña, String pregSEg, String resPreg, String telefono, String tipoUser, String idEdit)
        {
            CN_Usuario cnUser1 = new CN_Usuario();
            cnUser1.Editar(codigo, nombre, apellido, correo, contraseña, pregSEg, resPreg, telefono, tipoUser, idEdit);
            MessageBox.Show("Usuario Actualizado correctamente");
            limpiarCampos();
            CargarUsuarios();
            idEdit = "";
            codEdit = "";
            editar = false;
        }

        

        private void comboBoxTipoUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipoUser.Text == "Estudiante")
            {
                textBoxContra.Text = "";
                textBoxContra.Enabled = false;
                textBoxCorreo.Text = "";
                textBoxCorreo.Enabled = false;
                textBoxTel.Text = "";
                textBoxTel.Enabled = false;
                textBoxRSeg.Text = "";
                textBoxRSeg.Enabled = false;
                comboBoxPSeg.Enabled = false;
            }
            else
            {
                
                textBoxContra.Enabled = true;
                
                textBoxCorreo.Enabled = true;
                
                textBoxTel.Enabled = true;
                
                textBoxRSeg.Enabled = true;
                comboBoxPSeg.Enabled = true;
            }
        }
    }
}
