namespace TFlex.DOCs.References.MDM.Rank
{
    using DeveloperUtilsLibrary;
    using MDMEPZ.Dto.AnotherDto.Rank;
	using MDMEPZ.Util;
    using System.Linq;
    using TFlex.DOCs.Model.References;
    using TFlex.DOCs.Model.Search;

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

		public RankMDMReferenceObject FindTypeJob(string number)
		{
			return Find(Filter.Parse($"[Код] = '{number}'", this.ParameterGroup)).FirstOrDefault() as RankMDMReferenceObject;
		}
	}
}

