using System;
using System.Collections.Generic;
using System.Text;

namespace PostduifContext.Models
{
    public enum PostduifExceptionType
    {
        CollectionNotFound,
        CollectionNameNull,
        CollectionNameEmpty
    }

    public class PostduifException : Exception
    {
        public PostduifException(string message)
            : base(message)
        {
            
        }
    }
}
