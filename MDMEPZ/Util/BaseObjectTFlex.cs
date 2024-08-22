using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model.References;

namespace MDMEPZ.Util
{
    public class BaseObjectTFlex
    {
        protected ReferenceObject obj;
        public BaseObjectTFlex(ReferenceObject obj)
        {
            this.obj = obj;
        }

        public void StartUpdate()
        {
            obj.StartUpdate();
        }

        public void EndUpdate(string comment)
        {
            obj.EndUpdate(comment);
        }
    }
}
