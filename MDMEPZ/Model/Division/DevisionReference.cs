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
		/// ������ �������������
		/// </summary>
		/// <param name="devision"></param>
		/// <returns></returns>
		public ReferenceObject CreateReferenceObjectDevision(AnotherDivision devision)
		{
			//List<ReferenceObject> listSave = new List<ReferenceObject>();
			var devisionReferenceObject = CreateReferenceObject(Classes.MainDevision) as DevisionReferenceObject;
			devisionReferenceObject.StartUpdate(); 
			devisionReferenceObject.UID.Value = devision.������.UID;
			devisionReferenceObject.UID_Owner.Value = devision.��������.UID;
			devisionReferenceObject.Name.Value = devision.������������;

			if (devision.��� != null && devision.��� != "")
			{
                devisionReferenceObject.Kod.Value = devision.���;
            }

			devisionReferenceObject.VidPodrazdeleniya.Value = devision.����������������.UID;
			devisionReferenceObject.TipPodrazdeleniya.Value = devision.����������������.UID;
			devisionReferenceObject.NomerTsekha.Value = devision.���������;
			
			return devisionReferenceObject;
		}
		public ReferenceObject FindByUID(string uid)
		{
            return Find(Filter.Parse($"[UID] = '{uid}'",this.ParameterGroup)).FirstOrDefault();
			
		}

		/// <summary>
		/// ����� ������ � ����������� �� ������� �� ����������� "������ � ������������"
		/// </summary>
		/// <param name="departament"></param>
		/// <returns></returns>
		public ReferenceObject FindByLinkedObject(ReferenceObject departament)
		{
			if(departament == null) return null;
            return Find(Filter.Parse($"[������ � ������������] = '{departament}'", this.ParameterGroup)).FirstOrDefault();
        }
	}
}
