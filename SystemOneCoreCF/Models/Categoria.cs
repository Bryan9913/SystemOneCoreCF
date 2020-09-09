using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemOneCoreCF.Models
{
    public class Categoria
    {
        public int Idcategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
