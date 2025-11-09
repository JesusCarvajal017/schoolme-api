using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Parameters.Group;
using Entity.Model.Paramters;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Parameters
{
    public class MunicipalityController
       : GenericController<
       Munisipality,
       MunicipalityQueryDto,
       MunicipalityDto>
    {   

        protected readonly IQueryMunicipalityServices _queryMunicipalityServices;


        public MunicipalityController(
            IQueryMunicipalityServices q,
            ICommandService<Munisipality, MunicipalityDto> c)
          : base(q, c) 
        {
            this._queryMunicipalityServices = q;
        }


        [HttpGet("list/{IdDepart}")]
        public async Task<IActionResult> GetUserRolsById(int IdDepart)
        {
            var result = await _queryMunicipalityServices.GetMunicipalitysDepartament(IdDepart);
            return Ok(result);
        }


    }

}
