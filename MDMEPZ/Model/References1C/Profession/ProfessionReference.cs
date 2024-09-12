namespace TFlex.DOCs.References.Profession
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model;
    using System.Collections.Generic;
    using MDMEPZ.Util;
    using MDMEPZ.Model;
    using TFlex.DOCs.Model.Search;
    using System.Linq;
    using DeveloperUtilsLibrary;

    public partial class ProfessionReference : SpecialReference<ProfessionReferenceObject>, IFindService
    {
		
		public partial class Factory
		{
		}
        /// <summary>
        /// ������ ��������� � ������������ ����������
        /// </summary>
        /// <param name="profession"></param>
        /// <returns></returns>
        public ReferenceObject CreateReferenceObject(MDMEPZ.Dto.AnotherDto.Profession profession)
        {
            ProfessionReferenceObject professionReferenceObject = CreateReferenceObject(Classes.MainProfessionType) as ProfessionReferenceObject;
            professionReferenceObject.StartUpdate();
            professionReferenceObject.Name.Value = profession.������������;
            professionReferenceObject.UID.Value = profession.������.UID;
            professionReferenceObject.Kod.Value = profession.���;

            return professionReferenceObject;
        }

        public ReferenceObject FindByGuid1C(Guid guid)
        {
            return this.Find(Filter.Parse($"[UID] = '{guid}'", ParameterGroup)).FirstOrDefault();
        }
    }
}
