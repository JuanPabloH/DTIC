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
    public class CD_Salas
    {

        private ConSQL conexion = new ConSQL();


        MySqlCommand comando = new MySqlCommand();

        public DataTable MostrarSalas()
        {
            MySqlDataReader leer;
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "SELECT * FROM salainformatica";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            comando.Connection = conexion.cerrarConexion();
            return tabla;
        }
        public void InsertarSalas(String nombre, String Ubicacion)
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "INSERT INTO salainformatica (nombre,ubicacion) VALUES('"+nombre+"','"+Ubicacion+"')";
            comando.CommandType = CommandType.Text;
            comando.ExecuteNonQuery();
            comando.Connection = conexion.cerrarConexion();
            //conexion.cerrarConexion();

        }

        public DataTable ConsultaSala(String nombre)
        {
            MySqlDataReader leer;
            DataTable usuario = new DataTable();
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "select * from salainformatica where nombre like '%" + nombre + "%'";
            leer = comando.ExecuteReader();
            usuario.Load(leer);
            comando.Connection = conexion.cerrarConexion();
            return usuario;


        }
        public String cantEquipos(int idSala)
        {
            
            
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "select count(*) from equipoComputo where idsalainformatica=" + idSala + "";
            
            String res = Convert.ToString(comando.ExecuteScalar());
            comando.Connection = conexion.cerrarConexion();
            return res;


        }


        public void Editar(String nombre,String ubicacion,int idSala)
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "UPDATE salainformatica SET nombre='"+nombre+"',ubicacion='"+ubicacion+ "' where idSalaInformatica=" + idSala + "";
            comando.CommandType = CommandType.Text;
            comando.ExecuteNonQuery();
            comando.Connection = conexion.cerrarConexion();
        }
        public void Eliminar(int idSala)
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "DELETE FROM equipocomputo WHERE idSalaInformatica=" + idSala + "";
            comando.CommandType = CommandType.Text;
            comando.ExecuteNonQuery();
            comando.CommandText = "DELETE FROM salainformatica WHERE idSalaInformatica=" + idSala + "";
            comando.CommandType = CommandType.Text;
            comando.ExecuteNonQuery();
            
            comando.Connection = conexion.cerrarConexion();
        }
    }
}
