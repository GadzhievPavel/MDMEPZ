//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.FilterProduct
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Classes;
	
	
	/// <summary>
	/// Представляет описание типа объекта справочника "Изделия НСИ"
	/// </summary>
	public partial class FilterProductType
	{
		
		internal FilterProductType(FilterProductTypes owner) : 
				base(owner)
		{
		}
		
		/// <summary>
		/// Возвращает типы объектов справочника "Изделия НСИ"
		/// </summary>
		public new FilterProductTypes Classes
		{
			get
			{
				return ((FilterProductTypes)(base.Classes));
			}
		}
		
		/// <summary>
		/// Возвращает true, если текущий экземпляр описывает тип "Изделия НСИ" или порождён от него
		/// </summary>
		public bool IsFilterProductReferenceObject
		{
			get
			{
				return IsInherit(FilterProductTypes.Keys.FilterProductReferenceObject);
			}
		}
	}
}
