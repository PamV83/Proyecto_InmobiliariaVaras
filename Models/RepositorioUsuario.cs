using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_InmobiliariaVaras.Models
{
    public class RepositorioUsuario : RepositorioBase
    {
        public RepositorioUsuario(IConfiguration configuration) : base(configuration)
        {
        }
        public IList<Usuario> ObtenerTodos()
        {
            var res = new List<Usuario>(); 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdUsuario, Nombre, Apellido, Email, Clave, Rol, Avatar" +
                    $" FROM Usuario WHERE estado = 1"; 
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Usuario e = new Usuario
                        {
                            IdUsuario = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Email = reader.GetString(3),
                            Clave = reader.GetString(4),
                            Rol = reader.GetInt32(5),
                            Avatar = reader.GetString(6),

                        };
                        res.Add(e);
                    }
                    connection.Close();
                }
            }
            return res;
        }
        public int Alta(Usuario e)
        {
            string avatarDefault = "/img/default.jpg";
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"INSERT INTO Usuario (Nombre, Apellido, Email, Clave, Rol, Avatar) " +
                    $"VALUES (@nombre, @apellido, @email, @clave, @rol)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@nombre", e.Nombre);
                    command.Parameters.AddWithValue("@apellido", e.Apellido);
                    command.Parameters.AddWithValue("@email", e.Email);
                    command.Parameters.AddWithValue("@clave", e.Clave);
                    command.Parameters.AddWithValue("@rol", e.Rol);
                    if (String.IsNullOrEmpty(e.Avatar))
                        command.Parameters.AddWithValue("@avatar", avatarDefault);
                    else
                        command.Parameters.AddWithValue("@avatar", e.Avatar);

                    connection.Open();
                    res = Convert.ToInt32(command.ExecuteScalar());
                    e.IdUsuario = res;
                    connection.Close();
                }
                string sql_ID = $"SELECT MAX(id) AS id FROM Usuario";

                using (var command = new SqlCommand(sql_ID, connection))
                {
                    connection.Open();
                    res = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                }
            }
            return res;
        }
        public Usuario ObtenerPorId(int id)
        {
            Usuario e = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdUsuario, Nombre, Apellido, Email, Clave, Rol, Avatar FROM Usuario" +
                    $" WHERE IdUsuario=@id AND estado = -1";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        e = new Usuario
                        {
                            IdUsuario = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Email = reader.GetString(3),
                            Clave = reader.GetString(4),
                            Rol = reader.GetInt32(5),
                            Avatar = reader.GetString(6),

                        };
                        return e;
                    }
                    connection.Close();
                }
            }
            return e;
        }
        public Usuario ObtenerPorEmail(string email)
        {
            Usuario e = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdUsuario, Nombre, Apellido, Email, Clave, Rol, Avatar FROM Usuario" +
                    $" WHERE Email=@email";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        e = new Usuario

                        {
                            IdUsuario = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Email = reader.GetString(3),
                            Clave = reader.GetString(4),
                            Rol = reader.GetInt32(5),
                            Avatar = reader.GetString(6),
                        };
                        return e;
                    }
                    connection.Close();
                }
            }
            return e;
        }
        public int Baja(int id)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"DELETE FROM Usuario WHERE IdUsuario = @id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return res;
        }
        public int Modificar(Usuario e)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"UPDATE Usuario SET Nombre=@nombre, Apellido=@apellido, Rol=@rol, Avatar=@avatar " +
                    $"WHERE IdUsuario = @id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@nombre", e.Nombre);
                    command.Parameters.AddWithValue("@apellido", e.Apellido);
                    command.Parameters.AddWithValue("@rol", e.Rol);
                    command.Parameters.AddWithValue("@avatar", e.Avatar);
                    command.Parameters.AddWithValue("@id", e.IdUsuario);
                    

                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return res;
        }
        public int ModificarPass(Usuario e)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"UPDATE Usuarios SET Clave=@clave " +
                    $"WHERE Id = @id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("@clave", e.Clave);
                    command.Parameters.AddWithValue("@id", e.IdUsuario);
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return res;
        }
    }
}
