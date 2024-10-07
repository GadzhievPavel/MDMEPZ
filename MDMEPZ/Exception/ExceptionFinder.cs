using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Exception
{
    public class ExceptionFinder:SystemException
    {
        public ExceptionFinder(string msg):base(msg) { }
    }
}
