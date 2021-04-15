using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClienteSocketApp.comunicacion
{
   public class ClienteSocket
    {
        private string ip;
        private int puerto;
        private Socket comServidor;
        private StreamWriter writer;
        private StreamReader reader;
        public ClienteSocket(string ip, int puerto)
        {
            this.puerto = puerto;
            this.ip = ip;
        }
        public bool Conectar()
        {
            try
            {
                this.comServidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(ip), puerto);
                this.comServidor.Connect(endpoint);
                Stream stream = new NetworkStream(this.comServidor);
                this.reader = new StreamReader(stream);
                this.writer = new StreamWriter(stream);
                return true;
            }catch(Exception ex)
            {
              
                return false;
            }
        }
        public bool Escribir(string mensaje)
        {
            try
            {
                this.writer.WriteLine(mensaje);
                this.writer.Flush();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
        public string leer()
        {
            try
            {

                return this.reader.ReadLine().Trim();
            }catch(Exception ex)
            {
                return null;
            }
        }
        public void Desconectar()
        {
            this.comServidor.Close();
        }
    }
}
