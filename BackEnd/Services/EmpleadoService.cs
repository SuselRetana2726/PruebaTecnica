using System.Data;
using Microsoft.Data.SqlClient;
using BackEnd.Models;

namespace BackEnd.Services
{
    public class EmpleadoService
    {
        private readonly string _connectionString;

        public EmpleadoService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection")!;
        }

        private SqlConnection GetConnection() => new(_connectionString);

        public List<Empleado> ObtenerTodos()
        {
            var empleados = new List<Empleado>();

            using var conn = GetConnection();
            using var cmd = new SqlCommand("ObtenerEmpleados", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                empleados.Add(new Empleado
                {
                    Codigo = Convert.ToInt32(reader["Codigo"]),
                    Puesto = reader["Puesto"].ToString()!,
                    Nombre = reader["Nombre"].ToString()!,
                    CodigoJefe = reader["CodigoJefe"] != DBNull.Value ? Convert.ToInt32(reader["CodigoJefe"]) : null
                });
            }

            return empleados;
        }

        public EmpleadoNodo ConstruirArbol()
        {
            var empleados = ObtenerTodos();
            var diccionario = empleados.ToDictionary(e => e.Codigo, e => new EmpleadoNodo
            {
                Codigo = e.Codigo,
                Nombre = e.Nombre,
                Puesto = e.Puesto
            });

            EmpleadoNodo? raiz = null;

            foreach (var e in empleados)
            {
                if (e.CodigoJefe.HasValue)
                    diccionario[e.CodigoJefe.Value].Subordinados.Add(diccionario[e.Codigo]);
                else
                    raiz = diccionario[e.Codigo];
            }

            return raiz!;
        }

        public void Insertar(Empleado emp)
        {
            using var conn = GetConnection();
            using var cmd = new SqlCommand("InsertarEmpleado", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Puesto", emp.Puesto);
            cmd.Parameters.AddWithValue("@Nombre", emp.Nombre);
            cmd.Parameters.AddWithValue("@CodigoJefe", (object?)emp.CodigoJefe ?? DBNull.Value);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Actualizar(Empleado emp)
        {
            using var conn = GetConnection();
            using var cmd = new SqlCommand("ActualizarEmpleado", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Codigo", emp.Codigo);
            cmd.Parameters.AddWithValue("@Puesto", emp.Puesto);
            cmd.Parameters.AddWithValue("@Nombre", emp.Nombre);
            cmd.Parameters.AddWithValue("@CodigoJefe", (object?)emp.CodigoJefe ?? DBNull.Value);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int codigo)
        {
            using var conn = GetConnection();
            using var cmd = new SqlCommand("EliminarEmpleado", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Codigo", codigo);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
