using Entity.Enum;

namespace Utilities.helpers
{
    public static class DaysExtensions
    {

        private static readonly (Days flag, string text)[] Map =
        {
            (Days.Monday,    "Lunes"),
            (Days.Tuesday,   "Martes"),
            (Days.Wednesday, "Miércoles"),
            (Days.Thursday,  "Jueves"),
            (Days.Friday,    "Viernes"),
            (Days.Saturday,  "Sábado"),
            (Days.Sunday,    "Domingo"),
        };

        public static IEnumerable<string> ToTexts(this Days flags) =>
            Map.Where(x => flags.HasFlag(x.flag)).Select(x => x.text);

    }
}
