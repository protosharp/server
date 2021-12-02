using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ProtoSharp
{
    public class Server
    {
        private static Server? serverInstance;
        private readonly TcpListener tcpListener;

        public static Server Create(params string[] args)
        {
            if (serverInstance == null)
                serverInstance = new Server(args);

            return serverInstance;
        }

        internal Server(params string[] args)
        {
            Console.WriteLine("Starting ProtoSharp server");
            tcpListener = new TcpListener(IPAddress.Loopback, 5555);
            tcpListener.Start();

            while(true)
            {
                var socket = tcpListener.AcceptSocket();
                Console.WriteLine("New request");
                Task.Run(async () => {
                    var body = "ProtoSharp";
                    var response = $"HTTP/1.1 200 OK\nServer: ProtoSharp\nContent-Type: text/plain\nContent-Length: {body.Length}\n\n{body}";

                    await socket.SendAsync(Encoding.UTF8.GetBytes(response), SocketFlags.None);
                    socket.Close();
                });
            }
        }

        public bool IsAlive => tcpListener != null;
    }
}