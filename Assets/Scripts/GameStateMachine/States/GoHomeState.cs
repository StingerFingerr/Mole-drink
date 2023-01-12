using UI;

namespace GameStateMachine
{
    public class GoHomeState: BaseState
    {
        public TaskManager taskManager;
        public GameTask goHomeTask;
        public FadingScreen fadingScreen;
        
        public InteractableObject house;
        
        public override void Enter()
        {
            taskManager.SetTask(goHomeTask);

            house.OnPressed += Exit;
            
            onEnter?.Invoke();
        }

        public override void Exit()
        {
            house.OnPressed -= Exit;
            
            fadingScreen.Show();
            
            nextState.Enter();
        }
    }
}