using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyTcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                IPAddress ipad = IPAddress.Parse("127.0.0.1");
                TcpListener listener = new TcpListener(ipad, 8010);
                listener.Start();

                Console.WriteLine("The server is running at port 8010");
                Console.WriteLine("Waiting for connection...");
                
                Socket s = listener.AcceptSocket(); // blocking

                // when message arrives
                Console.WriteLine($"Connection accepted from {s.RemoteEndPoint}");
                byte[] b = new byte[1000];
                int size = s.Receive(b);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < size; i++)
                {
                    Console.Write(Convert.ToChar(b[i]));
                    sb.Append(Convert.ToChar(b[i]).ToString());
                }

                ASCIIEncoding enc = new ASCIIEncoding();
                s.Send(enc.GetBytes($"The string {sb} was recieved by the server."));

                s.Close();
                listener.Stop();
                Console.WriteLine();
                Thread.Sleep(1000);
            }
        }
    }
}
