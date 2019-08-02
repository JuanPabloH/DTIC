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
    public class CN_Reporte
    {
        private CD_ReporteActividad OB_Reporte = new CD_ReporteActividad();

       
        public DataTable reporte(String fecha, String nombreSala, String codUser)
        {
            DataTable reporte = new DataTable();
            reporte = OB_Reporte.reporte(fecha,nombreSala,codUser);
            return reporte;
        }



       
    }
}
