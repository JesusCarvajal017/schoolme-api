using Entity.Enum;
using Entity.Model.Business;

namespace Utilities.Helpers.Core
{
    public static class GroupDirectorHelpers
    {
        public static AgendaDayStateEnum GetAgendaOperation(GroupDirector s)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);

            var todayAgenda = s.Groups.AgendaDay?
                .FirstOrDefault(ad => ad.Date == today);

            if (todayAgenda == null)
                return AgendaDayStateEnum.NotInitialized;

            if (todayAgenda.ClosedAt == null)
                return AgendaDayStateEnum.Open;

            return AgendaDayStateEnum.Closed;
        }
    }
}
