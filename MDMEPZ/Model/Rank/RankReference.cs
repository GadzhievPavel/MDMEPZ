namespace TFlex.DOCs.References.Rank{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model;
    using MDMEPZ.Dto.AnotherDto.Rank;
    using MDMEPZ.Util;

    public partial class RankReference : SpecialReference<RankReferenceObject>	{				public partial class Factory		{		}

		public ReferenceObject CreateReferenceObject(RankMain rank)
		{
			var rankReferenceObject = CreateReferenceObject(Classes.MainRankType) as RankReferenceObject;
			rankReferenceObject.StartUpdate();
			rankReferenceObject.Kod.Value = rank.���;
			rankReferenceObject.Name.Value = rank.������������;
			rankReferenceObject.UID.Value = rank.������.UID;

			return rankReferenceObject;
		}
	}
}}