//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TFlex.DOCs.References.NomenclatureERP
{
    using System;
    using TFlex.DOCs.Model.References;
    using TFlex.DOCs.Model.Structure;
    using TFlex.DOCs.Model.Classes;


    /// <summary>
    /// Представляет типы объектов справочника "Номенклатура ERP"
    /// </summary>
    public partial class NomenclatureMDMTypes
    {

        internal NomenclatureMDMTypes(ParameterGroup group) :
                base(group)
        {
        }

        /// <summary>
        /// Возвращает описание типа объектов "Номенклатура ERP"
        /// </summary>
        public NomenclatureMDMType NomenclatureERP
        {
            get
            {
                return Find(Keys.NomenclatureERP);
            }
        }

        /// <summary>
        /// Возвращает описание типа объектов "Номенклатура ИТРП"
        /// </summary>
        public NomenclatureMDMType NomenclatureITRP
        {
            get
            {
                return Find(Keys.NomenclatureITRP);
            }
        }

        protected override NomenclatureMDMType CreateClassObject(Guid classGuid)
        {
            return new NomenclatureMDMType(this);
        }

        /// <summary>
        /// Уникальные идентификаторы (GUID) типов объектов справочника "Номенклатура ERP"
        /// </summary>
        public class Keys
        {

            /// <summary>
            /// Представляет уникальный идентификатор (GUID) типа "Номенклатура ERP"
            /// </summary>
            public static readonly Guid NomenclatureERP = new Guid("9ab08dd5-1cdf-499c-9442-0723236053a8");
            /// <summary>
            /// Представляет уникальный идентификатор (GUID) типа "Ноиенклатура ITRP"
            /// </summary>
            public static readonly Guid NomenclatureITRP = new Guid("3e224b80-bc31-41b7-9341-a790be48c264");
        }
    }
}