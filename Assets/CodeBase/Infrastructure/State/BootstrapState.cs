using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Infrastructure.Services.SceneLoader;
using CodeBase.Infrastructure.States.CodeBase.Services;

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

        public void Enter()
        {
            _allServices.RegisterSingle<ISceneLoader>(new SceneLoaderServices(_coroutineRunner));
            _allServices.RegisterSingle<IPersistentProgressService>(new PersistentProgress());
            _allServices.RegisterSingle<ISaveLoadService>(new SaveLoadService(_allServices.Single<IPersistentProgressService>()));
            _allServices.RegisterSingle<ISceneLoader>(new SceneLoaderServices(_coroutineRunner));

            _gameStateMachine.Enter<LoadLevelState>();
        }

        public void Exit()
        {
        }
    }
}