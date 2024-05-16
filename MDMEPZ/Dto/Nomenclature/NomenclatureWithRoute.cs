using MDMEPZ.Dto.Integration.Route;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model.References.Nomenclature;
using TFlex.DOCs.References.NomenclatureERP;

namespace MDMEPZ.Dto
{
    public class NomenclatureWithRoute: Nomenclature
    {
        public RoutePlm routePlm { get; set; }

        
        public static NomenclatureWithRoute CreateInstance(NomenclatureERPReferenceObject nomenclatureErp)
        {
            var nom = Nomenclature.CreateInstance(nomenclatureErp);
            var nomWithRoute = (NomenclatureWithRoute)nom;
            nomWithRoute.routePlm = RoutePlm;
            return nomWithRoute;
        }
    }
}
