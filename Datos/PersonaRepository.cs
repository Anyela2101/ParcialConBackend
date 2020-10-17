using System;
using Entity;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace Datos
{
    public class PersonaRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<Persona> _personas = new List<Persona>();
        public PersonaRepository(ConnectionManager connection){
            _connection = connection._conexion;
        }
        
        public void Guardar (Persona persona){
            using(var command =_connection.CreateCommand()){
                command.CommandText =@"Insert Into PrimerParcial (Identificacion,Nombres,Apellidos,Sexo,Edad,Departamento,Ciudad,ValorApoyo,Modalidad,Fecha) values (@Identificacion,@Nombres,@Apellidos,@Sexo,@Edad,@Departamento,@Ciudad,@ValorApoyo,@Modalidad,@Fecha)";
                command.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
                command.Parameters.AddWithValue("@Nombres", persona.Nombres);
                command.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
                command.Parameters.AddWithValue("@Sexo", persona.Sexo);
                command.Parameters.AddWithValue("@Edad", persona.Edad);
                command.Parameters.AddWithValue("@Departamento", persona.Departamento);
                command.Parameters.AddWithValue("@Ciudad", persona.Ciudad);
                command.Parameters.AddWithValue("@ValorApoyo", persona.ValorApoyo);
                command.Parameters.AddWithValue("@Modalidad", persona.Modalidad);
                command.Parameters.AddWithValue("@Fecha", persona.Fecha);
                var filas = command.ExecuteNonQuery();
            }
        }

        public void Eliminar(Persona persona)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from PrimerParcial where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
                command.ExecuteNonQuery();
            }
        }

        public List<Persona> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Persona> personas = new List<Persona>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from PrimerParcial";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Persona persona = DataReaderMapToPerson(dataReader);
                        personas.Add(persona);
                    }
                }
            }
            return personas;
        }

         public Persona BuscarPorIdentificacion(string identificacion)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from PrimerParcial where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", identificacion);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToPerson(dataReader);
            }
        }

         private Persona DataReaderMapToPerson(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Persona persona = new Persona();
            persona.Identificacion = (string)dataReader["Identificacion"];
            persona.Nombres = (string)dataReader["Nombres"];
            persona.Apellidos = (string)dataReader["Apellidos"];
            persona.Sexo = (string)dataReader["Sexo"];
            persona.Edad = (int)dataReader["Edad"];
            persona.Departamento=(string)dataReader["Departamento"];
            persona.Ciudad=(string)dataReader["Ciudad"];
            persona.ValorApoyo=(double)dataReader["ValorApoyo"];
            persona.Fecha=(DateTime)dataReader["Fecha"];
            persona.Modalidad=(string)dataReader["Modalidad"];
            return persona;
        }
    }
}