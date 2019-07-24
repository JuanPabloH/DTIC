using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;
namespace CapaNegocio
{
    public class CN_Salas
    {
        private CD_Salas salas = new CD_Salas();

        public DataTable mostrarSalas()
        {
            DataTable tabla = new DataTable();
            tabla = salas.MostrarSalas();
            return tabla;
        }

        public void InsertarSala(String nombre,String ubicacion)
        {
            salas.InsertarSalas(nombre,ubicacion);
            
        }
        public DataTable ConsultarSala(String nombre)
        {
            DataTable sala = new DataTable();
            sala = salas.ConsultaSala(nombre);
            return sala;
        }
        public String cantEquipos(String idSala)
        {
            String cant;
            cant = salas.cantEquipos(Convert.ToInt32(idSala));
            return cant;
        }

        

        public void Editar(String nombre,String ubicacion,String idSala)
        {

            salas.Editar(nombre, ubicacion,Convert.ToInt32(idSala));
        }

        public void Eliminar(String idSala)
        {
            salas.Eliminar(Convert.ToInt32(idSala));
        }
    }
}
