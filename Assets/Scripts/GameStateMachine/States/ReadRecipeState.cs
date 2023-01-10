using Cinemachine;
using UI;

namespace GameStateMachine
{
    public class ReadRecipeState: BaseState
    {
        public InteractableObject recipesBook;
        public TaskManager taskManager;
        public ClosableWindow recipe;
        public FadingScreen fadingScreen;

        public CameraManager cameraManager;
        public CinemachineVirtualCameraBase lookingAroundCam;
        public CinemachineVirtualCameraBase readingCam;
        
        public GameTask findRecipeTask;
        
        public override void Enter()
        {
            cameraManager.SetActiveVCamera(lookingAroundCam);
            Subscribe();
            SetTask();
            onEnter?.Invoke();
        }

        public override void Exit()
        {
            fadingScreen.Show();
            
            nextState?.Enter();
        }

        private void SetTask() => 
            taskManager.SetTask(findRecipeTask);

        private void FinishTask()
        {
            recipesBook.OnPressed -= FinishTask;
            
            cameraManager.SetActiveVCamera(readingCam);
            
            taskManager.FinishTask();
            
            OpenRecipe();
        }

        private void OpenRecipe()
        {
            recipe.Open(Continue);
        }

        private void Continue()
        {
            Destroy(recipesBook.gameObject);
            
            Exit();
        }

        private void Subscribe() => 
            recipesBook.OnPressed += FinishTask;
    }
}