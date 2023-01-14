using System.Collections;
using Cinemachine;
using UI;
using UnityEngine;

namespace GameStateMachine
{
    public class FindMoleState: BaseState
    {
        public InteractableObject moleHidden;
        public GameObject moleInJar;
        
        public TaskManager taskManager;
        public GameTask findMoleTask;

        public MessageWindow messageWindow;
        public GameMessage redMessage;

        public FadingScreen fadingScreen;

        public BoxCollider wall;
        
        public CameraManager cameraManager;
        public CinemachineVirtualCameraBase firstCamera;
        public CinemachineVirtualCameraBase secondCamera;
        public CinemachineVirtualCameraBase lookingAroundCamera;
        
        
        public override void Enter()
        {
            StartCoroutine(FadeDelay());
        }

        private IEnumerator FadeDelay()
        {
            yield return new WaitForSeconds(1f);
            
            cameraManager.SetActiveVCamera(firstCamera);
            onEnter?.Invoke();

            yield return new WaitForSeconds(1f);

            fadingScreen.Hide();
            
            yield return new WaitForSeconds(1.5f);
            
            cameraManager.SetActiveVCamera(secondCamera);

            yield return new WaitForSeconds(1f);
            
            messageWindow.ShowMessage(redMessage);

            yield return new WaitForSeconds(.5f);
            
            taskManager.SetTask(findMoleTask);

            yield return new WaitForSeconds(1f);

            MarkerController.instance.Show();
            
            wall.enabled = false;
            cameraManager.SetActiveVCamera(lookingAroundCamera);

            moleHidden.OnPressed += TakeMole;

        }

        private void TakeMole()
        {
            moleInJar.gameObject.SetActive(true);
            cameraManager.SetActiveVCamera(firstCamera);
            taskManager.FinishTask();

            Invoke(nameof(Exit), 1f);
        }

        public override void Exit()
        {
            nextState.Enter();
        }
    }
}