public class Program
{
        static void RegistrarProducto(int[] codigos, string[] nombres, double[] precios, int[] stocks, ref int cantidadProductos)
    {
        if (cantidadProductos >= 20) // Capacidad máxima del catálogo (20)
        {
            Console.WriteLine("El catalogo esta lleno. No se pueden registrar mas productos.");
            return;
        }
        int codigo = 0;
        bool codigoValido = false;
        do //Bucle para validar el codigo del producto
        {
        try
        {
            Console.Write("Ingrese el nuevo codigo del producto: ");
            codigo = int.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Codigo invalido. Intente nuevamente.");
            continue;
        }
        codigoValido = true; // Asumimos que el codigo es valido hasta que se demuestre lo contrario
        for (int i = 0; i < cantidadProductos; i++)
        {
            if (codigos[i] == codigo)
            {
                codigoValido = false;
                Console.WriteLine("Ya existe un producto con ese codigo.");
                break;
            }
        }
        }while (!codigoValido);

        string nombre;
        bool nombreValido = false;
        do //bucle para validar el nombre del producto
        {
            Console.Write("Ingrese el nombre del producto: ");
            nombre = Console.ReadLine();

            if (nombre == null || nombre.Trim() == "")
            {
                Console.WriteLine("El nombre no puede estar vacio. Intente nuevamente.");
            }
            else
            {
                nombreValido = true;
            }

        } while (!nombreValido);

        double precio = 0;
        bool precioValido = false;

        do//bucle para validar el precio del producto
        {
            try
            {
                Console.Write("Ingrese el precio del producto: ");
                precio = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Precio invalido. Debe ser un numero. Intente nuevamente.");
                continue;
            }

            if (precio <= 0)
            {
                Console.WriteLine("El precio debe ser mayor a 0. Intente nuevamente.");
            }
            else
            {
                precioValido = true;
            }

        } while (!precioValido);

        int stock = 0;
        bool stockValido = false;

        do //bucle para validar el stock del producto
        {
            try
            {
                Console.Write("Ingrese el stock inicial: ");
                stock = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Stock invalido. Debe ser un numero entero. Intente nuevamente.");
                continue;
            }

            if (stock < 0)
            {
                Console.WriteLine("El stock no puede ser negativo. Intente nuevamente.");
            }
            else
            {
                stockValido = true;
            }

        } while (!stockValido);

        // Todos los datos son validos: se registra en la siguiente posicion libre
        codigos[cantidadProductos] = codigo;
        nombres[cantidadProductos] = nombre;
        precios[cantidadProductos] = precio;
        stocks[cantidadProductos] = stock;

        cantidadProductos++;// Incrementar el contador de productos registrados

        Console.WriteLine("Producto registrado correctamente.");
    }

    public static void Main(string[] args)
    {
        // Arreglos paralelos del catálogo (capacidad fija de 20)
        int[] codigos = new int[20];
        string[] nombres = new string[20];
        double[] precios = new double[20];
        int[] stocks = new int[20];

        int cantidadProductos = 0; // Contador de productos registrados
        int opcion = 0; // Variable para almacenar la opción del menú

            Console.WriteLine("===== TECHSHOP - MENU PRINCIPAL =====");
            Console.WriteLine("1. Registrar un producto");
            Console.WriteLine("2. Mostrar el catalogo completo");
            Console.WriteLine("3. Buscar un producto por codigo");
            Console.WriteLine("4. Actualizar stock (sumar o restar)");
            Console.WriteLine("5. Ordenar el catalogo por precio");
            Console.WriteLine("6. Insertar un producto en una posicion especifica");
            Console.WriteLine("7. Eliminar un producto por codigo");
            Console.WriteLine("8. Ordenar el catalogo por nombre");
            Console.WriteLine("9. Demostracion: valor vs. referencia");
            Console.WriteLine("0. Salir del programa");
        do
        {
            Console.Write("Elige una opcion: ");
            try // Intentar convertir la entrada a un número entero
            {
                opcion = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Entrada invalida. Por favor, ingresa un numero del 1 al 9 o 0 para salir.");
                continue;   
            }

            switch (opcion)
            {
                case 1:
                    RegistrarProducto(codigos, nombres, precios, stocks, ref cantidadProductos);
                    break;

                case 2:
                    Console.WriteLine("Funcionalidad 2: Mostrar el catalogo completo.");
                    break;

                case 3:
                    Console.WriteLine("Funcionalidad 3: Buscar un producto por codigo.");
                    break;

                case 4:
                    Console.WriteLine("Funcionalidad 4: Actualizar stock.");
                    break;

                case 5:
                    Console.WriteLine("Funcionalidad 5: Ordenar el catalogo por precio.");
                    break;

                case 6:
                    Console.WriteLine("Funcionalidad 6: Insertar un producto en una posicion especifica.");
                    break;

                case 7:
                    Console.WriteLine("Funcionalidad 7: Eliminar un producto por codigo.");
                    break;

                case 8:
                    Console.WriteLine("Funcionalidad 8: Ordenar el catalogo por nombre.");
                    break;

                case 9:
                    Console.WriteLine("Funcionalidad 9: Demostracion: Valor vs. referencia.");
                    break;

                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opcion invalida. Intente nuevamente.");
                    break;
            }

        } while (opcion != 0);
    }
}