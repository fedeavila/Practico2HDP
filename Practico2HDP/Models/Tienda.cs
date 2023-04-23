using System.ComponentModel.DataAnnotations;

namespace Practico2HDP.Models
{
    public class Tienda
    {
        public int TiendaID { get; set; }

        [Display(Name = "Razón Social")]
        public string RazonSocial { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
    }
}
