using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Common;
using Newtonsoft.Json;
using Server.Controller;

namespace Server.Network
{
    public class ClientHandler
    {
        private TcpClient tcpClient;
        private NetworkStream networkStream;
        private StreamReader reader;
        private StreamWriter writer;

        private UsersController usersController;
        private BooksController booksController;

        public ClientHandler(TcpClient tcpClient)
        {
            this.tcpClient = tcpClient;
            networkStream = this.tcpClient.GetStream();
            reader = new StreamReader(networkStream, Encoding.ASCII);
            writer = new StreamWriter(networkStream, Encoding.ASCII);
            usersController = new UsersController();
            booksController = new BooksController();
        }

        public void handle()
        {
            try
            {
                while (true)
                {
                    String content = reader.ReadLine();
                    Console.WriteLine("Client {0}: Read {1} bytes from socket. \n Data : {2}",
                        tcpClient.Client.RemoteEndPoint.ToString(), content.Length, content);
                    writer.AutoFlush = true;

                    Command cmd = JsonConvert.DeserializeObject<Command>(content);

                    Controller.Controller controller = null;
                    switch (cmd.controller)
                    {
                        case API.Controllers.USERS:
                            controller = usersController;
                            break;
                        case API.Controllers.BOOKS:
                            controller = booksController;
                            break;
                    }
                    String response = controller.processCommand(cmd);
                    writer.WriteLine(response);
                    Console.WriteLine("Sent {0} bytes from socket. \n Data : {1}",
                        response.Length, response);
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                reader.Close();
                writer.Close();
                networkStream.Close();
                tcpClient.Close();
            }
        }
    }
}
