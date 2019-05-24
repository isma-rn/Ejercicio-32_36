using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E32_E36_MCM_y_MCD
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numerosMCD = new List<int>();            
            /*
            Console.WriteLine("MCD = {0}", CalcularMCD(nums));
            Console.WriteLine("MCM = {0}", CalcularMCM_2Numeros(30, 60));
            /*
            int a = 12, b = 18;
            Console.WriteLine("MCD({0}, {1}) = {2}", a, b, CalcularMCD( a, b));

            a = 6; b = 8;
            Console.WriteLine("MCM({0}, {1}) = {2}", a, b, CalcularMCM(a, b));
            
            Console.ReadLine();*/

            bool salir = false;
            string opcion;
            do
            {
                Console.Clear();                
                do
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Seleccione una opción\n1.- Calcular Mínimo Común Múltiplo de 2 números\n2.- Calcular Máximo Común Divisor de 2 números");
                    opcion = Console.ReadLine();
                    if (opcion.Equals("1"))
                    {
                        Console.WriteLine("\tMCM");
                        var result = CalcularMCM_2Numeros( IngresarValor("primer"), IngresarValor("segundo"));
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("MCM = {0}", result);
                        break;
                    }
                    else if (opcion.Equals("2"))
                    {
                        Console.WriteLine("\tMCD");
                        numerosMCD.Clear();
                        numerosMCD.Add(IngresarValor("primer"));
                        numerosMCD.Add(IngresarValor("segundo"));
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("MCD = {0}", CalcularMCD(numerosMCD));
                        break;                        
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No se reconoce opción...");
                    }                        
                } while (true);

                do
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("n : nuevo, s : salir");
                    opcion = Console.ReadLine();

                    if (opcion.Equals("s"))
                    {
                        salir = true;
                        break;
                    }
                    else if (!opcion.Equals("n"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No se reconoce opción...");
                    }
                    else
                        break;
                } while (true);

            } while (!salir);
        }
        public static int IngresarValor(string nombreValor)
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Ingrese {0} valor entero", nombreValor);
                if (Int32.TryParse(Console.ReadLine(), out int valor))
                {
                    if (valor < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Valor no válido");
                    }
                        
                    else
                        return valor;                    
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Valor no válido");
                }
            } while (true);
        }
        public static int CalcularMCD(List<int> numeros)
        {
            int mcd = 0;
            if (numeros.LongCount() > 0)
            {
                int min = numeros.Min(), sumaResiduo;
                if( min != 0 )
                {
                    for (int i = min; i >= 1; i--)
                    {
                        sumaResiduo = 0;
                        foreach (var n in numeros)                        
                            sumaResiduo += (n % i);                        
                        if(sumaResiduo == 0)
                        {
                            mcd = i;
                            break;
                        }
                    }
                }
            }            
            return mcd;
        }
        public static int CalcularMCM_2Numeros(int numeroA, int numeroB)
        {
            return (numeroA*numeroB) / CalcularMCD( new List<int> { numeroA, numeroB } );
        }
    }
}
