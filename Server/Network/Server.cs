using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Server.Controller;
using Newtonsoft.Json;

namespace Server.Network
{
    class Server
    {
        public Server()
        {
        }

        public static void StartListening()
        {

            // Establish the local endpoint for the socket.
            //IPAddress ipAddress = IPAddress.Any;
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, Settings.ServerPort);

            TcpListener tcpListener = new TcpListener(localEndPoint);

            try
            {
                Console.WriteLine("Server started...");
                tcpListener.Start(100);
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    ClientHandler clientHandler = new ClientHandler(tcpClient);
                    Thread handlerThread = new Thread(new ThreadStart(clientHandler.handle));
                    handlerThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
