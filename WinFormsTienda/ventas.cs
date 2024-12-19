using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsTienda
{
    public class ventas
    {
        public string NomProd {  get; set; }
        public int Total { get; set; }

        public ventas(string nomPro, int total)
        {
            this.NomProd = nomPro;
            this.Total = total;
        }
    }
}
