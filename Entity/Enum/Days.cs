namespace Entity.Enum
{

    [Flags]
    public enum Days
    {
        None = 0,             // 0000000
        Monday = 1,          // 0000001
        Tuesday = 2,        // 0000010
        Wednesday = 4,     // 0000100
        Thursday = 8,     // 0001000
        Friday = 16,     // 0010000
        Saturday = 32,  // 0100000
        Sunday = 64    // 1000000
    }
}
