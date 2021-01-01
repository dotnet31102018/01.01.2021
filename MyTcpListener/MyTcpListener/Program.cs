using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyTcpListener
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client ...");
            TcpClient client = new TcpClient();
            client.Connect("127.0.0.1", 8010);
            
            Console.WriteLine("Connected to server at 127.0.0.1:8010");
            Console.WriteLine("What do you want to send?");

            string message = Console.ReadLine();

            ASCIIEncoding enc = new ASCIIEncoding();
            byte[] b = enc.GetBytes(message);

            Console.WriteLine("Firing ...");
            Stream stm = client.GetStream();
            stm.Write(b, 0, b.Length);

            // server responded with ack
            byte[] resp = new byte[100];
            int size = stm.Read(resp, 0, 100);
            for (int i = 0; i < resp.Length; i++)
            {
                Console.Write(Convert.ToChar(resp[i])); // 'A' 65 'B' 66
            }
            client.Close();
            Console.ReadLine();

        }
    }
}
