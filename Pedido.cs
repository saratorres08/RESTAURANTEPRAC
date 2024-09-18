using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante
{
    class Pedido
    {
        private static int contadorId = 1;
        public int Id { get; }
        public string Cliente { get; }
        private List<Producto> Productos { get; }
        public double Total { get; }
        public EstadoPedido Estado { get; set; }

        public Pedido(string cliente, List<Producto> productos)
        {
            Id = contadorId++;
            Cliente = cliente;
            Productos = productos;
            Total = CalcularTotal();
            Estado = EstadoPedido.Pendiente;
        }

        private double CalcularTotal()
        {
            double suma = 0;
            for (int i = 0; i < Productos.Count; i++)
            {
                suma += Productos[i].Precio;
            }
            return suma;
        }

        public void CambiarEstado(EstadoPedido nuevoEstado)
        {
            Estado = nuevoEstado;
        }

        public string MostrarDetallesPedido()
        {
            string detalles = $"Pedido ID: {Id}\nCliente: {Cliente}\nProductos:\n";

            for (int i = 0; i < Productos.Count; i++)
            {
                detalles += $" - {Productos[i].MostrarDetalles()}\n";
            }

            detalles += $"Total: ${Total}\nEstado: {Estado}\n";
            return detalles;
        }
    }
}
