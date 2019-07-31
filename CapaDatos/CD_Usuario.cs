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
    public class CD_Usuario
    {
        private ConSQL conexion = new ConSQL();
        
        
        MySqlCommand comando = new MySqlCommand();

        public DataTable Mostrar()
        {
            MySqlDataReader leer;
            DataTable tabla = new DataTable();
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "SELECT IDUSUARIO,CODIGO,u.NOMBRE,APELLIDO,CORREO,CONTRASENA,PREGUNTASEG,RESPUESTAPREG,TELEFONO,t.nombre as Tipo from usuario u,tipousuario t where u.idtipousuario=t.idtipousuario and u.idtipousuario!=1";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.cerrarConexion();
            return tabla;
        }
        public void Insertar(int codigo,String nombre,String apellido,String correo,String contraseña,String pregSeg,String repSeg,String telefono,int tipoUser)
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "INSERT INTO USUARIO (codigo,nombre,apellido,correo,contrasena,preguntaSeg,respuestaPreg,telefono,idtipoUsuario) VALUES("+codigo+",'"+nombre+ "','" + apellido + "','" + correo + "','" + contraseña + "','" + pregSeg + "','" + repSeg + "','" + telefono + "'," + tipoUser + ")";
            comando.CommandType = CommandType.Text;
            comando.ExecuteNonQuery();
            comando.Connection = conexion.cerrarConexion();
            //conexion.cerrarConexion();

        }

        public DataTable ConsultaUsuarioCod(int codigo)
        {
            MySqlDataReader leer;
            DataTable usuario = new DataTable();
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "select * from usuario where codigo=" + codigo + "";
            leer = comando.ExecuteReader();
            usuario.Load(leer);
            return usuario;


        }

        public DataTable ConsultaUsuarioCodPrest(int codigo)
        {
            MySqlDataReader leer;
            DataTable usuario = new DataTable();
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "select * from usuario us WHERE us.codigo = "+codigo+" AND NOT EXISTS(SELECT * FROM prestamodevolucion pd WHERE us.idusuario = pd.idusuario and pd.estado = 'PRESTAMO')";
            leer = comando.ExecuteReader();
            usuario.Load(leer);
            return usuario;


        }


        public DataTable ConsultaUsuarioCorreo(String correo)
        {
            MySqlDataReader leer;
            DataTable usuario = new DataTable();
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "select * from usuario where correo='" + correo + "'";
            leer = comando.ExecuteReader();
            usuario.Load(leer);
            return usuario;


        }

        public void Editar(int codigo, String nombre, String apellido, String correo, String contraseña, String pregSeg, String repSeg, String telefono, int tipoUser, int idUsuario)
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "UPDATE USUARIO SET codigo=" + codigo + ",nombre='"+nombre+"',apellido='"+apellido+"',correo='"+correo+"',contrasenia='"+contraseña+"',preguntaSeg='"+pregSeg+"',respuestaPreg='"+repSeg+"',telefono='"+telefono+"',tipoUsuario='"+tipoUser+"' WHERE idUsuario="+idUsuario+"";
            comando.CommandType = CommandType.Text;
            comando.ExecuteNonQuery();
            comando.Connection = conexion.cerrarConexion();
        }
        public void Eliminar(int idUsuario)
        {
            comando.Connection = conexion.abrirConexion();
            comando.CommandText = "DELETE FROM usuario WHERE idUsuario="+idUsuario+"";
            comando.CommandType = CommandType.Text;
            comando.ExecuteNonQuery();
            comando.Connection = conexion.cerrarConexion();
        }
    }
}
