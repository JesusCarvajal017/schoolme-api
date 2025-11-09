using Entity.Dtos.Global;
using Entity.Enum;

namespace Entity.Dtos.Especific.DataBasicComplete
{
    public class CompleteDataPersonDto : ABaseDto
    {
        public int? DocumentTypeId { get; set; }
        public string? AcronymDocument { get; set; }
        public long? Identification { get; set; }
        public string? FisrtName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public string? SecondLastName { get; set; }
        public long? Phone { get; set; }
        public GenderEmun? Gender { get; set; }

        public int? RhId { get; set; }
        public string RhName { get; set; }
        public string? Adress { get; set; }
        public string? BrithDate { get; set; }
        public int? StratumStatus { get; set; }

        public int? MaterialStatusId { get; set; }
        public int? EpsId { get; set; }
        public string? EpsName { get; set; }
        public int? MunisipalityId { get; set; }

        public string? MunisipalityName { get; set; }


    }
}
