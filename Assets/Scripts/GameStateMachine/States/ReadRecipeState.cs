using Cinemachine;
using DG.Tweening;
using UI;
using UnityEngine;

namespace GameStateMachine
{
    public class ReadRecipeState: BaseState
    {
        public InteractableObject recipesBook;
        public GameObject bookFx;
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
            //fadingScreen.Show();
            
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
            PlayBookAnimation();

            Exit();
        }

        private void PlayBookAnimation()
        {
            DOTween.Sequence()
                .Append(recipesBook.transform.DOScale(.7f, .5f))
                .Append(recipesBook.transform.DOScale(0f, .5f))
                .AppendCallback(() =>
                {
                    bookFx.gameObject.SetActive(true);
                    Destroy(recipesBook.gameObject);
                });
        }

        private void Subscribe() => 
            recipesBook.OnPressed += FinishTask;
    }
}