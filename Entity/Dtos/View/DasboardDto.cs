namespace Entity.Dtos.View
{
    public class PieUsuariosDto
    {
        public int Docentes { get; set; }
        public int Estudiantes { get; set; }
        public int Acudientes { get; set; }
    }

    public class MesAgendasDto
    {
        public string Label { get; set; } = default!; 
        public int AgendasCreadas { get; set; }
        public int AgendasConfirmadas { get; set; }
    }

    public class SemanaConfirmacionesDto
    {
        public string Label { get; set; } = default!; 
        public int Confirmaciones { get; set; }
    }

    public class DashboardDto
    {
        public PieUsuariosDto PieUsuarios { get; set; } = default!;
        public List<MesAgendasDto> AgendasMensuales { get; set; } = new();
        public List<SemanaConfirmacionesDto> ConfirmacionesSemanales { get; set; } = new();
    }

}
