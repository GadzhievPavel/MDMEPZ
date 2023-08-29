using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMEPZ.Dto
{
    /// <summary>
    ///     Справочник "Спецификации"
    /// </summary>
    public class Specification
    {
        // Наименование
        public string Name { get; set; }
        
        // Обозначение
        public string Denotation { get; set; }
        
        // GUID (1C)
        public string Guid1C { get; set; }
        
        // GUID (T-Flex)
        public string GuidTFlex { get; set;}
        
        // Используемые материалы
        public string ApplicationMaterials { get; set; }
        
        // Единицы измерения
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        
        // Тип номенклатуры
        public TypeOfNomenclature TypeOfNomenclature { get; set; }
        
        // Группа списка
        public GroupOfList GroupOfList { get; set; }
        
        // Тип воспроизводства
        public TypeOfReproduction TypeOfReproduction { get; set; }
        
        // Товарная категория
        public ProductCategory ProductCategory { get; set; }
        
        // Вес
        public double weight { get; set; }

    }
}
