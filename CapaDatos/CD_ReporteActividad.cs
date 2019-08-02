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

    
    public class CD_ReporteActividad
    {
        private ConSQL conexion = new ConSQL();


        MySqlCommand comando = new MySqlCommand();

        public DataTable reporte(String fecha, String nombreSala,String codUser)
        {
            MySqlDataReader leer;
            DataTable reporte = new DataTable();
            comando.Connection = conexion.abrirConexion();
            if (codUser == "")
            {
                comando.CommandText = "SELECT us.NOMBRE,us.APELLIDO ,si.NOMBRE as Sala, pd.ESTADO,pd.HORAPRESTAMO,pd.HORADEVOLUCION FROM prestamodevolucion pd inner JOIN usuario us on pd.IDUSUARIO = us.IDUSUARIO inner JOIN equipocomputo ec on ec.CODIGO_EQUIPO = pd.CODIGO_EQUIPO inner JOIN salainformatica si on si.IDSALAINFORMATICA = ec.IDSALAINFORMATICA WHERE date(HORAPRESTAMO)= '" + fecha + "' AND si.NOMBRE = '" + nombreSala + "'";
            }
            else
            {
                comando.CommandText = "SELECT us.NOMBRE,us.APELLIDO ,si.NOMBRE as Sala, pd.ESTADO,pd.HORAPRESTAMO,pd.HORADEVOLUCION FROM prestamodevolucion pd inner JOIN usuario us on pd.IDUSUARIO = us.IDUSUARIO inner JOIN equipocomputo ec on ec.CODIGO_EQUIPO = pd.CODIGO_EQUIPO inner JOIN salainformatica si on si.IDSALAINFORMATICA = ec.IDSALAINFORMATICA WHERE date(HORAPRESTAMO)= '" + fecha + "' AND si.NOMBRE = '" + nombreSala + "' AND us.codigo='"+codUser+"'";
            }
            
            leer = comando.ExecuteReader();
            reporte.Load(leer);
            return reporte;


        }
    }
}
