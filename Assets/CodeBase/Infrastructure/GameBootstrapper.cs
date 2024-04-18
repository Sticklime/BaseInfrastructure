using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.State;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private GameStateMachine _gameStateMachine;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            
            _gameStateMachine = new GameStateMachine(new AllServices(), this);

            _gameStateMachine.Enter<BootstrapState>();
        }
    }
}

