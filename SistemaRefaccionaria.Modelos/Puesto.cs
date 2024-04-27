using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRefaccionaria.Modelos
{
    public class Puesto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Campo Nombre es Requerido")]
        [MaxLength(60, ErrorMessage = "El nombre se compone con 60  caracteres como maximo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Tipo de puesto es Requerido")]
        [MaxLength(60, ErrorMessage = "El tipo de puesto se compone con 60 caracteres como maximo")]
        public string TipoPuesto { get; set; }

        [Required(ErrorMessage = "El salario es requerido")]
        public double Salario { get; set; }

        [Required(ErrorMessage = "El Horario es Requerido")]
        [MaxLength(60, ErrorMessage = "El horario se compone con 60 caracteres como maximo")]
        public string Horario { get; set; }

        [Required(ErrorMessage = "El estado de la Marca es Requerido")]
        public bool Estado { get; set; }
    }
}
