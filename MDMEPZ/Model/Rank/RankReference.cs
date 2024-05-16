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
		/// <summary>
		/// ������ ������ �����������
		/// </summary>
		/// <param name="rank"></param>
		/// <returns></returns>
		public ReferenceObject CreateReferenceObject(RankMain rank)
		{
			var rankReferenceObject = CreateReferenceObject(Classes.MainRankType) as RankReferenceObject;
			rankReferenceObject.StartUpdate();
			rankReferenceObject.Kod.Value = rank.���.Trim(new char[] {'0'});
			rankReferenceObject.Name.Value = rank.������������;
			rankReferenceObject.UID.Value = rank.������.UID;
			return rankReferenceObject;
		}

		
	}
}

