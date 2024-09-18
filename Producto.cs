using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante
{
    // Clase abstracta Producto
    abstract class Producto
    {
        public string Nombre { get; }
        public double Precio { get; }
        public string Categoria { get; }

        public Producto(string nombre, double precio, string categoria)
        {
            Nombre = nombre;
            Precio = precio;
            Categoria = categoria;
        }

        public abstract string MostrarDetalles();
    }
}