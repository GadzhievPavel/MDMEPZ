using MDMEPZ.Dto.Integration.Route;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFlex.DOCs.Model;
using TFlex.DOCs.Model.References.Nomenclature;
using TFlex.DOCs.References.NomenclatureERP;
using TFlex.Model.Technology.References.TechnologyElements;
using TFlex.Technology.References;

namespace MDMEPZ.Dto
{
    /// <summary>
    /// DTO номенклатура c маршрутом. наследует поля у Nomenclature
    /// </summary>
    public class NomenclatureWithRoute: Nomenclature
    {
        /// <summary>
        /// Маршрут
        /// </summary>
        public RoutePlm[] routePlm { get; set; }

        
        public new static NomenclatureWithRoute CreateInstance(ServerConnection connection, NomenclatureERPReferenceObject nomenclatureErp)
        {
            var nom = Nomenclature.CreateInstance(nomenclatureErp);
            var nomWithRoute = new NomenclatureWithRoute();

            nomWithRoute.guid1C = nom.guid1C;
            nomWithRoute.groupOfList = nom.groupOfList;
            nomWithRoute.financialGroup = nom.financialGroup;
            nomWithRoute.weight = nom.weight;
            nomWithRoute.isTypical = nom.isTypical;
            nomWithRoute.category = nom.category;
            nomWithRoute.codeElamed = nom.codeElamed;
            nomWithRoute.denotation = nom.denotation;
            nomWithRoute.name = nom.name;
            nomWithRoute.guidTFlex = nom.guidTFlex;
            nomWithRoute.typeNomenclature = nom.typeNomenclature;
            nomWithRoute.typeOfReproduction = nom.typeOfReproduction;
            nomWithRoute.unitOfMeasurement = nom.unitOfMeasurement;
            nomWithRoute.weightUnitOfMeasurement = nom.weightUnitOfMeasurement;

            var nomPdm = nomenclatureErp.Nomenclature as NomenclatureObject;
            var routes = nomPdm.GetObjects(NomenclatureObject.RelationKeys.LinkedTP).Where(tech => ((TechnologicalReferenceObject)tech).Class.IsTechRoute).ToList();
            
            List<RoutePlm> tempRoutes = new List<RoutePlm>();
            foreach(var route in routes)
            {
                tempRoutes.Add(RoutePlm.CreateInstance(connection,(TechRoute) route));
            }
            nomWithRoute.routePlm = tempRoutes.ToArray();

            return nomWithRoute;
        }
    }
}
