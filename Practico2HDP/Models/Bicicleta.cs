using System.ComponentModel.DataAnnotations;

namespace Practico2HDP.Models
{
    public class Bicicleta
    {
        public int BicicletaID { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }

        [Display(Name ="Categoría")]
        public string Categoria { get; set; }

        [Display(Name = "¿Es eléctrica?")]
        public bool EsElectrica { get; set; }

        public string Color { get; set; }

        [Display(Name = "Año")]
        public int Anio { get; set; }
    }
}
