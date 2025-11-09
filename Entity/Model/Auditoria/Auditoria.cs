namespace Entity.Model.Auditoria
{
    public class Auditoria
    {

        public int Id { get; set; }
        public string OperationType { get; set; }
        public string CommandText { get; set; }
        public string ParametersJson { get; set; }
        public string AffectedEntities { get; set; }
        public long DurationMs { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
