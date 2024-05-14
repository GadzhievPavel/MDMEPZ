using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Exception
{
    public class ExceptionMDM : SystemException
    {
        public ExceptionMDM(string msg) : base(msg) { }
    }
}
