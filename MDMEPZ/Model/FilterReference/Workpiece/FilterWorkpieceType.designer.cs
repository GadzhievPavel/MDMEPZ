//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.Workpiece
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Classes;
	
	
	/// <summary>
	/// Представляет описание типа объекта справочника "Заготовки НСИ"
	/// </summary>
	public partial class FilterWorkpieceType
	{
		
		internal FilterWorkpieceType(FilterWorkpieceTypes owner) : 
				base(owner)
		{
		}
		
		/// <summary>
		/// Возвращает типы объектов справочника "Заготовки НСИ"
		/// </summary>
		public new FilterWorkpieceTypes Classes
		{
			get
			{
				return ((FilterWorkpieceTypes)(base.Classes));
			}
		}
		
		/// <summary>
		/// Возвращает true, если текущий экземпляр описывает тип "Заготовки НСИ" или порождён от него
		/// </summary>
		public bool IsWorkpieceReferenceObject
		{
			get
			{
				return IsInherit(FilterWorkpieceTypes.Keys.WorkpieceReferenceObject);
			}
		}
	}
}
