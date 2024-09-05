using MDMEPZ.Dto;
using MDMEPZ.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TFlex.DOCs.Model;
using TFlex.DOCs.Model.References.Nomenclature;
using TFlex.DOCs.References.NomenclatureERP;

namespace MDMEPZ.Service.Integration
{
    /// <summary>
    /// Сервис для формирования ресурсных спецификаций
    /// </summary>
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
                var mdm = nom.GetObject(NomenclatureMDMReferenceObject.RelationKeys.Nomenclature) as NomenclatureMDMReferenceObject;
                var nomDto = Nomenclature.CreateInstance(mdm);
                nomListTemp.Add(nomDto);
            }

            bomDto.nomenclatures = nomListTemp.ToArray();
            var mdmRoot = nomenclature.GetObject(NomenclatureMDMReferenceObject.RelationKeys.Nomenclature) as NomenclatureMDMReferenceObject;
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
                
            }
            return JsonConvert.SerializeObject(routes, Formatting.Indented);
        }
        
    }
}
