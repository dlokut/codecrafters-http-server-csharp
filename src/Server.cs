using System.Net;
using System.Net.Sockets;

const int HTTP_OK = 200;

// You can use print statements as follows for debugging, they'll be visible when running tests.
Console.WriteLine("Logs from your program will appear here!");

TcpListener server = new TcpListener(IPAddress.Any, 4221);
server.Start();
Socket socket = server.AcceptSocket(); // wait for client

int responseCode = HTTP_OK;
byte[] responseCodeBytes = BitConverter.GetBytes(responseCode);

int bytesSent = 0;
while (bytesSent < responseCodeBytes.Length)
{
    bytesSent += socket.Send(responseCodeBytes, bytesSent,
        responseCodeBytes.Length - bytesSent, SocketFlags.None);
}