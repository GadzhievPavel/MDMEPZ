namespace TFlex.DOCs.References.Devision
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	using TFlex.DOCs.Model;
    using System.Collections.Generic;
    using MDMEPZ.Util;
    using MDMEPZ.Dto.AnotherDto.Division;
	using TFlex.DOCs.Model.Search;
	using System.Security.Cryptography;
	using System.Linq;

	public partial class DevisionReference : SpecialReference<DevisionReferenceObject>
	{
		
		public partial class Factory
		{
		}
		/// <summary>
		/// Создаёт подразделения
		/// </summary>
		/// <param name="devision"></param>
		/// <returns></returns>
		public ReferenceObject CreateReferenceObjectDevision(AnotherDivision devision)
		{
			//List<ReferenceObject> listSave = new List<ReferenceObject>();
			var devisionReferenceObject = CreateReferenceObject(Classes.MainDevision) as DevisionReferenceObject;
			devisionReferenceObject.StartUpdate(); 
			devisionReferenceObject.UID.Value = devision.Ссылка.UID;
			devisionReferenceObject.UID_Owner.Value = devision.Родитель.UID;
			devisionReferenceObject.Name.Value = devision.Наименование;

			if (devision.Код != null && devision.Код != "")
			{
                devisionReferenceObject.Kod.Value = devision.Код;
            }

			devisionReferenceObject.VidPodrazdeleniya.Value = devision.ВидПодразделения.UID;
			devisionReferenceObject.TipPodrazdeleniya.Value = devision.ТипПодразделения.UID;
			devisionReferenceObject.NomerTsekha.Value = devision.НомерЦеха;
			
			return devisionReferenceObject;
		}
		public ReferenceObject FindByUID(string uid)
		{
            return Find(Filter.Parse($"[UID] = '{uid}'",this.ParameterGroup)).FirstOrDefault();
			
		}

		/// <summary>
		/// Поиск записи в справочнике по объекту из справочника "Группы и пользователи"
		/// </summary>
		/// <param name="departament"></param>
		/// <returns></returns>
		public ReferenceObject FindByLinkedObject(ReferenceObject departament)
		{
			if(departament == null) return null;
            return Find(Filter.Parse($"[Группы и пользователи] = '{departament}'", this.ParameterGroup)).FirstOrDefault();
        }
	}
}
