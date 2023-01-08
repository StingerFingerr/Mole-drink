using UnityEngine;

namespace GameStateMachine
{
    public abstract class BaseState: MonoBehaviour
    {
        public BaseState nextState;
        public abstract void Enter();
        public abstract void Exit();
    }
}