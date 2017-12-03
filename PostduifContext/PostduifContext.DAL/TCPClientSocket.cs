using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace PostduifContext.DAL
{
    class TCPClientSocket
    {
        private Socket socket = null;

        public TCPClientSocket(string host, int port)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);   // Can be done when declaring?
            socket.Connect(host, port);
        }

        private int Send(byte[] data)
        {
            return socket.Send(data);
        }

        public IEnumerable<byte[]> GetAll(string collectionName)
        {
            var list = new List<byte[]>();

            


            return list;
        }

        public byte[] GetById(string collectionName, int id)
        {
            var data = new byte[1];

            return data;
        }

        public int Add(string collectionName, byte[] data)
        {
            var addedId = -1;

            return addedId;
        }

        public void Update(string collectionName, byte[] data)
        {
            
        }

        public void Delete(string collectionName, byte[] data)
        {
            
        }
    }
}
