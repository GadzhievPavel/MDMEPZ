namespace TFlex.DOCs.References.Rank
{
	using MDMEPZ.Dto.AnotherDto.Rank;
	using MDMEPZ.Util;
	using TFlex.DOCs.Model.References;

	public partial class RankReference : SpecialReference<RankReferenceObject>
	{

		public partial class Factory
		{
		}

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
}

