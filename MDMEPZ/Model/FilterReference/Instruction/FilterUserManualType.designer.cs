//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.FilterUserManual
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Classes;
	
	
	/// <summary>
	/// Представляет описание типа объекта справочника "Руководство по эксплуатации НСИ"
	/// </summary>
	public partial class FilterUserManualType
	{
		
		internal FilterUserManualType(FilterUserManualTypes owner) : 
				base(owner)
		{
		}
		
		/// <summary>
		/// Возвращает типы объектов справочника "Руководство по эксплуатации НСИ"
		/// </summary>
		public new FilterUserManualTypes Classes
		{
			get
			{
				return ((FilterUserManualTypes)(base.Classes));
			}
		}
		
		/// <summary>
		/// Возвращает true, если текущий экземпляр описывает тип "Руководство по эксплуатации НСИ" или порождён от него
		/// </summary>
		public bool IsFilterUserManual
		{
			get
			{
				return IsInherit(FilterUserManualTypes.Keys.FilterUserManual);
			}
		}
	}
}
