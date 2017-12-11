using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace TCPClient.standard
{
    public class Client
    {
        private List<byte> recievedBytes = new List<byte>();
        private byte[] buffer;
        private Socket socket = null;

        public Client()
        {
            socket = new Socket(
                addressFamily: AddressFamily.InterNetwork,
                socketType: SocketType.Stream,
                protocolType: ProtocolType.Tcp
                );

            socket.Connect(IPAddress.Parse("127.0.0.1"), 6556);

            socket.Send(new byte[] {0x00, 0x01, 0x02, 0x03});

            socket.BeginReceive(buffer, 0, 1024, SocketFlags.None, RecievedCallback, null);
        }

        private void RecievedCallback(IAsyncResult result)
        {
            // Handle recieved bytes
            int bytesRecieved = socket.EndReceive(result);
            recievedBytes.AddRange(buffer);


        }
    }
}
