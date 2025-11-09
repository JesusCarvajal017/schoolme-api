using Entity.Context.Main;
using Entity.Model.Security;
using Microsoft.Extensions.Logging;

namespace Data.Implements.Querys.Security
{
    public class UserQueryData : BaseGenericQuerysData<User>
    {
        protected readonly ILogger<UserQueryData> _logger;
        protected readonly AplicationDbContext _context;

        public UserQueryData(AplicationDbContext context, ILogger<UserQueryData> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        


    }
}
