using UnityEngine;
using UnityEngine.Events;

namespace GameStateMachine
{
    public abstract class BaseState: MonoBehaviour
    {
        public BaseState nextState;
        public UnityEvent onEnter;
        public abstract void Enter();
        public abstract void Exit();
    }
}