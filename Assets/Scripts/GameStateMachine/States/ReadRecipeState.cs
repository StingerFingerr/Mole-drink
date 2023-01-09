using Cinemachine;
using UI;
using UnityEngine;

namespace GameStateMachine
{
    public class ReadRecipeState: BaseState
    {
        public InteractableObject recipesBook;
        public TaskManager taskManager;
        public MessageWindow messageWindow;
        public ClosableWindow recipe;
        public FadingScreen fadingScreen;

        public CameraManager cameraManager;
        public CinemachineVirtualCameraBase lookingAroundCam;
        public CinemachineVirtualCameraBase readingCam;
        
        public GameTask findRecipeTask;
        public GameMessage readRecipeMessage;
        
        public override void Enter()
        {
            cameraManager.SetActiveVCamera(lookingAroundCam);
            Subscribe();
            SetTask();
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
            
            recipesBook.Interact();

            cameraManager.SetActiveVCamera(readingCam);
            
            taskManager.FinishTask(findRecipeTask);
            messageWindow.ShowMessage(readRecipeMessage, OpenRecipe);
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