using Cinemachine;
using UI;
using UnityEngine;

namespace GameStateMachine
{
    public class FindDoorState: BaseState
    {
        public InteractableObject targetObject;
        public TaskManager taskManager;
        public GameTask findDoorTask;
        public FadingScreen fadingScreen;

        public CameraManager cameraManager;
        public CinemachineVirtualCameraBase lookingAroundCam;

        public override void Enter()
        {
            cameraManager.SetActiveVCamera(lookingAroundCam);
            taskManager.SetTask(findDoorTask);

            targetObject.OnPressed += GoOutside;
            
            onEnter?.Invoke();
        }

        public override void Exit() => 
            nextState.Enter();

        private void GoOutside()
        {
            targetObject.OnPressed -= GoOutside;
            taskManager.FinishTask();
            fadingScreen.Show();
            Invoke(nameof(Exit), 1);
        }
    }
}