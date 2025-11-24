using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Querys;
using Entity.Dtos.Business.CompositionAgenda;
using Entity.Dtos.Business.Question;
using Entity.Dtos.Business.Tution;
using Entity.Model.Business;
using Microsoft.Extensions.Logging;
using Utilities.Helpers.Validations;

namespace Business.Implements.Querys.Business
{
    public class CompositionQueryBusiness : BaseQueryBusiness<CompositionAgendaQuestion, CompositionDto>, IQueryCompositionServices
    {
        protected readonly IQueryCompositionAgenda _data;

        public CompositionQueryBusiness(
            IQueryCompositionAgenda data,
            IMapper mapper,
            ILogger<CompositionQueryBusiness> _logger,
            IGenericHerlpers helpers) : base(data, mapper, _logger, helpers)
        {
            _data = data;
        }


        public virtual async Task<IEnumerable<QuestionQueryDto>> AgendaCompsition(int agendaId)
        {
            try
            {
                var entities = await _data.QuerAgendaComposite(agendaId);
                _logger.LogInformation($"Obteniendo todos los registros de {typeof(QuestionQueryDto).Name}");
                return _mapper.Map<IEnumerable<QuestionQueryDto>>(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener registros de {typeof(QuestionQueryDto).Name}: {ex.Message}");
                throw;
            }
        }



    }
}
