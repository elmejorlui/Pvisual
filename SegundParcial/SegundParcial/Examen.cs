using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SegundParcial
{
    class Program
    {
        static void Main(string[] args)
        {
            int opc = 0;
            

            Console.WriteLine("1. Leer documento");
            Console.WriteLine("2. Escribir en documento");
            Console.WriteLine("3. Salir");
            opc = int.Parse(Console.ReadLine());

            switch (opc)
            {
                case 1:
                    string line;
                    string temp = "";
                    Boolean isinfile = false;
                    try
                    {
                        StreamReader file =
                            new StreamReader("Registro.txt");
                        while ((line = file.ReadLine()) != null)
                        {
                            temp += line + '\n';
                            isinfile = true;
                        }
                        if (isinfile)
                        {
                            Console.WriteLine(temp);
                        }
                        else
                        {
                            Console.WriteLine("El documento no existe o no tiene nada.");
                        }
                        file.Close();
                    }
                    catch (System.IO.FileNotFoundException e)
                    {
                        Console.WriteLine("El archivo no existe, primero escribe un archivo");
                    }
                    break;
                case 2:
                    string filename = "Registro.txt";
                    string halp = "";

                    Console.WriteLine("Cuantos elementos va a agregar?: ");
                    int x = int.Parse(Console.ReadLine());
                    int[] nums = new int[x];

                    for (int i = 0; i < x; i++)
                    {
                        Console.WriteLine(i + ": ");
                        string linea = Console.ReadLine();
                        nums[i] = Convert.ToInt32(linea);

                        DateTime CurrentDate;
                        CurrentDate = DateTime.Now;

                        Array.Sort(nums);

                        for (int g = 0; g < nums.Length - x; g++)
                        {
                            halp += i + "." + nums[g] + " " + CurrentDate + Environment.NewLine;
                        }
                    }
                    String nuevo = halp;
                    File.WriteAllText(filename, nuevo);
                    Console.WriteLine("Se escribio con exito !");
                    Console.ReadKey();
                    break;

            }
        }
    }
}
