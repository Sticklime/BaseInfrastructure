using CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace CodeBase.TestSDK.Button
{
    public class SaveButton : MonoBehaviour
    {
        private ISaveLoadService _saveLoadService;
        private SaveLimit _saveLimit;

        public void Construct(ISaveLoadService saveLoadService, SaveLimit saveLimit)
        {
            _saveLoadService = saveLoadService;
        }

        public void Save()
        {
            _saveLoadService.SaveProgress();
        }

        public void SaveLimit()
        {
            _saveLimit.StartWaitForSave();
        }
    }
}