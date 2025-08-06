using System.Net;
using System.Net.Sockets;
using System.Text;

const string HTTP_OK = "HTTP/1.1 200 OK\r\n\r\n";

// You can use print statements as follows for debugging, they'll be visible when running tests.
Console.WriteLine("Logs from your program will appear here!");

TcpListener server = new TcpListener(IPAddress.Any, 4221);
server.Start();
Socket socket = server.AcceptSocket(); // wait for client

byte[] responseCodeBytes = Encoding.UTF8.GetBytes(HTTP_OK);

int bytesSent = 0;
while (bytesSent < responseCodeBytes.Length)
{
    bytesSent += socket.Send(responseCodeBytes, bytesSent,
        responseCodeBytes.Length - bytesSent, SocketFlags.None);
}