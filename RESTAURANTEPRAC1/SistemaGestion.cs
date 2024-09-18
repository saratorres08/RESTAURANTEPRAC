using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante
{
    public class SistemaGestion : IGestionarPedido
    {
        private List<Producto> menu;
        private List<Pedido> historialPedidos;

        public SistemaGestion()
        {
            menu = new List<Producto>();
            historialPedidos = new List<Pedido>();
        }

        public override void AgregarProducto(Producto producto)
        {
            menu.Add(producto);
            Console.WriteLine($"Producto agregado: {producto.MostrarDetalles()}");
        }

        public override void EliminarProducto(string nombreProducto)
        {
            menu.RemoveAll(p => p.Nombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"Producto eliminado del menú: {nombreProducto}");
        }

        public override void MostrarMenu()
        {
            Console.WriteLine("---- Menú del Restaurante ----");
            foreach (var producto in menu)
            {
                Console.WriteLine(producto.MostrarDetalles());
            }
        }

        // Implementación de métodos para gestionar pedidos
        public override void RegistrarPedido(Pedido pedido)
        {
            historialPedidos.Add(pedido);
            Console.WriteLine("Pedido registrado con éxito.");
        }

        public override void ActualizarEstado(int idPedido, EstadoPedido nuevoEstado)
        {
            Pedido pedido = historialPedidos.Find(p => p.Id == idPedido);
            if (pedido != null)
            {
                pedido.CambiarEstado(nuevoEstado);
                Console.WriteLine($"Estado del pedido actualizado: {nuevoEstado}");
            }
            else
            {
                Console.WriteLine("Pedido no encontrado.");
            }
        }

        public override List<Pedido> ConsultarHistorialPedidos()
        {
            return historialPedidos;
        }

    }
}
