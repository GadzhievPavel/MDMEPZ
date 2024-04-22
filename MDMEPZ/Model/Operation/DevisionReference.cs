namespace TFlex.DOCs.References.Devision{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model;
    using System.Collections.Generic;
    using MDMEPZ.Util;

    public partial class DevisionReference : SpecialReference<DevisionReferenceObject>	{				public partial class Factory		{		}		public ReferenceObject CreateDevision(MDMEPZ.Dto.Division devision)
		{			List<ReferenceObject> listSave = new List<ReferenceObject>();			var devisionReferenceObject = CreateReferenceObject(Classes.MainDevision) as DevisionReferenceObject;			devisionReferenceObject.StartUpdate();			devisionReferenceObject.Name.Value = devision.Наименование;			devisionReferenceObject.Kod.Value = devision.Код;			devisionReferenceObject.UID.Value = devision.UID;			return devisionReferenceObject;		}	}}