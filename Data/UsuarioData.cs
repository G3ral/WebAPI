using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class UsuarioData
    {
        public static bool Registrar(Usuario oUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombres", oUsuario.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", oUsuario.Apellidos);
                cmd.Parameters.AddWithValue("@DocumentoIdentidad", oUsuario.DocumentoIdentidad);
                cmd.Parameters.AddWithValue("@FechaNacimiento", oUsuario.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Genero", oUsuario.Genero);
                cmd.Parameters.AddWithValue("@Direccion", oUsuario.Direccion);
                cmd.Parameters.AddWithValue("@Departamento", oUsuario.Departamento);
                cmd.Parameters.AddWithValue("@Municipio", oUsuario.Municipio);
                cmd.Parameters.AddWithValue("@Telefono", oUsuario.Telefono);
                cmd.Parameters.AddWithValue("@Correo", oUsuario.Correo);
                cmd.Parameters.AddWithValue("@Tipificacion", oUsuario.Tipificacion);

                try
                {
                    oConexion.Open();
                    //cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public static bool Modificar(Usuario oUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection((Conexion.rutaConexion)))
            {
                SqlCommand cmd = new SqlCommand("usp_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdUsers", oUsuario.IdUsers);
                cmd.Parameters.AddWithValue("@Nombres", oUsuario.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", oUsuario.Apellidos);
                cmd.Parameters.AddWithValue("@DocumentoIdentidad", oUsuario.DocumentoIdentidad);
                cmd.Parameters.AddWithValue("@FechaNacimiento", oUsuario.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Genero", oUsuario.Genero);
                cmd.Parameters.AddWithValue("@Direccion", oUsuario.Direccion);
                cmd.Parameters.AddWithValue("@Departamento", oUsuario.Departamento);
                cmd.Parameters.AddWithValue("@Municipio", oUsuario.Municipio);
                cmd.Parameters.AddWithValue("@Telefono", oUsuario.Telefono);
                cmd.Parameters.AddWithValue("@Correo", oUsuario.Correo);
                cmd.Parameters.AddWithValue("@Tipificacion", oUsuario.Tipificacion);

                try
                {
                    oConexion.Open();
                    //cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<Usuario> Listar()
        {
            List<Usuario> oListaUsuario = new List<Usuario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                   // cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaUsuario.Add(new Usuario()
                            {
                                IdUsers = Convert.ToInt32(dr["IdUsers"]),
                                Nombres = dr["Nombres"].ToString(),
                                Apellidos = dr["Apellidos"].ToString(),
                                DocumentoIdentidad = dr["DocumentoIdentidad"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"].ToString()),
                                Genero = dr["Genero"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                Departamento = dr["Departamento"].ToString(),
                                Municipio = dr["Municipio"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Tipificacion = dr["Tipificacion"].ToString(),
                            });
                        }
                    }
                    return oListaUsuario;
                }
                catch (Exception ex)
                {
                    return oListaUsuario;
                }
            }
        }

        public static Usuario Obtener(int idusuario)
        {
            Usuario oUsuario = new Usuario();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsers", idusuario);

                try
                {
                    oConexion.Open();
                    //cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oUsuario = new Usuario()
                            {
                                IdUsers = Convert.ToInt32(dr["IdUsers"]),
                                Nombres = dr["Nombres"].ToString(),
                                Apellidos = dr["Apellidos"].ToString(),
                                DocumentoIdentidad = dr["DocumentoIdentidad"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"].ToString()),
                                Genero = dr["Genero"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                Departamento = dr["Departamento"].ToString(),
                                Municipio = dr["Municipio"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Tipificacion = dr["Tipificacion"].ToString(),
                            };
                        }

                    }
                    return oUsuario;
                }
                catch (Exception ex)
                {
                    return oUsuario;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsers", id);

                try
                {
                    oConexion.Open();
                    //cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

    }
}