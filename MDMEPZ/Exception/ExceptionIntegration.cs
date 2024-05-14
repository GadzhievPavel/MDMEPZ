using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Exception
{
    public class ExceptionIntegration: SystemException
    {
        public ExceptionIntegration(string msg):base(msg) { }
    }
}
