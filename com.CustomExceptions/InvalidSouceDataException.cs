using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.CustomExceptions
{
    public class InvalidSouceDataException:Exception
    {
        private string message;

        public InvalidSouceDataException()
            : base()
        { }

        public InvalidSouceDataException(String Message)
            : base(Message)
        {
            message = Message;
        }
    }
}
