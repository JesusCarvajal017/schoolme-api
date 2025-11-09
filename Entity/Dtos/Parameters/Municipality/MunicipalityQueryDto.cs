using Entity.Dtos.Global;

namespace Entity.Dtos.Parameters.Group
{
    public class MunicipalityQueryDto : ABaseDto
    {
        public string? Name { get; set; }

        public int? DepartamentId { get; set; }

        public string? DepartamentName { get; set; }


    }

}
