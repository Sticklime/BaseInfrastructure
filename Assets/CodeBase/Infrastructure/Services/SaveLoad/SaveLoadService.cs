using System.Collections;
using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SDK;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly IPersistentProgressService _progressService;
        private readonly IRawData _rawData;

        public SaveLoadService(IRawData rawData)
        {
            _rawData = rawData;
        }

        public async UniTask SaveProgress() =>
            await _rawData.Save(_progressService.Progress.ToJson());

        public async UniTask<PlayerProgress> LoadProgress() =>
            (await _rawData.FetchData())?.ToDeserialized<PlayerProgress>();
    }
    
    public class SaveLimit : IService
    {
        private readonly ISaveLoadService _saveLoadService;

        private bool _isSave;

        public SaveLimit(ICoroutineRunner coroutineRunner, ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
            coroutineRunner.StartCoroutine(WaitForSave());
        }

        public void StartWaitForSave() => 
            _isSave = true;

        private IEnumerator WaitForSave()
        {
            while (true)
            {
                yield return new WaitUntil(() => _isSave);

                yield return new WaitForSeconds(3);
                
                _isSave = false;
                _saveLoadService.SaveProgress();
            }
        }
    }
}