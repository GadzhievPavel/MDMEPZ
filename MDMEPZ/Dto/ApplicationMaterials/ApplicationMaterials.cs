using MDMEPZ.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.References.ApplicabiltyMaterials;
using TFlex.DOCs.References.NomenclatureERP;
using TFlex.DOCs.References.UnitOfMeasurement;

namespace MDMEPZ.Dto
{
    //public class ApplicationMaterials
    //{
    //    public static ApplicationMaterials CreateInstance(ApplicabiltyMaterialsReferenceObject appMatRefObj)
    //    {
    //        if(appMatRefObj == null)
    //        {
    //            return null;
    //        }
    //        var appMat = new ApplicationMaterials();
    //        appMat.amount = appMatRefObj.Amount;

    //        var material = appMatRefObj.Material as NomenclatureERPReferenceObject;
    //        appMat.material = material.GUID1C.GetString();

    //        var unit = appMatRefObj.UnitsOfMeasurement as UnitOfMeasurementReferenceObject;
    //        appMat.unitOfMeasurement = unit.GUID_1C.GetString();

    //        return appMat;
    //    }

    //    public string material { get; set; }
    //    public string unitOfMeasurement { get; set; }

    //    public double amount { get; set; }
    //}
}
