using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeNow_MVC_Application.Exceptions
{
    [Serializable]
    public class InvalidFormatException:Exception
    {
        public InvalidFormatException() { }
        public InvalidFormatException (string message)
        : base(message)
        {
        }
    }
}
