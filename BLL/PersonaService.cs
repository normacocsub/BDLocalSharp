using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
    public class PersonaService
    {
        public ConectionManager Conection;
        public PersonaRepository PersonaRepositorio;

        public PersonaService(string conection)
        {
            Conection = new ConectionManager(conection);
            PersonaRepositorio = new PersonaRepository(Conection);
        }


        public string GuardarPersona(Persona persona)
        {
            try
            {
                Conection.Open();
                PersonaRepositorio.GuardarPersona(persona);
                return $"Se ha guardado. ";
            }
            catch(Exception e)
            {
                return $"Error. {e.Message.ToString()}";
            }
            finally
            {
                Conection.Close();
            }
        }

        public IList<Persona> Consultar()
        {
            try
            {
                Conection.Open();
                return PersonaRepositorio.Consultar();
            }
            catch(Exception e)
            {
                return null;
            }
            finally
            {
                Conection.Close();
            }
        }
    }
}
