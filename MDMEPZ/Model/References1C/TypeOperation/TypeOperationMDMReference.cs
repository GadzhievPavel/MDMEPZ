namespace TFlex.DOCs.References.TypeOperationMDM
{
    using DeveloperUtilsLibrary;
    using MDMEPZ.Dto;
    using MDMEPZ.Util;
    using TFlex.DOCs.Model.References;

    public partial class TypeOperationMDMReference : SpecialReference<TypeOperationMDMReferenceObject>
    {

        public partial class Factory
        {
        }
        public ReferenceObject CreateReferenceObjectTypeOperation(TypeOperationMDM typeOperation)
        {
            var typeReferenceObject = CreateReferenceObject(Classes.MainTypeOperation) as TypeOperationMDMReferenceObject;
            typeReferenceObject.StartUpdate();
            typeReferenceObject.UID.Value = typeOperation.Ссылка.UID;
            typeReferenceObject.Name.Value = typeOperation.Наименование;
            typeReferenceObject.Kod.Value = typeOperation.Код;

            return typeReferenceObject;
        }
    }
}
