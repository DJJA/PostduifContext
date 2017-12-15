using System;
using System.Collections.Generic;
using System.Text;

namespace PostduifContext.Models
{
    public class PostduifException : Exception
    {
        public PostduifException(string message)
            : base(message)
        {
            
        }
    }
}
