using UnityEngine;

namespace GameStateMachine
{
    public class GameStateMachine: MonoBehaviour
    {
        public BaseState initialState;

        private BaseState _currentState;

        public void EnterInitialState()
        {
            Enter(initialState);
        }

        public void Enter<TState>(TState state) where TState:  BaseState
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }

    }
}