namespace TFlex.DOCs.References.Devision{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.References.Links;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model.Parameters;
    using MDMEPZ.Dto.AnotherDto.Division;

    public partial class DevisionReferenceObject : SpecialReferenceObject<DevisionReference>	{		public void Update(AnotherDivision division)
		{
			this.Name.Value = division.������������;
			this.Kod.Value = division.���;
			this.NomerTsekha.Value = division.���������;
			this.VidPodrazdeleniya.Value = division.����������������.TYPE;
			this.TipPodrazdeleniya.Value = division.����������������.TYPE;
			this.UID_Owner.Value = division.��������.UID;
		}	}}