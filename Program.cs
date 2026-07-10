public class Program
{
    public static void Main(string[] args)
    {
        // Arreglos paralelos del catálogo (capacidad fija de 20)
        int[] codigos = new int[20];
        string[] nombres = new string[20];
        double[] precios = new double[20];
        int[] stocks = new int[20];

        int cantidadProductos = 0; // Contador de productos registrados
        int opcion = 0; // Variable para almacenar la opción del menú

            Console.WriteLine();
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
                    Console.WriteLine("Funcionalidad 1: Registrar un producto.");
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