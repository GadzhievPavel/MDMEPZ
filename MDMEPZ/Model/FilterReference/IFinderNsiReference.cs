using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model.References;

namespace MDMEPZ.Model.FilterReference
{
    internal interface IFinderNsiReference
    {
        ReferenceObject findObjectByNomenclatureERP(ReferenceObject obj);
    }
}
