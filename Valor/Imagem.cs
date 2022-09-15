using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Valor
{
    public partial class Imagem
    {
        public ImagemElemento[] Stocks { get; set; }
    }

    public partial class ImagemElemento
    {
        public string Stock { get; set; }
        public string Name { get; set; }
        public double Close { get; set; }
        public double Change { get; set; }
        public long Volume { get; set; }
        public long? MarketCap { get; set; }
        public Uri Logo { get; set; }
        public string Sector { get; set; }
    }
}
