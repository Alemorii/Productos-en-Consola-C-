using System;
using ProyectoProducto.Interface;
using ProyectoProducto.Models;
using  ProyectoProducto.Interface.ProductoRepository;

IproductoRepository repo = new ProductoRepository();

bool salir = false;

while (!salir)
{
    Console.WriteLine("\n1- Mostrar lista de productos");
    Console.WriteLine("2- Buscar producto por id");
    Console.WriteLine("3- Filtrar por categoria");
    Console.WriteLine("4- Agregar producto");
    Console.WriteLine("5- Salir");
    Console.Write("Seleccione una opcion: ");

    string? opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
        {
            foreach (var p in repo.ObtenerTodos())
                Console.WriteLine($"{p.Id} | {p.Nombre} | ${p.Precio} | {p.Categoria} | Activo: {p.Activo}");
            break;
        }
        case "2":
        {
            Console.Write("Ingrese id: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var encontrado = repo.ObtenerPorId(id);
                Console.WriteLine(encontrado != null ? encontrado.Nombre : "No encontrado");
            }
            else
            {
                Console.WriteLine("El id debe ser un número.");
            }
            break;
        }
        case "3":
        {
            Console.Write("Ingrese categoria: ");
            string? categoria = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(categoria))
            {
                Console.WriteLine("La categoría no puede estar vacía.");
                break;
            }

            foreach (var p in repo.BuscarPorCategoria(categoria))
                Console.WriteLine($"{p.Id} | {p.Nombre}");
            break;
        }
        case "4":
        {
            Console.Write("Nombre: ");
            string? nombre = Console.ReadLine();

            Console.Write("Precio: ");
            bool precioValido = decimal.TryParse(Console.ReadLine(), out decimal precio);

            Console.Write("Categoria: ");
            string? categoria = Console.ReadLine();

            Console.Write("¿Activo? (s/n): ");
            string? respuestaActivo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(categoria) || !precioValido || precio < 0)
            {
                Console.WriteLine("Datos inválidos. No se agregó el producto.");
                break;
            }

            var todos = repo.ObtenerTodos();
            int nuevoId = todos.Count == 0 ? 1 : todos.Max(p => p.Id) + 1;
            
            repo.Agregar(new Producto
            {
                Id = nuevoId,
                Nombre = nombre,
                Precio = precio,
                Categoria = categoria,
                Activo = respuestaActivo?.Trim().ToLower() == "s"
            });  
            break;       
        }
        case "5":
            salir = true;
            break;
        default:
            Console.WriteLine("Opción inválida.");
            break;
    }
}