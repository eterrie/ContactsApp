using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Core.Exceptions
{
    public class ValidationException : ContactsAppException
    {
        public ValidationException(string message) : base(message) { }
    }
}
