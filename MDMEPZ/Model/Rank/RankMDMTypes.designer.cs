//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.MDM.Rank
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	
	
	/// <summary>
	/// Представляет типы объектов справочника "Разряд работ"
	/// </summary>
	public partial class RankMDMTypes
	{
		
		internal RankMDMTypes(ParameterGroup group) : 
				base(group)
		{
		}
		
		/// <summary>
		/// Возвращает описание типа объектов "Разряд работ"
		/// </summary>
		public RankMDMType MainRankType
		{
			get
			{
				return Find(Keys.MainRankRype);
			}
		}
		
		protected override RankMDMType CreateClassObject(Guid classGuid)
		{
			return new RankMDMType(this);
		}
		
		/// <summary>
		/// Уникальные идентификаторы (GUID) типов объектов справочника "Разряд работ"
		/// </summary>
		public class Keys
		{
			
			/// <summary>
			/// Представляет уникальный идентификатор (GUID) типа "Разряд работ"
			/// </summary>
		   public static readonly Guid MainRankRype = new Guid("f36ccc5f-5736-4d6e-b0ed-e7aff1d581c6");

		}
	}
}