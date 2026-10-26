using System;
using ProyectoProducto.Interface;
using ProyectoProducto.Models;

namespace ProyectoProducto.Interface.ProductoRepository;

public class ProductoRepository : IproductoRepository
{
    private readonly List<Producto> _productos;

    public ProductoRepository()
    {
        _productos = new List<Producto>{
            new Producto{Id =1,Nombre="Ryzen 5600g",Precio = 279000m,Categoria = "CPU",Activo = true},
            new Producto{Id =2,Nombre="i9 9900k",Precio = 500000m,Categoria = "CPU",Activo = true},
            new Producto{Id =3,Nombre="Rtx 3060",Precio = 200000m,Categoria = "GPU",Activo = true},

        };

    }
        
    public void Agregar(Producto producto)
    {
        _productos.Add(producto);
    }

    public List<Producto> ObtenerTodos()
    {
        return _productos.ToList();
    }

    public Producto? ObtenerPorId(int id)
    {   
        return _productos.FirstOrDefault(p => p.Id == id);
    }

    public List<Producto> BuscarPorCategoria(string categoria)
    {
        return _productos
            .Where(p=> p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}