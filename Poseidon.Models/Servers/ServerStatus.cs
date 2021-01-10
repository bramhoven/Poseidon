namespace Poseidon.Models.Servers
{
    public enum ServerStatus
    {
        Failing = -2,
        Offline = -1,
        Unknown = 0,
        Running = 1,
        Slow = 2
    }
}