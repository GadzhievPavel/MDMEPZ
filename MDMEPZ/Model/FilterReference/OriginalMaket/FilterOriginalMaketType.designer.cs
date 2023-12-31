//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.FilterOiginalMaket
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Classes;
	
	
	/// <summary>
	/// Представляет описание типа объекта справочника "Оригинал-макеты НСИ"
	/// </summary>
	public partial class FilterOriginalMaketType
	{
		
		internal FilterOriginalMaketType(FilterOriginalMaketTypes owner) : 
				base(owner)
		{
		}
		
		/// <summary>
		/// Возвращает типы объектов справочника "Оригинал-макеты НСИ"
		/// </summary>
		public new FilterOriginalMaketTypes Classes
		{
			get
			{
				return ((FilterOriginalMaketTypes)(base.Classes));
			}
		}
		
		/// <summary>
		/// Возвращает true, если текущий экземпляр описывает тип "Оригинал-макеты НСИ" или порождён от него
		/// </summary>
		public bool IsFilterOiginalMaketReferenceObject
		{
			get
			{
				return IsInherit(FilterOriginalMaketTypes.Keys.FilterOiginalMaketReferenceObject);
			}
		}
	}
}
