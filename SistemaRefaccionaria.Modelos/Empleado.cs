using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRefaccionaria.Modelos
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Campo Apellido Paterno es Requerido")]
        [MaxLength(60, ErrorMessage = "El nombre se compone con 60  caracteres como maximo")]
        public string APaterno { get; set; }

        [Required(ErrorMessage = "El Campo Apellido Materno es Requerido")]
        [MaxLength(60, ErrorMessage = "El nombre se compone con 60  caracteres como maximo")]
        public string AMaterno { get; set; }

        [Required(ErrorMessage = "El Campo Nombre es Requerido")]
        [MaxLength(60, ErrorMessage = "El nombre se compone con 60  caracteres como maximo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Campo Direccion es Requerido")]
        [MaxLength(100, ErrorMessage = "La Direccion se compone con 100 caracteres como maximo")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El Telefono es Requerido")]
        [MaxLength(15, ErrorMessage = "El Telefono se compone con 15 caracteres como maximo")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El estado de la Marca es Requerido")]
        public bool Estado { get; set; }

        //Agregamos la relacion con la tabla puesto
        [Required(ErrorMessage = "El puesto es requerido")]
        public int PuestoId { get; set; }
        [ForeignKey("PuestoId")]
        public Puesto Puesto { get; set; }

        //La relacion con la tabla departamento
        [Required(ErrorMessage = "El Departamento es requerido")]
        public int DepartamentoId { get; set; }
        [ForeignKey("DepartamentoId")]
        public Departamento Departamento { get; set; }
    }
}
