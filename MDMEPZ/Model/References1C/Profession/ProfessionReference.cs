namespace TFlex.DOCs.References.Profession{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model;
    using System.Collections.Generic;
    using MDMEPZ.Util;

    public partial class ProfessionReference : SpecialReference<ProfessionReferenceObject>	{				public partial class Factory		{		}

        public ReferenceObject CreateReferenceObject(MDMEPZ.Dto.AnotherDto.Profession route)
        {
            ProfessionReferenceObject professionReferenceObject = CreateReferenceObject(Classes.MainProfessionType) as ProfessionReferenceObject;
            professionReferenceObject.StartUpdate();
            professionReferenceObject.Name.Value = route.������������;
            professionReferenceObject.UID.Value = route.������.UID;
            professionReferenceObject.Kod.Value = route.���;

            return professionReferenceObject;
        }
    }}