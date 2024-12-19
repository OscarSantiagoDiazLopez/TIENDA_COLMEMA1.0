using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsTienda
{
    public class Producto
    {
        public int IdP { get; set; }
        public string NameP { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Existencias { get; set; }
        public int Ventas { get; set; }

        public Producto(int idP,string nameP, string imagen, string descripcion, int precio, int existencias, int ventas)
        {
            this.IdP = idP;
            this.NameP = nameP;
            this.Imagen = imagen;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Existencias = existencias;
            this.Ventas = ventas;
        }

    }
}
