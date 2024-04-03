using CodeBase.Infrastructure.State;
using CodeBase.Infrastructure.States.CodeBase.Services;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
{
    private GameStateMachine _gameStateMachine;

    private void Awake()
    {
        _gameStateMachine = new GameStateMachine(new AllServices(), this);

        _gameStateMachine.Enter<BootstrapState>();
    }
}

