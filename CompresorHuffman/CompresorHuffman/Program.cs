using System;
using HuffmanLib.com.cenfotec.estructuras.huffman.gestor;

namespace CompresorHuffman
{
    class Program
    {
        private static gestorCompresor gestorComp;

        public static void Main(string[] args)
        {
            gestorComp = new gestorCompresor();
            string texto;


            bool salir = false;
            do
            {
                Console.WriteLine("\nIngrese el texto que desea comprimir:\n");
                texto = Console.ReadLine();

                Console.WriteLine(gestorComp.comprimir(texto));


                Console.WriteLine("\nDesea comprimir algo mas?:");
                Console.WriteLine("\n1.Si");
                Console.WriteLine("\n2.No\n");
                int opcionSeleccionada = seleccionarOpcion();
                salir = ejecutarSeleccion(opcionSeleccionada);
            } while (!salir);
        }

        public static int seleccionarOpcion()
        {
            Console.Write("\nSeleccione su opción: ");
            int.TryParse(Console.ReadLine(), out int opcion);
            Console.WriteLine("\n");

            return opcion;
        }

        public static bool ejecutarSeleccion(int opcion)
        {
            bool salir = false;

            switch (opcion)
            {
                case 1:
                    break;

                case 2:
                    Console.WriteLine("Adios");
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opcion invalida");
                    break;
            }

            return salir;
        }
    }
}

