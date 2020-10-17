using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Primerparcial.Models
{
        public class PersonaInputModel{
            public string Identificacion {get;set;}
            public string Nombres {get;set;}
            public string Apellidos {get;set;}
            public string Sexo {get;set;}
            public int Edad {get;set;}
            public string Departamento {get;set;}
            public string Ciudad {get;set;}
            public double ValorApoyo {get;set;}
            public string Modalidad {get;set;}
            public DateTime Fecha {get;set;}
        }

        public class PersonaViewModel : PersonaInputModel{
            public PersonaViewModel(){

            }
            public PersonaViewModel(Persona persona){
                Identificacion = persona.Identificacion;
                Nombres = persona.Nombres;
                Apellidos = persona.Apellidos;
                Sexo = persona.Sexo;
                Edad = persona.Edad;
                Departamento = persona.Departamento;
                Ciudad = persona.Ciudad;
                ValorApoyo = persona.ValorApoyo;
                Modalidad = persona.Modalidad;
                Fecha = persona.Fecha;
            }
        }
}