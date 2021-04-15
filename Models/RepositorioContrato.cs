using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_InmobiliariaVaras.Models
{
    public class RepositorioContrato : RepositorioBase
    {
        public RepositorioContrato(IConfiguration configuration) : base(configuration)
        {

        }
        public IList<Contrato> ObtenerTodos()
        {
            IList<Contrato> res = new List<Contrato>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT IdContrato, FechaIn, FechaFin, Importe, IdInquilino, IdInmueble, i.Nombre, i.Apellido, n.Direccion, n.PropietarioId " +
                    " FROM Contrato c INNER JOIN Inquilino i ON c.IdInquilino = i.IdInquilino INNER JOIN Inmueble n ON c.IdInmueble = n.IdInmueble";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Contrato c = new Contrato
                        {
                            IdContrato = reader.GetInt32(0),
                            FechaIn = reader.GetDateTime(1),
                            FechaFin = reader.GetDateTime(2),
                            Importe = reader.GetInt32(3),
                            IdInquilino = reader.GetInt32(4),
                            IdInmueble = reader.GetInt32(5),

                            Inquilino = new Inquilino
                            {
                                Nombre = reader.GetString(6),
                                Apellido = reader.GetString(7),
                            },

                            Inmueble = new Inmueble
                            {
                                DireccionInmueble = reader.GetString(8),
                                IdPropietario = reader.GetInt32(9),
                            }
                        };
                        res.Add(c);
                    }
                    connection.Close();
                }
            }
            return res;
        }
        public int Alta(Contrato c)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"INSERT INTO Contrato (FechaIn, FechaFin, Importe, IdInquilino, IdInmueble)" +
                             "VALUES ( @fechain, @fechafin, @importe, @idinquilino, @idinmueble);" +
                             "SELECT SCOPE_IDENTITY();";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@fechain", c.FechaIn);
                    command.Parameters.AddWithValue("@fechafin", c.FechaFin);
                    command.Parameters.AddWithValue("@importe", c.Importe);
                    command.Parameters.AddWithValue("@idinquilino", c.IdInquilino);
                    command.Parameters.AddWithValue("@idinmueble", c.IdInmueble);
                    connection.Open();
                    res = Convert.ToInt32(command.ExecuteScalar());
                    c.IdContrato = res;
                    connection.Close();
                }
            }
            return res;
        }
        public Contrato ObtenerPorId(int id)
        {
            Contrato c = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdContrato, FechaIn, FechaFin, Importe, IdInquilino, IdInmueble, i.Nombre, i.Apellido, n.Direccion, n.IdPropietario " +
                    " FROM Contrato c INNER JOIN Inquilino i ON c.IdInquilino = i.IdInquilino INNER JOIN Inmueble n ON c.IdInmueble = n.IdInmueble" +
                    $" WHERE IdContrato=@id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        c = new Contrato
                        {
                            IdContrato = reader.GetInt32(0),
                            FechaIn = reader.GetDateTime(1),
                            FechaFin = reader.GetDateTime(2),
                            Importe = reader.GetInt32(3),
                            IdInquilino = reader.GetInt32(4),
                            IdInmueble = reader.GetInt32(5),

                            Inquilino = new Inquilino
                            {
                                Nombre = reader.GetString(6),
                                Apellido = reader.GetString(7),
                            },
                            Inmueble = new Inmueble
                            {
                                DireccionInmueble = reader.GetString(8),
                                IdPropietario = reader.GetInt32(9),

                            }

                        };

                    }
                    connection.Close();
                }
            }
            return c;
        }
        public int Baja(int id)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"DELETE FROM Contrato WHERE IdContrato = {id}";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return res;
        }

        public int Modificar(Contrato c)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Contrato SET " +
                     "FechaIn = @fechain, FechaFin = @fechafin,  Importe=@importe, IdInquilino= @idinquilino, IdInmueble= @idinmueble " +
                    "WHERE IdContrato = @id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    command.Parameters.AddWithValue("@fechaIn", c.FechaIn);
                    command.Parameters.AddWithValue("@fechaFin", c.FechaFin);
                    command.Parameters.AddWithValue("@importe", c.Importe);
                    command.Parameters.AddWithValue("@idinquilino", c.IdInquilino);
                    command.Parameters.AddWithValue("@idinmueble", c.IdInmueble);
                    command.Parameters.AddWithValue("@id", c.IdContrato);
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return res;
        }
    }
}




