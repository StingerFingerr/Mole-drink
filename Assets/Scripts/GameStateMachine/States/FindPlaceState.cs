using UI;

namespace GameStateMachine
{
    public class FindPlaceState: BaseState
    {
        public InteractableObject targetObject;
        public TaskManager taskManager;
        public GameTask findPlaceTask;
        
        
        public override void Enter()
        {
            targetObject.OnPressed += Exit;

            taskManager.SetTask(findPlaceTask);
            
            onEnter?.Invoke();
        }

        public override void Exit()
        {
            targetObject.OnPressed -= Exit;
            nextState.Enter();
        }
    }
}