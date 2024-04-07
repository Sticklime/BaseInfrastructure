using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadService : IService
    {
        UniTask SaveProgress();
        UniTask<PlayerProgress> LoadProgress();
    }
}