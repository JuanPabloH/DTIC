using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_Login
    {

        private ConSQL conexion = new ConSQL();
        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();

        public DataTable CargarUser(String email, String password)
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "SELECT codigo,nombre,apellido, telefono, idtipoUsuario FROM usuario where correo='"+email+"' and contrasena='"+password+"'";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.cerrarConexion();
            return tabla;
        }
    }
}
