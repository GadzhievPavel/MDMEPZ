using MDMEPZ.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.References.ApplicabiltyMaterials;

namespace MDMEPZ.Dto
{
    public class ApplicationMaterials
    {
        //public static ApplicationMaterials CreateInstance(ApplicabiltyMaterialsReferenceObject appMatRefObj)
        //{
        //    var appMat = new ApplicationMaterials();
        //    appMat.material = appMatRefObj.Name;
        //    appMat.amount = appMatRefObj.Amount;
        //    appMat.unitOfMeasurement = appMatRefObj.Material.
        //}
        public string material { get; set; }
        public string unitOfMeasurement {  get; set; }

        public double amount {  get; set; }
    }
}
