//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.Performers
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	
	
	/// <summary>
	/// Представляет типы объектов справочника "Исполнители операции"
	/// </summary>
	public partial class PerformersTypes
	{
		
		internal PerformersTypes(ParameterGroup group) : 
				base(group)
		{
		}
		
		/// <summary>
		/// Возвращает описание типа объектов "Исполнитель операции"
		/// </summary>
		public PerformersType MainPerformers
		{
			get
			{
				return Find(Keys.MainPerformers);
			}
		}
		
		protected override PerformersType CreateClassObject(Guid classGuid)
		{
			return new PerformersType(this);
		}
		
		/// <summary>
		/// Уникальные идентификаторы (GUID) типов объектов справочника "Исполнители операции"
		/// </summary>
		public class Keys
		{
			
			/// <summary>
			/// Представляет уникальный идентификатор (GUID) типа "Исполнитель операции"
			/// </summary>
		   public static readonly Guid MainPerformers = new Guid("e4aaed6a-ef11-4b59-aeaa-29502b6cceb9");

		}
	}
}
