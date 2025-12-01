using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Commands;
using Entity.Context.Main;
using Entity.Dtos.Parameters.Group;
using Entity.Model.Paramters;
using Microsoft.Extensions.Logging;
using Utilities.Helpers.Validations;

namespace Business.Implements.Commands.Business
{
    public class GroupsCommandBusines : BaseCommandsBusiness<Groups, GroupsDto>, ICommandGroupsServices
    {
        protected readonly ICommadGroups _data;

        public GroupsCommandBusines(
            ICommadGroups data,
            IMapper mapper,
            ILogger<GroupsCommandBusines> _logger,
            IGenericHerlpers helpers,
            AplicationDbContext context
            ) : base(data, mapper, _logger, helpers, context)
        {
            _data = data;
        }

   
        public virtual async Task<bool> ChangeAgendaServies(int id, int? agendaId)
        {
            try
            {
                return await _data.UpdateAgendaAsync(id, agendaId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar la genda del grupo con id: {id}");
                throw;
            }
        }



    }
}
