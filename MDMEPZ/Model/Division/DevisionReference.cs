namespace TFlex.DOCs.References.Devision{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model;
    using System.Collections.Generic;
    using MDMEPZ.Util;
    using MDMEPZ.Dto.AnotherDto.Division;

    public partial class DevisionReference : SpecialReference<DevisionReferenceObject>	{				public partial class Factory		{		}		public ReferenceObject CreateReferenceObjectDevision(AnotherDivision devision)
		{			//List<ReferenceObject> listSave = new List<ReferenceObject>();			var devisionReferenceObject = CreateReferenceObject(Classes.MainDevision) as DevisionReferenceObject;			devisionReferenceObject.StartUpdate(); 			devisionReferenceObject.UID.Value = devision.������.UID;			devisionReferenceObject.Name.Value = devision.������������;			devisionReferenceObject.Kod.Value = devision.���;			devisionReferenceObject.VidPodrazdeleniya.Value = devision.����������������.UID;			devisionReferenceObject.TipPodrazdeleniya.Value = devision.����������������.UID;			devisionReferenceObject.NomerTsekha.Value = devision.���������;						return devisionReferenceObject;		}	}}