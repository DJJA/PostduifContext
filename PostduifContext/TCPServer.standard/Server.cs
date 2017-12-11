using System;
using System.Net;
using System.Net.Sockets;

namespace TCPServer.standard
{
    public class Server
    {
        private Socket socket = null;
        private byte[] buffer;
        public Server()
        {
            socket = new Socket(
                addressFamily: AddressFamily.InterNetwork, 
                socketType: SocketType.Stream,
                protocolType: ProtocolType.Tcp
                );

            socket.Bind(new IPEndPoint(IPAddress.Any, 6556));

            socket.Listen(10);

            socket.BeginAccept(AcceptedCallback, null);
        }

        private void AcceptedCallback(IAsyncResult result)
        {
            Socket clientSocket = socket.EndAccept(result);//stop accepting client
            buffer = new byte[1024];//cleans buffer
            clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceivedCallback, clientSocket);//start receiving from client and store received data in _buffer. When this happens, ReceivedCallback gets called, clientSocket is a parameter to that method. clientSocket Is the connection between you and the client, you want to keep that.
            //Accept();//start looking for clients again
            Console.WriteLine("Client connected on " + clientSocket.RemoteEndPoint.ToString());
        }

        private void ReceivedCallback(IAsyncResult result)
        {
            Socket clientSocket = result.AsyncState as Socket;//define clientSocket. IAsyncResult can be any object, so you have to tell it thatt it is socket.
            int bufferSize = clientSocket.EndReceive(result);//end receive gives you the amount of data you've received
            byte[] packet = new byte[bufferSize];//create shadowclone of _buffer before anyone else uses it
            Array.Copy(buffer, packet, packet.Length);

            //Handle packet
            //PacketHandler.Handle(packet, clientSocket);
            Console.WriteLine(packet);

            //start over
            buffer = new byte[1024];
            clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceivedCallback, clientSocket);//see how that works :)
        }
    }
}
