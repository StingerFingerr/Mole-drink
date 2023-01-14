using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UI;
using UnityEngine;

namespace GameStateMachine
{
    public class FindAlcoholState: BaseState
    {
        public InteractableObject targetObject;
        
        public FadingScreen fadingScreen;
        public TaskManager taskManager;
        public GameTask findAlcoholTask;
        public MessageWindow messageWindow;


        public CameraManager cameraManager;
        public CinemachineVirtualCameraBase lookingAroundCam;

        public override void Enter() => 
            StartCoroutine(FadeDelay());

        private IEnumerator FadeDelay()
        {
            yield return new WaitForSeconds(2f);
            cameraManager.SetActiveVCamera(lookingAroundCam);

            targetObject.OnPressed += AlcoholFound;
            messageWindow.Hide();
            //fadingScreen.Hide();

            yield return new WaitForSeconds(1f);
            taskManager.SetTask(findAlcoholTask);
            onEnter?.Invoke();
        }

        public override void Exit() => 
            nextState.Enter();

        private void AlcoholFound()
        {
            targetObject.OnPressed -= AlcoholFound;
            
            taskManager.FinishTask();

            MarkerController.instance.Show();
            
            Exit();
        }
    }
}