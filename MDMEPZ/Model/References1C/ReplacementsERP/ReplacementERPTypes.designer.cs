//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.ReplacementERP
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	
	
	/// <summary>
	/// Представляет типы объектов справочника "Замены ERP"
	/// </summary>
	public partial class ReplacementERPTypes
	{
		
		internal ReplacementERPTypes(ParameterGroup group) : 
				base(group)
		{
		}
		
		/// <summary>
		/// Возвращает описание типа объектов "Замены ERP"
		/// </summary>
		public ReplacementERPType ReplacementERPReferenceObject
		{
			get
			{
				return Find(Keys.ReplacementERPReferenceObject);
			}
		}
		
		protected override ReplacementERPType CreateClassObject(Guid classGuid)
		{
			return new ReplacementERPType(this);
		}
		
		/// <summary>
		/// Уникальные идентификаторы (GUID) типов объектов справочника "Замены ERP"
		/// </summary>
		public class Keys
		{
			
			/// <summary>
			/// Представляет уникальный идентификатор (GUID) типа "Замены ERP"
			/// </summary>
		   public static readonly Guid ReplacementERPReferenceObject = new Guid("a35dd029-ab1b-4b37-abcb-ebd721ee2589");

		}
	}
}