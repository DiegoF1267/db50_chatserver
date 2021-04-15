using ClienteSocketApp.comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteSocketApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = ConfigurationManager.AppSettings["ip"];
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            ClienteSocket clienteScoket = new ClienteSocket(ip, puerto);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("conectandose al servidor {0} en el puerto {1}", ip, puerto);
            if (clienteScoket.Conectar())
            {
                Console.WriteLine("cliente conectado..");

                string mensaje = "";
                while (mensaje.ToLower() != "chao")
                {
                    Console.WriteLine("diga lo que quiere decir:");
                    mensaje = Console.ReadLine().Trim();
                    Console.WriteLine(" C: {0}", mensaje);
                    clienteScoket.Escribir(mensaje);
                    if(mensaje.ToLower() != "chao")
                    {
                        mensaje = clienteScoket.leer();
                        Console.WriteLine(" S: {0}", mensaje);
                    }
                }
                clienteScoket.Desconectar();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("error  de connexion");
            }
        }
    }
}
