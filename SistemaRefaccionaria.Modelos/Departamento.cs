using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRefaccionaria.Modelos
{
    public class Departamento
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Campo Descripcion es Requerido")]
        [MaxLength(100, ErrorMessage = "La Descripcion se compone con 100 caracteres como maximo")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El Turno es Requerido")]
        [MaxLength(60, ErrorMessage = "El Turno se compone con 60 caracteres como maximo")]
        public string Turno { get; set; }

        [Required(ErrorMessage = "El estado del Departamento es Requerido")]
        public bool Estado { get; set; }
    }
}
