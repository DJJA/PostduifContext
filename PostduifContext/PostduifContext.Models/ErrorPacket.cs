using System;
using System.Collections.Generic;
using System.Text;

namespace PostduifContext.Models
{
    public class ErrorPacket : Packet
    {
        public string ErrorMessage { get; private set; }

        public ErrorPacket(string errorMessage, List<byte> payload) 
            : base(headerLength + errorMessage.Length, ActionType.Error, payload)
        {
            ErrorMessage = errorMessage;
        }
    }
}
