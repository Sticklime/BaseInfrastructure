using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Infrastructure.States.CodeBase.Services;

namespace CodeBase.Infrastructure.State
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly AllServices _allServices;

        public LoadProgressState(GameStateMachine gameStateMachine, AllServices allServices)
        {
            _gameStateMachine = gameStateMachine;
            _allServices = allServices;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();

            _gameStateMachine.Enter<LoadLevelState>();
        }

        public void Exit()
        {
            
        }

        private void LoadProgressOrInitNew()
        {
            _allServices.Single<IPersistentProgressService>().Progress =
                _allServices.Single<SaveLoadService>().LoadProgress()
                ?? NewProgress();
        }

        private PlayerProgress NewProgress()
        {
            return new PlayerProgress();
        }
    }
}