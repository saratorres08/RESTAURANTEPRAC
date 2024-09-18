using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante
{
    public interface IGestionarPedido
    {
        void RegistrarPedido(Pedido pedido);
        void ActualizarEstado(int idPedido, EstadoPedido nuevoEstado);
        List<Pedido> ConsultarHistorialPedidos();
        void AgregarProducto(Producto producto);
        void EliminarProducto(string nombreProducto);
        void MostrarMenu();
    }
}