using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Business.DataBasic;
using Entity.Model.Business;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Business
{
    public class DataBasicController
       : GenericController<
       DataBasic,
       DataBasicDto,
       DataBasicDto>
    {
        public DataBasicController(
            IQueryServices<DataBasic, DataBasicDto> q,
            ICommandService<DataBasic, DataBasicDto> c)
          : base(q, c) { }
    }

}
