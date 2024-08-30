namespace TFlex.DOCs.References.Devision{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.References.Links;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model.Parameters;
    using MDMEPZ.Dto.AnotherDto.Division;

    public partial class DevisionReferenceObject : SpecialReferenceObject<DevisionReference>	{		public void Update(AnotherDivision division)
		{
			this.Name.Value = division.Наименование;
			this.Kod.Value = division.Код;
			this.NomerTsekha.Value = division.НомерЦеха;
			this.VidPodrazdeleniya.Value = division.ВидПодразделения.TYPE;
			this.TipPodrazdeleniya.Value = division.ТипПодразделения.TYPE;
			this.UID_Owner.Value = division.Родитель.UID;
		}	}}