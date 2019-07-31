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
    public class CD_Equipo
    {
        private ConSQL conexion = new ConSQL();


        MySqlCommand comando = new MySqlCommand();

        public List<string> listaSalas()
        {
            MySqlDataReader leer;
            
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "SELECT nombre FROM salainformatica";
            leer = comando.ExecuteReader();
            List<string> salas = new List<string>();
            while (leer.Read())
            {
                salas.Add(Convert.ToString(leer["nombre"]));
            }
            return salas;
            
        }

        public void insertarEquipo(String descripcion, int idSalaInformatica)
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "INSERT INTO equipocomputo (descripcion,idsalainformatica) VALUES('" + descripcion + "'," + idSalaInformatica + ")";
            comando.CommandType = CommandType.Text;
            comando.ExecuteNonQuery();
            comando.Connection = conexion.cerrarConexion();
            //conexion.cerrarConexion();

        }

        public DataTable Equipos()
        {
            MySqlDataReader leer;
            DataTable usuario = new DataTable();
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "SELECT codigo_equipo,descripcion, nombre from equipocomputo e, salainformatica s where e.IDSALAINFORMATICA= s.IDSALAINFORMATICA";
            leer = comando.ExecuteReader();
            usuario.Load(leer);
            return usuario;


        }
        public DataTable Salas(String nombreSala)
        {
            MySqlDataReader leer;
            DataTable usuario = new DataTable();
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "SELECT idSalaInformatica from salainformatica  where nombre= '"+nombreSala+"'";
            leer = comando.ExecuteReader();
            usuario.Load(leer);
            return usuario;


        }
        public DataTable Equipo(String nombreEquipo, String nombreSala)
        {
            MySqlDataReader leer;
            DataTable usuario = new DataTable();
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "SELECT * from equipocomputo eq inner join salainformatica sa on eq.idsalainformatica=sa.idsalainformatica   where eq.descripcion= '" + nombreEquipo + "' and sa.nombre='"+nombreSala+"'";
            leer = comando.ExecuteReader();
            usuario.Load(leer);
            return usuario;


        }


        public void Editar(String descripcion, int idEquipo,int idSala)
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "UPDATE equipocomputo SET descripcion='"+descripcion+"', idsalainformatica="+idSala+" where codigo_equipo= "+idEquipo+"";
            comando.CommandType = CommandType.Text;
            comando.ExecuteNonQuery();
            comando.Connection = conexion.cerrarConexion();
        }
        public void Eliminar(int idEquipo)
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "DELETE FROM equipocomputo WHERE codigo_equipo=" + idEquipo + "";
            comando.CommandType = CommandType.Text;
            comando.ExecuteNonQuery();
            comando.Connection = conexion.cerrarConexion();
        }
    }
}
