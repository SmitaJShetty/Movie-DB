using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.CustomExceptions
{
    public class NewMovieAlreadyExistsException : Exception
   {
        public string message { get; set; }

        public NewMovieAlreadyExistsException()
            : base()
        { }

        public NewMovieAlreadyExistsException(String Message)
            : base(Message)
        {
            message = Message;
        }
    }
}
