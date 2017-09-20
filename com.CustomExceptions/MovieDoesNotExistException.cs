using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.CustomExceptions
{
    public class MovieDoesNotExistException:Exception
    {
        public string message { get; set; }

        public MovieDoesNotExistException()
            : base()
        { }

        public MovieDoesNotExistException(String Message)
            : base(Message)
        {
            message = Message;
        }
    }
}
