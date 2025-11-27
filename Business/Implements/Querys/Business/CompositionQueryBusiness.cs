using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Querys;
using Entity.Dtos.Business.CompositionAgenda;
using Entity.Dtos.Business.Question;
using Entity.Dtos.Business.QuestionOption;
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


        public virtual async Task<IEnumerable<QuestionCompositionQueryDto>> AgendaCompsition(int agendaId)
        {
            try
            {
                var entities = await _data.QuerAgendaComposite(agendaId);
                _logger.LogInformation($"Obteniendo todos los registros de {typeof(QuestionCompositionQueryDto).Name}");
                return _mapper.Map<IEnumerable<QuestionCompositionQueryDto>>(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener registros de {typeof(QuestionCompositionQueryDto).Name}: {ex.Message}");
                throw;
            }
        }

        public async Task<List<QuestionCompositionQueryDto>> GetQuestionsByAgendaAsync(int agendaId, CancellationToken ct = default)
        {
            var questions = await _data.GetQuestionsByAgendaAsync(agendaId, ct);

            var result = questions
                .Where(q => q.Status == 1)
                .Select(q => new QuestionCompositionQueryDto
                {
                    Id = q.Id,
                    Text = q.Text,
                    TypeAnswerId = q.TypeAnswerId,
                    NameAnswer = q.TypeAswer.Name,
                    Status = q.Status,   // 👈 si lo tienes en el DTO

                    Options = q.QuestionOptions
                        .Where(o => o.Status == 1)
                        .Select(o => new QuestionOptionCompositionDto
                        {
                            Id = o.Id,
                            QuestionId = o.QuestionId,  // 👈 ahora sí
                            Text = o.Text,
                            Order = o.Order,
                            Status = o.Status           // 👈 ahora sí
                        })
                        .ToList()
                })
                .ToList();

            return result;
        }


    }
}
