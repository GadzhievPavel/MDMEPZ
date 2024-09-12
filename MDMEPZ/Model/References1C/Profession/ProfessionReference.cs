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
        /// Создаёт профессию в справочниках технологии
        /// </summary>
        /// <param name="profession"></param>
        /// <returns></returns>
        public ReferenceObject CreateReferenceObject(MDMEPZ.Dto.AnotherDto.Profession profession)
        {
            ProfessionReferenceObject professionReferenceObject = CreateReferenceObject(Classes.MainProfessionType) as ProfessionReferenceObject;
            professionReferenceObject.StartUpdate();
            professionReferenceObject.Name.Value = profession.Наименование;
            professionReferenceObject.UID.Value = profession.Ссылка.UID;
            professionReferenceObject.Kod.Value = profession.Код;

            return professionReferenceObject;
        }

        public ReferenceObject FindByGuid1C(Guid guid)
        {
            return this.Find(Filter.Parse($"[UID] = '{guid}'", ParameterGroup)).FirstOrDefault();
        }
    }
}
