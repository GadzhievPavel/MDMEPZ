﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model.References;

namespace MDMEPZ.Model.FilterReference
{
    internal interface IFilterNSI
    {
        void setStandard();
        void setEquivalent();
        void setEmptyClassification();

    }
}
