using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Sistema_Nutricional_UH.Models
{
    public class RegistrosAvances
    {
        public int ceduladieta { get; set; }
        public int pesoanterior { get; set; }
        public int pesonuevo { get; set; }
        public int caloriasnecesariasdieta { get; set; }
        public decimal totalCarnes { get; set; }
        public decimal totalVerduras { get; set; }
        public decimal totalLacteos { get; set; }
        public decimal totalGranos { get; set; }
        public decimal totalFrutas { get; set; }
      }
}