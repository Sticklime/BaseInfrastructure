using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.Services.SceneLoader
{
    public class SceneLoaderServices : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoaderServices(ICoroutineRunner coroutineRunner) =>
            _coroutineRunner = coroutineRunner;

        public void Load(string name, Action onLoaded = null)
        {
            _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));
        }

        private IEnumerator LoadScene(string nextScene, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);


            while (!waitNextScene.isDone)
            {
                yield return null;
            }

            onLoaded?.Invoke();
        }
    }
    
}