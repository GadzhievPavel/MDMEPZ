namespace TFlex.DOCs.References.Region{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model;	using MDMEPZ.Dto.AnotherDto.Region;	using DeveloperUtilsLibrary;
    using TFlex.DOCs.Model.Search;
    using System.Linq;

    public partial class RegionReference : SpecialReference<RegionReferenceObject>	{				public partial class Factory		{		}		public ReferenceObject CreateReferenceObject(Region region)
		{			var regionReferenceObjectMDM = CreateReferenceObject(Classes.OwnerTypeRegion) as RegionReferenceObject;			regionReferenceObjectMDM.StartUpdate();			regionReferenceObjectMDM.UID.Value = region.������.UID;			regionReferenceObjectMDM.Vladelets.Value = region.��������.UID;			regionReferenceObjectMDM.Name.Value = region.������������;			regionReferenceObjectMDM.Kod.Value = region.���;			return regionReferenceObjectMDM;		}
	}}