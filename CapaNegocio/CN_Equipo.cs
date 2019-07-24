using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class CN_Equipo
    {
        private CD_Equipo OB_Equipo = new CD_Equipo();

        public List<string> listaSalas()
        {
            List<string> salas = new List<string>();
            salas = OB_Equipo.listaSalas();
            return salas;
        }

        public void insertarEquipo(String descripcion, String idSala)
        {
            OB_Equipo.insertarEquipo(descripcion, Convert.ToInt32(idSala));

        }
        public DataTable equipos()
        {
            DataTable equipos = new DataTable();
            equipos = OB_Equipo.Equipos();
            return equipos;
        }



        public void Editar(String descripcion, String idEquipo,String idSala)
        {

            OB_Equipo.Editar(descripcion, Convert.ToInt32(idEquipo),Convert.ToInt32(idSala));
        }

        public void Eliminar(String idEquipo)
        {
            OB_Equipo.Eliminar(Convert.ToInt32(idEquipo));
        }

        public DataTable sala(String nombreSala)
        {
            DataTable sala = new DataTable();
            sala = OB_Equipo.Salas(nombreSala);

            return sala;
        }
    }
}
