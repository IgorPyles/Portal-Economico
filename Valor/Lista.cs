using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Valor
{
    public partial class Lista
    {
        public Listagem[] Stocks { get; set; }
    }

    public partial class Listagem
    {
        public string Name { get; set; }
        public string Stock { get; set; }
        public string Close { get; set; }
        public string Sector { get; set; }
        public float Change { get; set; }

    }
}
