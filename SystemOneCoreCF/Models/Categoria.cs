using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SystemOneCoreCF.Models
{
    public class Categoria
    {
        public int Idcategoria { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage ="El nombre que ha ingresado no debe ser mayor a 50 ni menor a 3 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [StringLength(255, ErrorMessage = "El nombre que ha ingresado no debe ser mayor a 255 caracteres")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
