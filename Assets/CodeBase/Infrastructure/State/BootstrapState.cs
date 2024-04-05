using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.States.CodeBase.Services;
using CodeBase.Infrastructure.Services.SceneLoader;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Infrastructure.Services.SDK;

namespace CodeBase.Infrastructure.State
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly AllServices _allServices;
        private readonly ICoroutineRunner _coroutineRunner;

        public BootstrapState(GameStateMachine gameStateMachine, ICoroutineRunner coroutineRunner, AllServices allServices)
        {
            _gameStateMachine = gameStateMachine;
            _allServices = allServices;
            _coroutineRunner = coroutineRunner;
        }

        public async void Enter()
        {
            _allServices.RegisterSingle<ISdkServices>( new YandexSdk());
            _allServices.RegisterSingle<ISceneLoader>(new SceneLoaderServices(_coroutineRunner));
            _allServices.RegisterSingle<IPersistentProgressService>(new PersistentProgress());
            _allServices.RegisterSingle<ISaveLoadService>(new SaveLoadService(_allServices.Single<IPersistentProgressService>()));
            _allServices.RegisterSingle<ISceneLoader>(new SceneLoaderServices(_coroutineRunner));
            
            await _allServices.Single<ISdkServices>().InitSDK();
            
            _gameStateMachine.Enter<LoadProgressState>();
        }

        public void Exit()
        {
        }
    }
}