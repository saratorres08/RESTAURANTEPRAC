using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante
{
    class Postre : Producto
    {
        public Postre(string nombre, double precio) : base(nombre, precio, "Postre") { }

        public override string MostrarDetalles()
        {
            return $"Postre: {Nombre} - Precio: ${Precio}";
        }
    }
}
