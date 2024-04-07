using CodeBase.Data;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Infrastructure.Services.SDK;
using UnityEngine.Device;

namespace CodeBase.Infrastructure.State
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly AllServices _allServices;
        private readonly ISdkServices _sdkServices;
        private readonly ISaveLoadService _saveLoad;

        public LoadProgressState(GameStateMachine gameStateMachine, AllServices allServices)
        {
            _gameStateMachine = gameStateMachine;
            _allServices = allServices;
            _sdkServices = _allServices.Single<ISdkServices>();
            _saveLoad = _allServices.Single<ISaveLoadService>();
        }

        public void Enter()
        {
            LoadProgressOrInitNew();

            _gameStateMachine.Enter<LoadLevelState>();
        }

        public void Exit()
        {
        }

        private async void LoadProgressOrInitNew()
        {
            _allServices.Single<IPersistentProgressService>().Progress = await _saveLoad.LoadProgress() ?? NewProgress();

            if (_sdkServices is ISdkGameReadyServices gameReadyServices)
                gameReadyServices.CallGameReady();
        }

        private PlayerProgress NewProgress()
        {
            return new PlayerProgress();
        }
    }
}