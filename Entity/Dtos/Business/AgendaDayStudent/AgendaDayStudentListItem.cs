namespace Entity.Dtos.Business.AgendaDayStudent
{
    public class AgendaDayStudentListItem
    {
        public int AgendaDayStudentId { get; set; }
        public int StudentId { get; set; }

        public string FullName { get; set; } = null!;
        public long Document { get; set; }

        public string TypeDocumetation { get; set; } = null!;

        public int AgendaId { get; set; }
    }
}
