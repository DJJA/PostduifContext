using System;
using System.Collections.Generic;
using System.Text;
using PostduifContext.Models;
using PostduifServer.CollectionLogic;

namespace PostduifContextClient
{
    class PacketHandler
    {
        public static void HandlePacket(Packet packet)
        {
            switch (packet.PacketType)
            {
                case PacketType.Error:
                    throw new PostduifException(((ErrorPacket)packet).ErrorMessage);
                case PacketType.Manipulation:
                    ManipulateData((CollectionManipulationPacket)packet);
                    break;
                    
            }
        }

        private static void ManipulateData(CollectionManipulationPacket packet)
        {
            //switch (packet.ActionType)
            //{
            //    case ActionType.Add:
            //        CollectionContainer.AddToCollection(packet.CollectionName, packet.CollectionData);
            //        break;
            //    case ActionType.Update:
            //        CollectionContainer.UpdateCollection(packet.CollectionName, packet.);
            //}
        }
    }
}
