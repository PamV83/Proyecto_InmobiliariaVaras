using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_InmobiliariaVaras.Models
{
	public class RepositorioInmueble : RepositorioBase
	{
		public RepositorioInmueble(IConfiguration configuration) : base(configuration)
		{

		}
		public IList<Inmueble> ObtenerTodos()
		{
			IList<Inmueble> res = new List<Inmueble>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT i.IdInmueble, i.DireccionInmueble, i.Ambientes, i.Superficie, i.Tipo, i.Precio, i.IdPropietario, p.Nombre " +
					$"FROM inmueble i INNER JOIN Propietario p ON i.IdPropietario = p.id";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						Inmueble e = new Inmueble
						{
							IdInmueble = reader.GetInt32(0),
							DireccionInmueble = reader.GetString(1),
							Ambientes = reader.GetInt32(2),
							Superficie = reader.GetInt32(3),
							Tipo = reader.GetString(4),
							Precio = reader.GetInt32(5),
							IdPropietario = reader.GetInt32(6),
							Duenio = new Propietario
							{
								Id = reader.GetInt32(6),
								Nombre = reader.GetString(7)

							}

						};
						res.Add(e);
					}
					connection.Close();
				}

			}
			return res;
		}
		public int Alta(Inmueble e)
		{
			int res = -1;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"INSERT INTO Inmueble (DireccionInmueble, Ambientes, Superficie, Tipo, Precio, IdPropietario) " +
					$"VALUES (@direccioninmueble, @ambientes, @superficie, @tipo, @precio, @idpropietario)";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					command.Parameters.AddWithValue("@direccioninmueble", e.DireccionInmueble);
					command.Parameters.AddWithValue("@ambientes", e.Ambientes);
					command.Parameters.AddWithValue("@superficie", e.Superficie);
					command.Parameters.AddWithValue("@tipo", e.Tipo);
					command.Parameters.AddWithValue("@precio", e.Precio);
					command.Parameters.AddWithValue("@idpropietario", e.IdPropietario);

					connection.Open();
					res = Convert.ToInt32(command.ExecuteScalar());
					e.IdInmueble = res;
					connection.Close();
				}
			}
			return res;
		}

			public Inmueble ObtenerPorId(int id)
		{
			Inmueble e = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdInmueble, DireccionInmueble, Ambientes, Superficie, Tipo, Precio, IdPropietario FROM inmueble" +
					$" WHERE IdInmueble=@id";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.Add("@id", SqlDbType.Int).Value = id;
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					if (reader.Read())
					{
						e = new Inmueble
						{
							IdInmueble = reader.GetInt32(0),
							DireccionInmueble = reader.GetString(1),
							Ambientes = reader.GetInt32(2),
							Superficie = reader.GetInt32(3),
							Tipo = reader.GetString(4),
							Precio = reader.GetInt32(5),
							IdPropietario = reader.GetInt32(6),
							
                          };

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
				string sql = $"DELETE FROM Inmuebles WHERE Id = {id}";
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

		public int Modificar(Inmueble e)
		{
			var res = -1;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = "UPDATE Inmueble SET " +
					"DireccionInmueble=@direccioninmueble, Ambientes=@ambientes, Superficie=@superficie, Tipo=@tipo, Precio=@precio " +
					"WHERE IdInmueble = @IdInmueble";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.AddWithValue("@direccioninmueble", e.DireccionInmueble);
					command.Parameters.AddWithValue("@ambientes", e.Ambientes);
					command.Parameters.AddWithValue("@superficie", e.Superficie);
					command.Parameters.AddWithValue("@tipo", e.Tipo);
					command.Parameters.AddWithValue("@precio", e.Precio);
					command.Parameters.AddWithValue("@idinmueble", e.IdInmueble);
				

					connection.Open();
					res = command.ExecuteNonQuery();
					connection.Close();
				}
			}
			return res;
		}
	}
}
	