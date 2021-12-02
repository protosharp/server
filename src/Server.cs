using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ProtoSharp
{
    public class Server
    {
        public const string VERSION = "0.1.0";
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
            Console.WriteLine($"Starting ProtoSharp v{VERSION} server...");
            tcpListener = new TcpListener(IPAddress.Loopback, 5555);
            Start().GetAwaiter().GetResult();
        }

        private async Task Start()
        {
            tcpListener.Start();

            while (true)
            {
                var socket = await tcpListener.AcceptSocketAsync();

                var body = "ProtoSharp";
                var headers = $"HTTP/1.1 200 OK\nServer: ProtoSharp\nContent-Type: text/plain\nContent-Length: {body.Length}";
                await SendResponseAsync(socket, headers, body);
            }
        }

        private async Task SendResponseAsync(Socket socket, string headers, string body)
        {
            var response = $"{headers}\n\n{body}\n";
            await socket.SendAsync(Encoding.UTF8.GetBytes(response), SocketFlags.None);
            socket.Shutdown(SocketShutdown.Send);
            socket.Close();
        }

        public bool IsAlive => tcpListener != null;
    }
}