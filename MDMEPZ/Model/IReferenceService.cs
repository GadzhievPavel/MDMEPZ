using MDMEPZ.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model.References;

namespace MDMEPZ.Model
{
    internal interface IFindService
    {
        ReferenceObject FindByGuid1C(Guid guid);
    }
}
