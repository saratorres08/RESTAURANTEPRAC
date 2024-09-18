using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante
{
    class Pizza : Producto
    {
        public Pizza(string nombre, double precio) : base(nombre, precio, "Comida") { }

        public override string MostrarDetalles()
        {
            return $"Pizza: {Nombre} - Precio: ${Precio}";
        }
    }
}
