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
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	
	
	/// <summary>
	/// Представляет типы объектов справочника "Подразделение"
	/// </summary>
	public partial class DevisionTypes
	{
		
		internal DevisionTypes(ParameterGroup group) : 
				base(group)
		{
		}
		
		/// <summary>
		/// Возвращает описание типа объектов "Подразделение"
		/// </summary>
		public DevisionType MainDevision
		{
			get
			{
				return Find(Keys.MainDevision);
			}
		}
		
		protected override DevisionType CreateClassObject(Guid classGuid)
		{
			return new DevisionType(this);
		}
		
		/// <summary>
		/// Уникальные идентификаторы (GUID) типов объектов справочника "Подразделение"
		/// </summary>
		public class Keys
		{
			
			/// <summary>
			/// Представляет уникальный идентификатор (GUID) типа "Подразделение"
			/// </summary>
		   public static readonly Guid MainDevision = new Guid("9038e356-741a-4b33-9991-aa7443e63dfe");

		}
	}
}
