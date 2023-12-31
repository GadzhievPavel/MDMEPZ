//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.EtalonProductOther
{
	using System;
	using TFlex.DOCs.Model.References;
	using TFlex.DOCs.Model.Structure;
	using TFlex.DOCs.Model.Classes;
	
	
	/// <summary>
	/// Представляет типы объектов справочника "Эталонные прочие изделия"
	/// </summary>
	public partial class EtalonProductOtherTypes
	{
		
		internal EtalonProductOtherTypes(ParameterGroup group) : 
				base(group)
		{
		}
		
		/// <summary>
		/// Возвращает описание типа объектов "Эталонные прочие изделия"
		/// </summary>
		public EtalonProductOtherType EtalonProductOtherReferenceObject
		{
			get
			{
				return Find(Keys.EtalonProductOtherReferenceObject);
			}
		}
		
		protected override EtalonProductOtherType CreateClassObject(Guid classGuid)
		{
			return new EtalonProductOtherType(this);
		}
		
		/// <summary>
		/// Уникальные идентификаторы (GUID) типов объектов справочника "Эталонные прочие изделия"
		/// </summary>
		public class Keys
		{
			
			/// <summary>
			/// Представляет уникальный идентификатор (GUID) типа "Эталонные прочие изделия"
			/// </summary>
		   public static readonly Guid EtalonProductOtherReferenceObject = new Guid("2c1e223c-470a-4667-a005-a3947daad0b5");

		}
	}
}
