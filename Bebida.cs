using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante
{
    class Bebida : Producto
    {
        public Bebida(string nombre, double precio) : base(nombre, precio, "Bebida") { }

        public override string MostrarDetalles()
        {
            return $"Bebida: {Nombre} - Precio: ${Precio}";
        }
    }
}
