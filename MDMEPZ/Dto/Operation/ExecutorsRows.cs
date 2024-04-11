namespace ClassLibrary1.Dto
{
    /// <summary>
    /// Строки в исполнителях
    /// </summary>
    public class ExecutorsRows
    {
        public int НомерСтроки { get; set; }
        public Profession Профессия { get; set; }
        public TypeJobs РазрядРабот { get; set; }
        public Tarif ТарифнаяСетка { get; set; }
        public bool ИспользоватьФормулу { get; set; }
        public int КоличествоИсполнителей { get; set; }

    }
}