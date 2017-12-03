using System;
using System.Collections.Generic;
using System.Text;

namespace PostduifContext.DAL.Conexts
{
    interface IConnectionContext
    {
        int Send(byte[] data);
        int Recieve();
    }
}
