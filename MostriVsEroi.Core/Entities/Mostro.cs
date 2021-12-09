using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Core.Entities
{
    public class Mostro
    {
        public int Id { get; set; }
        public CategoriaEnum CategoriaEnum { get; set; }
        public int IdArma { get; set; }
    }
}
