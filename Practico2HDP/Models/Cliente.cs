using System.ComponentModel.DataAnnotations;

namespace Practico2HDP.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }

        [Display(Name ="¿Consumidor Final?")]
        public bool ConsumidorFinal { get; set; } = true;
    }
}
