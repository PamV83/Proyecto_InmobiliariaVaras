using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_InmobiliariaVaras.Models
{
	public class RepositorioInquilino : RepositorioBase
	{
		public RepositorioInquilino(IConfiguration configuration) : base(configuration)
		{

		}

		public IList<Inquilino> ObtenerTodos()
		{
			IList<Inquilino> res = new List<Inquilino>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT Id, Dni, Nombre, Apellido, DomicilioLaboral, Email, TelefonoInquilino, NombreGarante, DniGarante, TelefonoGarante " +
					$" FROM Inquilino";

				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						Inquilino i = new Inquilino
						{
							Id = reader.GetInt32(0),
							Dni = reader.GetString(1),
							Nombre = reader.GetString(2),
							Apellido = reader.GetString(3),
							DomicilioLaboral = reader.GetString(4),
							Email = reader.GetString(5),
							TelefonoInquilino = reader.GetString(6),
							NombreGarante = reader.GetString(7),
							DniGarante = reader.GetString(8),
							TelefonoGarante = reader.GetString(9),

						};
						res.Add(i);
					}
					connection.Close();
				}
			}
			return res;
		}

		public int Alta(Inquilino i)
		{
			int res = -1;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"INSERT INTO Inquilino (Dni, Nombre, Apellido, DomicilioLaboral, Email, TelefonoInquilino, NombreGarante, DniGarante, TelefonoGarante ) " +
					$"VALUES (@dni, @nombre, @apellido, @domiciliolaboral, @email, @telefonoinquilino, @nombregarante, @dnigarante, @telefonogarante )";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					command.Parameters.AddWithValue("@dni", i.Dni);
					command.Parameters.AddWithValue("@nombre", i.Nombre);
					command.Parameters.AddWithValue("@apellido", i.Apellido);
					command.Parameters.AddWithValue("@domiciliolaboral", i.DomicilioLaboral);
					command.Parameters.AddWithValue("@email", i.Email);
					command.Parameters.AddWithValue("@telefonoinquilino", i.TelefonoInquilino);
					command.Parameters.AddWithValue("@nombregarante", i.NombreGarante);
					command.Parameters.AddWithValue("@dnigarante", i.DniGarante);
					command.Parameters.AddWithValue("@telefonogarante", i.TelefonoGarante);


					connection.Open();
					res = Convert.ToInt32(command.ExecuteScalar());
					i.Id = res;
					connection.Close();
				}
			}
			return res;
		}
		public int Baja(int id)
		{
			int res = -1;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"DELETE FROM Inquilino WHERE Id = @id";
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
		public Inquilino ObtenerPorId(int id)
		{

			Inquilino i = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT Id, Dni, Nombre, Apellido, DomicilioLaboral, Email, TelefonoInquilino, NombreGarante, DniGarante, TelefonoGarante FROM Inquilino" +
					$" WHERE Id=@id";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{ 
					command.Parameters.Add("@id", SqlDbType.Int).Value = id;
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					if (reader.Read())
					{
						i = new Inquilino
						{
							Id = reader.GetInt32(0),
							Dni = reader.GetString(1),
							Nombre = reader.GetString(2),
							Apellido = reader.GetString(3),
							DomicilioLaboral = reader.GetString(4),
							Email = reader.GetString(5),
							TelefonoInquilino = reader.GetString(6),
							NombreGarante = reader.GetString(7),
							DniGarante = reader.GetString(8),
							TelefonoGarante = reader.GetString(9),

						};
					}
					connection.Close();
				}
			}
			return i;
		}
		public int Modificar(Inquilino i)
		{
			int res = -1;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"UPDATE Inquilino SET Dni=@dni, Nombre=@nombre, Apellido=@apellido, DomicilioLaboral=@domiciliolaboral, Email=@email, TelefonoInquilino=@telefonoinquilino, NombreGarante=@nombregarante, DniGarante=@dnigarante, TelefonoGarante=@telefonogarante " +
					$"WHERE Id = @id";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					command.Parameters.AddWithValue("@dni", i.Dni);
					command.Parameters.AddWithValue("@nombre", i.Nombre);
					command.Parameters.AddWithValue("@apellido", i.Apellido);
					command.Parameters.AddWithValue("@domiciliolaboral", i.DomicilioLaboral);
					command.Parameters.AddWithValue("@email", i.Email);
					command.Parameters.AddWithValue("@telefonoinquilino", i.TelefonoInquilino);
					command.Parameters.AddWithValue("@nombregarante", i.NombreGarante);
					command.Parameters.AddWithValue("@dnigarante", i.DniGarante);
					command.Parameters.AddWithValue("@telefonogarante", i.TelefonoGarante);
					command.Parameters.AddWithValue("@id", i.Id);

					connection.Open();
					res = command.ExecuteNonQuery();
					connection.Close();
				}
			}
			return res;
		}

	}
}

