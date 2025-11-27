namespace Entity.Dtos.Business.CompositionAgenda
{
    public class QuestionOptionCompositionDto
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; } = null!;
        public int? Order { get; set; }
        public int Status { get; set; }

    }
}
