using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PostduifContext.Models
{
    public enum ActionType
    {
        None,
        GetAll,
        GetById,
        Add,
        Update,
        DeleteById,
        Error
    }

    public enum PacketType
    {
        None,
        Manipulation,
        Error
    }

    public class Packet
    {
        protected const int headerLength = 5;

        public int Length { get; private set; }
        public PacketType PacketType { get; private set; }
        private List<byte> Payload { get;  set; }

        public Packet(int length, PacketType packetType)
        {
            Payload = new List<byte>();
            WriteInt(length);
            WriteBye((byte)packetType);
        }

        public Packet(byte[] payload)
        {
            Length = ReadInt(0);
            PacketType = (PacketType)ReadByte(4);
        }

        protected void WriteBye(byte value)
        {
            Payload.Add(value);
        }

        protected byte ReadByte(int offset)
        {
            return Payload[offset];
        }

        protected void WriteInt(int value)
        {
            Payload.AddRange(BitConverter.GetBytes(value));
        }

        protected int ReadInt(int offset)
        {
            return Convert.ToInt32(ReadByteCollection(offset, 4));
        }

        protected void WriteByteCollection(IEnumerable<byte> byteCollection)
        {
            Payload.AddRange(byteCollection);
        }

        protected IEnumerable<byte> ReadByteCollection(int offset, int length)
        {
            return Payload.GetRange(offset, length);
        }

        protected void WriteString(string value)
        {
            WriteByteCollection(Encoding.UTF8.GetBytes(value));
        }

        protected void WriteNullTerminatedString(string value)
        {
            throw new NotImplementedException();
        }

        protected string ReadString(int offset, int length)
        {
            return Encoding.UTF8.GetString(ReadByteCollection(offset, length).ToArray());
        }

        protected string ReadNullTerminatedString(int offset)
        {
            throw new NotImplementedException();
        }

        //private byte[] GetByteArrayFromPayload(int offset, int length)
        //{
        //    var byteArray = new byte[length];
        //    Buffer.BlockCopy(
        //        src: Payload.ToArray(),
        //        srcOffset: offset,
        //        dst: byteArray,
        //        dstOffset: 0,
        //        count: length
        //        );
        //    return byteArray;
        //}
    }
}
