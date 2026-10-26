using ProyectoProducto.Models;

namespace ProyectoProducto.Interface;

public interface IproductoRepository
{
    void Agregar(Producto producto);
    List<Producto> ObtenerTodos();
    Producto? ObtenerPorId(int id);
    List<Producto> BuscarPorCategoria(string categoria);

}