namespace TFlex.DOCs.References.MDM.Rank
{
	using MDMEPZ.Dto.AnotherDto.Rank;
	using MDMEPZ.Util;
	using TFlex.DOCs.Model.References;

	public partial class RankMDMReference : SpecialReference<RankMDMReferenceObject>
	{

		public partial class Factory
		{
		}
		/// <summary>
		/// Создаёт Разряд исполнителя
		/// </summary>
		/// <param name="rank"></param>
		/// <returns></returns>
		public ReferenceObject CreateReferenceObject(RankMain rank)
		{
			var rankReferenceObject = CreateReferenceObject(Classes.MainRankType) as RankMDMReferenceObject;
			rankReferenceObject.StartUpdate();
			rankReferenceObject.Kod.Value = rank.Код.Trim(new char[] {'0'});
			rankReferenceObject.Name.Value = rank.Наименование;
			rankReferenceObject.UID.Value = rank.Ссылка.UID;
			return rankReferenceObject;
		}

		
	}
}

