using ChatServerProject.Comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int puerto = Int32.Parse(ConfigurationManager.AppSettings["puerto"]);
            Console.WriteLine("iniciando servidor en puerto {0}",puerto);
            ServerSocket servidor = new ServerSocket(puerto);
            if (servidor.Iniciar())
            {
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("esperando clientes...");
                    if (servidor.ObtenerCliente())
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("conexion establecida");
                        Console.Write("S: Hola Mundo Cliente!");
                        servidor.Escribir("Hola Mundo Cliente!");
                        string mensaje = servidor.Leer();
                        Console.WriteLine("C: {0}", mensaje);
                        servidor.CerrarConexion();
                        


                    }
                }
            }else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("no es posible iniciar servidor");
                Console.ReadKey();
            }
        }
    }
}
