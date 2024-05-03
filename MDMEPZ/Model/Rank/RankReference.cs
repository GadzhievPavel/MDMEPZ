namespace TFlex.DOCs.References.Rank{	using System;	using TFlex.DOCs.Model.References;	using TFlex.DOCs.Model.Structure;	using TFlex.DOCs.Model.Classes;	using TFlex.DOCs.Model;
    using MDMEPZ.Dto.AnotherDto.Rank;
    using MDMEPZ.Util;

    public partial class RankReference : SpecialReference<RankReferenceObject>	{				public partial class Factory		{		}

		public ReferenceObject CreateReferenceObject(RankMain rank)
		{
			var rankReferenceObject = CreateReferenceObject(Classes.MainRankType) as RankReferenceObject;
			rankReferenceObject.StartUpdate();
			rankReferenceObject.Kod.Value = rank.Код;
			rankReferenceObject.Name.Value = rank.Наименование;
			rankReferenceObject.UID.Value = rank.Ссылка.UID;

			return rankReferenceObject;
		}
	}
}}