using MDMEPZ.Dto.Integration.Route;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model.References.Nomenclature;
using TFlex.DOCs.References.NomenclatureERP;
using TFlex.Model.Technology.References.TechnologyElements;
using TFlex.Technology.References;

namespace MDMEPZ.Dto
{
    public class NomenclatureWithRoute: Nomenclature
    {
        public RoutePlm[] routePlm { get; set; }

        
        public new static NomenclatureWithRoute CreateInstance(NomenclatureERPReferenceObject nomenclatureErp)
        {
            var nom = Nomenclature.CreateInstance(nomenclatureErp);
            var nomWithRoute = (NomenclatureWithRoute)nom;

            var nomPdm = nomenclatureErp.Nomenclature as NomenclatureObject;
            var routes = nomPdm.GetObjects(NomenclatureObject.RelationKeys.LinkedTP).Where(tech => ((TechnologicalReferenceObject)tech).Class.IsTechRoute).ToList();
            
            List<RoutePlm> tempRoutes = new List<RoutePlm>();
            foreach(var route in routes)
            {
                tempRoutes.Add(RoutePlm.CreateInstance((TechRoute) route));
            }
            nomWithRoute.routePlm = tempRoutes.ToArray();

            return nomWithRoute;
        }
    }
}
