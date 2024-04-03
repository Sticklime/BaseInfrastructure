using CodeBase.Infrastructure.Services.SceneLoader;
using CodeBase.Infrastructure.States.CodeBase.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.State
{
    public class LoadLevelState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly AllServices _services;
    
        private Camera _camera;

        public LoadLevelState(GameStateMachine gameStateMachine, AllServices services)
        {
            _gameStateMachine = gameStateMachine;
            _services = services;
        }

        public void Enter()
        {
            _services.Single<ISceneLoader>().Load("MainScene", InitLevel);
        }

        public void Exit()
        {
        }

        private void InitLevel()
        {
            InitCamera();
        }

        private void InitCamera()
        {
            _camera = Camera.main;
        }
    }
}