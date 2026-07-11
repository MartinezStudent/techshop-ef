public class Program
    {
        // Funcionalidad 1: Registrar un producto
        static void RegistrarProducto(int[] codigos, string[] nombres, double[] precios, int[] stocks, ref int cantidadProductos)
        {
            if (cantidadProductos >= 20) // Capacidad máxima del catálogo (20)
            {
                Console.WriteLine("El catalogo esta lleno. No se pueden registrar mas productos.");
                return;
            }

        //Codigo del producto: Debe ser unico y un numero entero
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

        //Nombre del producto: No puede estar vacio
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

        //Precio del producto: Debe ser un numero mayor a 0
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

        //Stock del producto: Debe ser un numero entero mayor o igual a 0
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

        // Funcionalidad 2: Mostrar el catálogo completo
        static void MostrarCatalogo(int[] codigos, string[] nombres, double[] precios, int[] stocks, int cantidadProductos)
        {
        if (cantidadProductos == 0)
        {
        Console.WriteLine("El catalogo esta vacio.");
        return;
        }

        for (int i = 0; i < cantidadProductos; i++)
        {
        Console.WriteLine("Codigo: " + codigos[i] + " | Nombre: " + nombres[i] + " | Precio: " + precios[i] + " | Stock: " + stocks[i]);
        }
        }

        //Funcionaliadd 3: Buscar un producto por codigo
        static int BuscarProducto(int[] codigos, int cantidadProductos, int codigoBuscado)
        {
        for (int i = 0; i < cantidadProductos; i++)
        {
        if (codigos[i] == codigoBuscado)
        {
            return i;
        }
        }
        return -1;
        }
        static void BuscarPorCodigo(int[] codigos, string[] nombres, double[] precios, int[] stocks, int cantidadProductos)
        {
        int codigoBuscado = 0;
        try
        {
        Console.Write("Ingrese el codigo a buscar: ");
        codigoBuscado = int.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
        Console.WriteLine("Codigo invalido.");
        return;
        }

        int indice = BuscarProducto(codigos, cantidadProductos, codigoBuscado);

        if (indice == -1)
        {
        Console.WriteLine("No se encontro un producto con ese codigo.");
        return;
        }

        Console.WriteLine("Codigo: " + codigos[indice] + 
        " | Nombre: " + nombres[indice] + 
        " | Precio: " + precios[indice] + 
        " | Stock: " + stocks[indice]);
        }
        //Funcionalidad 4: Actualizar stock (sumar o restar)
        static void ActualizarStock(int[] codigos, string[] nombres, double[] precios, int[] stocks, int cantidadProductos)
        {
        int codigoBuscado = 0;
        try
        {
        Console.Write("Ingrese el codigo del producto a actualizar: ");
        codigoBuscado = int.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
        Console.WriteLine("Codigo invalido.");
        return;
        }

        int indice = BuscarProducto(codigos, cantidadProductos, codigoBuscado);

        if (indice == -1)
        {
        Console.WriteLine("No se encontro un producto con ese codigo.");
        return;
        }

        Console.WriteLine("Producto: " + nombres[indice]);
        Console.WriteLine("Stock actual: " + stocks[indice]);

        int cantidad = 0;
        try
        {
        Console.Write("Ingrese la cantidad (positiva para sumar, negativa para restar): ");
        cantidad = int.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
        Console.WriteLine("Cantidad invalida.");
        return;
        }

        int nuevoStock = stocks[indice] + cantidad;

        if (nuevoStock < 0)
        {
        Console.WriteLine("Operacion rechazada: el stock no puede quedar negativo.");
        return;
        }

        stocks[indice] = nuevoStock;
        Console.WriteLine("Stock actualizado correctamente. Nuevo stock: " + stocks[indice]);
        }

        // Swap: Intercambiar productos en el catálogo (utilizado para ordenar) - Reglas 4 y 7
        static void IntercambiarProductos(int[] codigos, string[] nombres, double[] precios, int[] stocks, int j)
        {
            //Se definen variables temporales para almacenar los valores de los productos a intercambiar
            double tempPrecio = precios[j];
            precios[j] = precios[j + 1];
            precios[j + 1] = tempPrecio;

            int tempCodigo = codigos[j];
            codigos[j] = codigos[j + 1];
            codigos[j + 1] = tempCodigo;

            string tempNombre = nombres[j];
            nombres[j] = nombres[j + 1];
            nombres[j + 1] = tempNombre;

            int tempStock = stocks[j];
            stocks[j] = stocks[j + 1];
            stocks[j + 1] = tempStock;
        }

        // Funcionalidad 5: Ordenar el catálogo por precio (de menor a mayor)
        static void OrdenarPorPrecio(int[] codigos, string[] nombres, double[] precios, int[] stocks, int cantidadProductos)
        {
            if (cantidadProductos == 0)
            {
                Console.WriteLine("El catalogo esta vacio. No hay nada que ordenar.");
                return;
            }

            for (int i = 0; i < cantidadProductos - 1; i++)
            {
                for (int j = 0; j < cantidadProductos - 1 - i; j++)
                {
                    if (precios[j] > precios[j + 1])
                    {
                        IntercambiarProductos(codigos, nombres, precios, stocks, j);//Llamada a función Swap
                    }
                }
            }
            Console.WriteLine("Catalogo ordenado por precio (ascendente).");
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
                    MostrarCatalogo(codigos, nombres, precios, stocks, cantidadProductos);
                    break;

                case 3:
                    BuscarPorCodigo(codigos, nombres, precios, stocks, cantidadProductos);
                    break;

                case 4:
                    ActualizarStock(codigos, nombres, precios, stocks, cantidadProductos);
                    break;

                case 5:
                    OrdenarPorPrecio(codigos, nombres, precios, stocks, cantidadProductos);
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