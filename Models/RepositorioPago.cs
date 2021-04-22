using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_InmobiliariaVaras.Models
{
    public class RepositorioPago : RepositorioBase
    {
        public RepositorioPago(IConfiguration configuration) : base(configuration)
        {

        }
        public List<Pago> ObtenerTodos()
        {
            List<Pago> res = new List<Pago>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdPago, NumeroPago, FechaPago, Importe, IdContrato, c.Importe, c.IdInmueble, c.IdInquilino" +
                    $"FROM Pago p INNER JOIN Contrato c ON p.IdContrato = c.IdContrato";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {

                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Pago p = new Pago
                        {
                            IdPago = reader.GetInt32(0),
                            NumeroPago = reader.GetInt32(1),
                            FechaPago = reader.GetDateTime(2),
                            Importe = reader.GetDecimal(3),
                            IdContrato = reader.GetInt32(4),
                            Contrato = new Contrato
                            {
                                IdContrato = reader.GetInt32(4),
                                Importe = reader.GetInt32(5),
                                IdInmueble = reader.GetInt32(6),
                                IdInquilino = reader.GetInt32(7),

                            }

                        };
                        res.Add(p);
                    }
                    connection.Close();
                }
            }
            return res;
        }
        public int Alta(Pago p)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"INSERT INTO Pago (NumeroPago, FechaPago, Importe, IdContrato) " +
                    "VALUES (@numeroPago, @fechaPago, @importe, @idContrato);" +
                    "SELECT SCOPE_IDENTITY();";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@numeroPago", p.NumeroPago);
                    command.Parameters.AddWithValue("@fechaPago", p.FechaPago);
                    command.Parameters.AddWithValue("@importe", p.Importe);
                    command.Parameters.AddWithValue("@idContrato", p.IdContrato);
                    connection.Open();
                    res = Convert.ToInt32(command.ExecuteScalar());
                    p.IdPago = res;
                    connection.Close();
                }
            }
            return res;
        }
        public Pago ObtenerPorId(int id)
        {
            Pago p = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdPago, NumeroPago, FechaPago, Importe, IdContrato, c.Importe, c.IdInmueble, c.IdInquilino" +
                    $" FROM Pago p INNER JOIN Contrato c ON p.IdContrato = c.IdContrato" +
                    $" WHERE p.IdPago=@id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        p = new Pago
                        {
                            IdPago = reader.GetInt32(0),
                            NumeroPago = reader.GetInt32(1),
                            FechaPago = reader.GetDateTime(2),
                            Importe = reader.GetDecimal(3),
                            IdContrato = reader.GetInt32(4),
                            Contrato = new Contrato
                            {
                                IdContrato = reader.GetInt32(4),
                                Importe = reader.GetInt32(5),
                                IdInmueble = reader.GetInt32(6),
                                IdInquilino = reader.GetInt32(7),
                            }
                        };
                    }
                    connection.Close();
                }
            }
            return p;
        }

        public int Baja(int id)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"DELETE FROM Pago WHERE Idpago = {id}";
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
        public int Modificar(Pago p)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Pago SET " +
                    "NumeroPago=@numeroPago, FechaPago=@fechaPago, Importe=@importe, IdContrato=@idContrato " +
                    "WHERE IdPago = @id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@numeroPago", p.NumeroPago);
                    command.Parameters.AddWithValue("@fechaPago", p.FechaPago);
                    command.Parameters.AddWithValue("@importe", p.Importe);
                    command.Parameters.AddWithValue("@idContrato", p.IdContrato);
                    command.Parameters.AddWithValue("@id", p.IdPago);
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
    
