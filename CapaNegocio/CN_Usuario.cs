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
    public class CN_Usuario
    {
        private CD_Usuario usuarios = new CD_Usuario();

        public DataTable mostrarUsuario()
        {
            DataTable tabla = new DataTable();
            tabla = usuarios.Mostrar();
            return tabla;
        }

        public void Insertar(String codigo, String nombre, String apellido, String correo, String contraseña, String pregSeg, String repSeg, String telefono, String tipoUser)
        {

            usuarios.Insertar(Convert.ToInt32(codigo), nombre, apellido, correo, contraseña, pregSeg, repSeg, telefono, Convert.ToInt32(tipoUser));
        }
        public DataTable ConsultarUsuarioCod(String codigo)
        {
            DataTable user = new DataTable();
            user = usuarios.ConsultaUsuarioCod(Convert.ToInt32(codigo));
            return user;
        }
        public DataTable ConsultarUsuarioCodPres(String codigo)
        {
            DataTable user = new DataTable();
            user = usuarios.ConsultaUsuarioCodPrest(Convert.ToInt32(codigo));
            return user;
        }

        public DataTable ConsultarUsuarioCorreo(String correo)
        {
            DataTable user = new DataTable();
            user = usuarios.ConsultaUsuarioCorreo(correo);
            return user;
        }

        public void Editar(String codigo, String nombre, String apellido, String correo, String contraseña, String pregSeg, String repSeg, String telefono, String tipoUser,String idUser)
        {

            usuarios.Editar(Convert.ToInt32(codigo), nombre, apellido, correo, contraseña, pregSeg, repSeg, telefono, Convert.ToInt32(tipoUser),Convert.ToInt32(idUser));
        }

        public void Eliminar(String idUsuario)
        {
            usuarios.Eliminar(Convert.ToInt32(idUsuario));
        }
    }
}
