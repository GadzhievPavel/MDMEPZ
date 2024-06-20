using MDMEPZ.Dto;
using MDMEPZ.Util;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TFlex.DOCs.Model;
using TFlex.DOCs.Model.References.Nomenclature;
using TFlex.DOCs.References.NomenclatureERP;

namespace MDMEPZ.Service.Integration
{
    public class BomService
    {
        private NomenclatureObject nomenclature;
        private HashSet<NomenclatureObject> nomenclatureObjects;
        private At3bootSerializator serializator;
        private ServerConnection connection;
        public BomService(ServerConnection connection, NomenclatureObject rootNom, HashSet<NomenclatureObject> nomenclatures)
        {
            this.connection = connection;
            this.nomenclature = rootNom;
            this.nomenclatureObjects = nomenclatures;
            this.serializator = new At3bootSerializator();
        }

        public string GetBom(string path = null)
        {
            BomDto bomDto = new BomDto();

            List<Nomenclature> nomListTemp = new List<Nomenclature>();
            foreach (var nom in nomenclatureObjects)
            {
                var mdm = nom.GetObject(NomenclatureERPReferenceObject.RelationKeys.Nomenclature) as NomenclatureERPReferenceObject;
                var nomDto = Nomenclature.CreateInstance(mdm);
                nomListTemp.Add(nomDto);
            }

            bomDto.nomenclatures = nomListTemp.ToArray();
            var mdmRoot = nomenclature.GetObject(NomenclatureERPReferenceObject.RelationKeys.Nomenclature) as NomenclatureERPReferenceObject;
            bomDto.nomenclature = NomenclatureWithRoute.CreateInstance(connection ,mdmRoot);

            if (path != null)
            {
                return serializator.saveFile(bomDto, path);
            }
            else
            {
                return JsonConvert.SerializeObject(bomDto, Formatting.Indented);
            }
        }

        public string getRoute(string root)
        {
            List<Route> routes = new List<Route>();
            foreach(var nom in nomenclatureObjects)
            {
                //nom.
            }
            return JsonConvert.SerializeObject(routes, Formatting.Indented);
        }
        
    }
}
