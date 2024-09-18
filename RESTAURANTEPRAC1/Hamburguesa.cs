using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante
{
    class Hamburguesa : Producto
    {
        public Hamburguesa(string nombre, double precio) 
            :base(nombre, precio, "Comida") { }

        public override string MostrarDetalles()
        {
            return $"Hamburguesa: {Nombre} - Precio: ${Precio}";
        }
    }
}