using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Common.Model;
using Newtonsoft.Json;

namespace Client
{
    class ClientConnection
    {
        #region Members
        // The port number for the remote device.
        private const int port = Settings.ServerPort;

        //This will be the userID of the client
        public static string UserID { get; private set; }

        // TCP/IP socket for the client to the server
        private static TcpClient tcpClient = null;

        private static NetworkStream newtworkStream;
        private static StreamReader reader;
        private static StreamWriter writer;

        #endregion

        public static void StartClient()
        {
            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                // The name of the 
                // remote device is "localhost".
                IPHostEntry ipHostInfo = Dns.GetHostEntry("localhost");
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                tcpClient = new TcpClient();
                tcpClient.Connect(remoteEP);
                newtworkStream = tcpClient.GetStream();
                reader = new StreamReader(newtworkStream);
                writer = new StreamWriter(newtworkStream);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void login(string userId, Action<Response<User>> callback)
        {
            Command cmd = new Command { controller = API.Controllers.USERS, method = API.Methods.GET, userID = userId };
            Send<User>(cmd,
                (response) => // intercept callback
                {
                    if (response.success) // if login was successfull
                        ClientConnection.UserID = response.response.idUser; // store user id for future calls
                    callback(response); // proceed with callback
                });
        }

        public static void getAllBooks(Action<Response<List<Book>>> callback, bool includeUnavailable)
        {
            Command cmd = new Command { controller = API.Controllers.BOOKS, method = API.Methods.LIST, arg2 = includeUnavailable, userID = UserID };

            Thread thread = new Thread(new ThreadStart(
                () =>
                {
                    Send<List<Book>>(cmd, callback);
                }));
            thread.Start();
        }

        public static void borrowBooks(List<Book> books, Action<Response<object>> callback)
        {
            Command cmd = new Command { controller = API.Controllers.BORROWING, method = API.Methods.PUT, arg2 = books, userID = UserID };

            Thread thread = new Thread(new ThreadStart(
                () =>
                {
                    Send<object>(cmd, callback);
                }));
            thread.Start();
        }

        public static void saveOrUpdateBook(Book book, Action<Response<object>> callback)
        {
            Command cmd = new Command { controller = API.Controllers.BOOKS, method = API.Methods.PUT, arg2 = book, userID = UserID };

            Thread thread = new Thread(new ThreadStart(
                () =>
                {
                    Send<object>(cmd, callback);
                }));
            thread.Start();
        }

        private static void Send<T>(Command cmd, Action<Response<T>> callback)
        {
            // Send command to the remote device.
            writer.AutoFlush = true;
            writer.WriteLine(JsonConvert.SerializeObject(cmd, Formatting.None));
            writer.Flush();

            // Receive the response from the remote device.
            String response = reader.ReadLine();

            // Write the response to the console.
            Console.WriteLine("Response received : {0}", response);
            
            Response<T> result = JsonConvert.DeserializeObject<Response<T>>(response);

            callback(result);
        }
    }
}
