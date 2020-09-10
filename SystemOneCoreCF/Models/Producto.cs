using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SystemOneCoreCF.Models
{
    public class Producto
    {
        public int Idproducto { get; set; }
       
        [Required (ErrorMessage = "Seleccione una categoría")]
        public int Idcategoria { get; set; }
        public string Codigo { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El nombre que ha ingresado no debe ser mayor a 100 caracteres ni menos a 1")]
        public string Nombre { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
