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
    public class CN_PrestamoDev
    {
        private CD_PrestamoDev OB_PresDev = new CD_PrestamoDev();

        public List<string> listaSalas()
        {
            List<string> salas = new List<string>();
            salas = OB_PresDev.listaSalas();
            return salas;
        }

        public List<string> listaEquipos(String idSala)
        {
            List<string> equipos = new List<string>();
            equipos = OB_PresDev.listaEquipos(Convert.ToInt32(idSala));
            return equipos;
        }

        public DataTable prestamosActivos()
        {
            DataTable prestamos = new DataTable();
            prestamos = OB_PresDev.PrestamosActivos();
            return prestamos;
        }
        public void prestamo(String idUser,String idEquipo)
        {
            DateTime horaIngreso = DateTime.Now;
            String hora=horaIngreso.ToString("yyyy-MM-dd H:mm:ss");
            OB_PresDev.insertarPrestamo(Convert.ToInt32(idUser),Convert.ToInt32(idEquipo),hora);
        }




    }
}
