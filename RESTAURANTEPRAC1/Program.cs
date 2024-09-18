using Restaurante;

public class Program
{
    public static void Main(string[] args)
    {
        SistemaGestion sistema = new SistemaGestion();
        int opcion;

        // Agregar productos al menú inicial
        sistema.AgregarProducto(new Hamburguesa("Hamburguesa Clásica", 15000));
        sistema.AgregarProducto(new Pizza("Pizza Margarita", 10000));
        sistema.AgregarProducto(new Bebida("Coca Cola", 2000));
        sistema.AgregarProducto(new Postre("Helado de Vainilla", 7000));

        do
        {
            Console.WriteLine("\nRESTAURANTE");
            Console.WriteLine("1. Ver Menú");
            Console.WriteLine("2. Registrar Pedido");
            Console.WriteLine("3. Actualizar Estado del Pedido");
            Console.WriteLine("4. Consultar Historial de Pedidos");
            Console.WriteLine("5. Eliminar Producto del Menú");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    sistema.MostrarMenu();
                    break;
                case 2:
                    Console.Write("Ingrese el nombre del cliente: ");
                    string cliente = Console.ReadLine();
                    List<Producto> productosPedido = new List<Producto>();
                    string agregarProducto;

                    do
                    {
                        sistema.MostrarMenu();

                        Producto producto = SeleccionarProducto(sistema);
                        if (producto != null)
                        {
                            productosPedido.Add(producto);
                            Console.WriteLine("Producto agregado.");
                        }
                        else
                        {
                            Console.WriteLine("Producto no encontrado.");
                        }

                        agregarProducto = ConsultarSiAgregarOtroProducto();
                    } 
                    while (agregarProducto.Equals("si", StringComparison.OrdinalIgnoreCase));

                    Pedido nuevoPedido = new Pedido(cliente, productosPedido);
                    sistema.RegistrarPedido(nuevoPedido);
                    Console.WriteLine(nuevoPedido.MostrarDetallesPedido());
                    break;

                    Producto SeleccionarProducto(SistemaGestion sistema)
                    {
                        Console.Write("Ingrese el nombre del producto para agregar al pedido: ");
                        string nombreProducto = Console.ReadLine();
                        return sistema.menu.Find(p => p.Nombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase));
                    }

                    // Método auxiliar para preguntar si el usuario quiere agregar otro producto
                    string ConsultarSiAgregarOtroProducto()
                    {
                        Console.Write("¿Desea agregar otro producto? (si/no): ");
                        return Console.ReadLine();
                    }

                case 3:
                    Console.Write("Ingrese el ID del pedido a actualizar: ");
                    int idPedido = int.Parse(Console.ReadLine());
                    Console.WriteLine("Seleccione el nuevo estado: ");
                    Console.WriteLine("1. Pendiente");
                    Console.WriteLine("2. En Preparación");
                    Console.WriteLine("3. Listo");
                    Console.WriteLine("4. Entregado");
                    int estadoSeleccionado = int.Parse(Console.ReadLine());
                    EstadoPedido nuevoEstado = (EstadoPedido)(estadoSeleccionado - 1);
                    sistema.ActualizarEstado(idPedido, nuevoEstado);
                    break;
                case 4:
                    List<Pedido> historial = sistema.ConsultarHistorialPedidos();
                    for (int i = 0; i < historial.Count; i++)
                    {
                        Console.WriteLine(historial[i].MostrarDetallesPedido());
                    }
                    break;
                case 5:
                    Console.Write("Ingrese el nombre del producto a eliminar: ");
                    string nombreProductoEliminar = Console.ReadLine();
                    sistema.EliminarProducto(nombreProductoEliminar);
                    break;
                case 6:
                    Console.WriteLine("¡Saliendo del programa!");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        } while (opcion != 6);
    }
}
