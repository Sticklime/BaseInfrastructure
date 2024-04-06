using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.Services.SceneLoader
{
    public class SceneLoaderServices : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoaderServices(ICoroutineRunner coroutineRunner) =>
            _coroutineRunner = coroutineRunner;

        public async UniTask LoadScene(string nextScene)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
                throw new ArgumentException("Scene is loaded");

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);


            await waitNextScene;
        }
    }
}