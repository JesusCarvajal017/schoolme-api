using Data.Interfaces.Group.Commands;
using Entity.Context.Main;
using Entity.Model.Business;
using Microsoft.Extensions.Logging;

namespace Data.Implements.Commands.Business
{
    public class AcLoadCommandData : BaseGenericCommandsData<AcademicLoad>, ICommanAcademicLoad
    {
        protected readonly ILogger<AcLoadCommandData> _logger;
        protected readonly AplicationDbContext _context;

        public AcLoadCommandData(AplicationDbContext context, ILogger<AcLoadCommandData> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }


    }
}
