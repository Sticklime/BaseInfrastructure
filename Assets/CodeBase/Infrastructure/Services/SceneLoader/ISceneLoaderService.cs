using System;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Services.SceneLoader
{
    public interface ISceneLoader : IService
    {
        UniTask LoadScene(string name);
    }
}