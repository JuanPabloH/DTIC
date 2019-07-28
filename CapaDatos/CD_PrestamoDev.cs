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
     public class CD_PrestamoDev
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

        public List<string> listaEquipos(int idSala)
        {
            MySqlDataReader leer;

            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "SELECT descripcion FROM equipocomputo eq WHERE IDSALAINFORMATICA = " + idSala+" AND (NOT EXISTS(SELECT * FROM prestamodevolucion pd WHERE eq.CODIGO_EQUIPO = pd.CODIGO_EQUIPO AND pd.ESTADO = 'PRESTAMO') OR EXISTS(SELECT * FROM prestamodevolucion pd WHERE eq.CODIGO_EQUIPO = pd.CODIGO_EQUIPO AND pd.ESTADO = 'DEVUELTO'))";
            leer = comando.ExecuteReader();
            List<string> salas = new List<string>();
            while (leer.Read())
            {
                salas.Add(Convert.ToString(leer["descripcion"]));
            }
            return salas;

        }
       
        public DataTable PrestamosActivos()
        {
            MySqlDataReader leer;
            DataTable prestamos = new DataTable();
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "SELECT us.NOMBRE, us.APELLIDO, sa.NOMBRE from prestamodevolucion pd inner join usuario us on pd.IDUSUARIO=us.IDUSUARIO inner join equipocomputo eq on pd.CODIGO_EQUIPO=eq.CODIGO_EQUIPO inner join salainformatica sa on sa.IDSALAINFORMATICA=eq.IDSALAINFORMATICA where pd.ESTADO='PRESTAMO'";
            leer = comando.ExecuteReader();
            prestamos.Load(leer);
            return prestamos;


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

       
        


        public void Editar(String descripcion, int idEquipo, int idSala)
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "UPDATE equipocomputo SET descripcion='" + descripcion + "', idsalainformatica=" + idSala + " where codigo_equipo= " + idEquipo + "";
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
