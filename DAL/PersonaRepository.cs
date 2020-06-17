using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entity;

namespace DAL
{
    public class PersonaRepository
    {
        public ConectionManager Conection;
        public SqlDataReader Reader;
        public IList<Persona> Personas;

        public PersonaRepository(ConectionManager conection)
        {
            Conection = conection;
            Personas = new List<Persona>();
        }

        public void GuardarPersona(Persona persona)
        {
            using(var command = Conection.Connection.CreateCommand())
            {
                command.CommandText = "GuardarPersona";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@cedula", System.Data.SqlDbType.VarChar).Value = persona.Cedula;
                command.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
                command.ExecuteNonQuery();
            }
        }

        public IList<Persona> Consultar()
        {
            Personas.Clear();
            using(var command = Conection.Connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Persona";
                Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Persona persona;
                    persona = Map(Reader);
                    Personas.Add(persona);
                }
            }
            return Personas;
        }

        private Persona Map(SqlDataReader reader)
        {
            Persona persona = new Persona();
            persona.Cedula = (string)reader["id_cedula"];
            persona.Nombre = (string)reader["Nombre"];
            return persona;
        }
    }
}
