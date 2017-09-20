using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.CustomExceptions
{
    public class CreateNewMovieFailedException:Exception
    {
        public string message;

        public CreateNewMovieFailedException():base()
        { }

        public CreateNewMovieFailedException(String Message):base(Message)
        {
            message = Message;
        }
    }
}
