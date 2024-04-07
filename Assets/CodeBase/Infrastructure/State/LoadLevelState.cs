using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.SceneLoader;
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

        public async void Enter()
        {
            await _services.Single<ISceneLoader>().LoadScene("MainScene");

            InitLevel();
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