//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.Devision
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Classes;
	
	
	/// <summary>
	/// Представляет описание типа объекта справочника "Подразделение"
	/// </summary>
	public partial class DevisionType
	{
		
		internal DevisionType(DevisionTypes owner) : 
				base(owner)
		{
		}
		
		/// <summary>
		/// Возвращает типы объектов справочника "Подразделение"
		/// </summary>
		public new DevisionTypes Classes
		{
			get
			{
				return ((DevisionTypes)(base.Classes));
			}
		}
		
		/// <summary>
		/// Возвращает true, если текущий экземпляр описывает тип "Подразделение" или порождён от него
		/// </summary>
		public bool IsMainDevision
		{
			get
			{
				return IsInherit(DevisionTypes.Keys.MainDevision);
			}
		}
	}
}