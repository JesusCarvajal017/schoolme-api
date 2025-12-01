namespace Entity.Dtos.Business.AgendaDayStudent
{
    public class AgendaDayStudentListDto
    {
        public int AgendaDayStudentId { get; set; }
        public int StudentId { get; set; }

        public string FullName { get; set; } = null!;
        public string? Document { get; set; }

        public string? TypeDocumetation { get; set; }
        public int AgendaId { get; set; }

    }
}
