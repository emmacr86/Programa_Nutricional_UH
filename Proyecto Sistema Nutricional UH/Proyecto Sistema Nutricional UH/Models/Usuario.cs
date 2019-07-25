using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace Proyecto_Sistema_Nutricional_UH.Models
{
    public class Usuario
    {
        [Required(ErrorMessage = "Digite su Cédula")]
        public int cedula { get; set; }

        [Required(ErrorMessage = "Digite su Contraseña")]
        public string contrasena { get; set; }

        public string nombre { get; set; }

        public string apellidos { get; set; }

        public string sexo { get; set; }

        public int edad { get; set; }

        public int estatura { get; set; }

        public int peso { get; set; }

        public string correo { get; set; }

        public string tasaMetabolicaBasal { get; set; }

        public string factorActividad { get; set; }

        public string caloriasNecesarias { get; set; }

        public int cantidadComidas { get; set; }
        
        public DataTable tabla { get; set; }

        public Usuario()
        {
            cedula = 0;
            contrasena = "";
            nombre = "";
            apellidos = "";
            sexo = "";
            edad = 0;
            estatura = 0;
            peso = 0;
            correo = "";
            tasaMetabolicaBasal = "";
            factorActividad = "";
            caloriasNecesarias = "";
            cantidadComidas = 0; 
            tabla = new DataTable();
        }
    }
}