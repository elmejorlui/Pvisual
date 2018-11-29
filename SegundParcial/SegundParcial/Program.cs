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
            
            string folderName = @"c:\Carpeta1";
            string pathString = System.IO.Path.Combine(folderName, "SubFolder");
            string pathString2 = @"c:\Subcarpeta1";
            System.IO.Directory.CreateDirectory(pathString); 
            string fileName = "SegParcial.txt";

            Console.WriteLine("1. Leer documento");
            Console.WriteLine("1. Escribir en documento");
            Console.WriteLine("3. Salir");
            opc = Console.Read();

            switch (opc)
            {
                case 1:
                    try
                    {
                        byte[] readBuffer = System.IO.File.ReadAllBytes(pathString);
                        foreach (byte b in readBuffer)
                        {
                            Console.Write(b + " ");
                        }
                        Console.WriteLine();
                    }
                    catch (System.IO.IOException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case 2:
                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"C:\Carpeta1\Subcarpeta1\SegParcial.txt"))
                    {
                        Console.WriteLine("Cuantos elementos va a agregar?: ");
                        int x = Console.Read();
                        int[] nums = new int[x];
                        for (int i = 0; i<nums.Length; i++)
                        {
                            Console.WriteLine(i + ": ");
                            string linea = Console.ReadLine();
                            nums[i] = int.Parse(linea);

                            for (int k = 0; k < nums.Length; k++)
                            {
                                for (int f = 0; f < nums.Length
                                    - k; f++)
                                {
                                    if (nums[f] > nums[f + 1])
                                    {
                                        int aux;
                                        aux = nums[f];
                                        nums[f] = nums[f + 1];
                                        nums[f + 1] = aux;
                                    }
                                }
                            }

                            DateTime CurrentDate;
                            CurrentDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy"));

                            using (StreamWriter writer = new StreamWriter(@"C:\Carpeta1\Subcarpeta1\SegParcial.txt", false))
                            {
                                for (int j = 0; j < nums.Length; i++)
                                {
                                    writer.WriteLine(nums[j].ToString());
                                    writer.WriteLine(CurrentDate.ToString());
                                }
                            }
                        }
                        
                    }
                    break;
                default:
                    break;
            }
            
            System.Console.ReadKey();
        }
    }
}
