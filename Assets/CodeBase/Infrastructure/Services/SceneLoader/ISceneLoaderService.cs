using System;

namespace CodeBase.Infrastructure.Services.SceneLoader
{
    public interface ISceneLoader : IService
    {
        void Load(string name, Action onLoaded = null);
    }
}