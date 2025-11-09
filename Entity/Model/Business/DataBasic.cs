using Entity.Model.Global;
using Entity.Model.Paramters;
using Entity.Model.Security;

namespace Entity.Model.Business
{
    public class DataBasic : ABaseEntity
    {
        public int PersonId { get; set; }
        public int RhId { get; set; }
        public string Adress { get; set; }
        public DateTime BrithDate { get; set; }
        public int StratumStatus { get; set; }

        public int MaterialStatusId { get; set; }

        public int EpsId { get; set; }
        public int MunisipalityId { get; set; }

        public Person Person { get; set; }
        public Rh Rh { get; set; }
        public Eps Eps { get; set; }
        public Munisipality Munisipality { get; set; }

        public MaterialStatus MaterialStatus { get; set; }

    }
}
