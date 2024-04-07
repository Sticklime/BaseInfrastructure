using CodeBase.Infrastructure.Services.PersistentProgress;

namespace CodeBase.Data
{
    public class PersistentProgress : IPersistentProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}