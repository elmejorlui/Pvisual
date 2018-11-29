using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excep2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ExceptionSample();
            }
            catch (excepcion inEx)
            {
                Console.WriteLine($"Message:{inEx.Message} sourse: {inEx.Source}  inner: {inEx.InnerException}");
            }
            catch (FormatException fEx)
            {
                Console.WriteLine($"Message:{fEx.Message} sourse: {fEx.Source}  inner: {fEx.InnerException}");
                Console.ReadLine();
            }

        }

        public static void ExceptionSample()
        {
            Console.WriteLine($"Mostrar Error de insercion (true o false)");
            var isErrorInsert = bool.Parse(Console.ReadLine());
            if (isErrorInsert)
                throw new excepcion("Error al insertar");

            Console.WriteLine($"Mostrar Error al obtener (true o false)");
            var isErrorGet = bool.Parse(Console.ReadLine());
            if (isErrorGet)
                throw new excepcion("No se encontraron registros para mostrar");
        }
    }   
}
