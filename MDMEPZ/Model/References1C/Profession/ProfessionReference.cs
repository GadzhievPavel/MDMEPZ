namespace TFlex.DOCs.References.Profession
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model;
    using System.Collections.Generic;
    using MDMEPZ.Util;

    public partial class ProfessionReference : SpecialReference<ProfessionReferenceObject>
	{
		
		public partial class Factory
		{
		}

        public ReferenceObject CreateReferenceObject(MDMEPZ.Dto.AnotherDto.Profession profession)
        {
            ProfessionReferenceObject professionReferenceObject = CreateReferenceObject(Classes.MainProfessionType) as ProfessionReferenceObject;
            professionReferenceObject.StartUpdate();
            professionReferenceObject.Name.Value = profession.������������;
            professionReferenceObject.UID.Value = profession.������.UID;
            professionReferenceObject.Kod.Value = profession.���;

            return professionReferenceObject;
        }
    }
}
