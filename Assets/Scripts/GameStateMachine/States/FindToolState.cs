using System.Collections;
using Cinemachine;
using UI;
using UnityEngine;

namespace GameStateMachine
{
    public class FindToolState: BaseState
    {
        public InteractableObject targetObject;
        public TaskManager taskManager;
        public GameTask findToolTask;
        public FadingScreen fadingScreen;
        public MessageWindow messageWindow;
        
        public CameraManager cameraManager;
        public CinemachineVirtualCameraBase findToolCam;
        
        
        public override void Enter()
        {
            StartCoroutine(FadeDelay());
        }

        private IEnumerator FadeDelay()
        {
            messageWindow.Hide();
            cameraManager.SetActiveVCamera(findToolCam);
            yield return OneSecond();
            onEnter?.Invoke();
            fadingScreen.Hide();
            yield return OneSecond();
            taskManager.SetTask(findToolTask);
            targetObject.OnPressed += ToolFound;
        }

        private void ToolFound()
        {
            targetObject.OnPressed -= ToolFound;
            targetObject.gameObject.SetActive(false);
            taskManager.FinishTask();

            Invoke(nameof(Exit), 1);
        }

        private static WaitForSeconds OneSecond() => 
            new WaitForSeconds(1f);

        public override void Exit()
        {
            
        }
    }
}