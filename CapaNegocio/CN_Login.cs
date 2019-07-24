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
    public class CN_Login
    {

        private CD_Login cd_login = new CD_Login();

        public DataTable mostrarUsuario(String email, String password)
        {
            DataTable tabla = new DataTable();
            tabla = cd_login.CargarUser( email,  password);
            return tabla;
        }
    }
}
