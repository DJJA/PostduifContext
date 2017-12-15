using System;
using System.Collections.Generic;
using System.Text;

namespace PostduifContext.Models
{
    public class ErrorPacket : Packet
    {
        public string ErrorMessage { get; private set; }

        public ErrorPacket(string errorMessage) 
            : base(headerLength + errorMessage.Length, PacketType.Error)
        {
            WriteNullTerminatedString(errorMessage);
        }

        public ErrorPacket(byte[] data)
            : base(data)
        {
            ErrorMessage = ReadNullTerminatedString(headerLength);
        }
    }
}
