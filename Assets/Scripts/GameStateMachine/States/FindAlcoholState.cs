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
        public Vector3 positionOnTable;
        
        public FadingScreen fadingScreen;
        public TaskManager taskManager;
        public GameTask findAlcoholTask;
        public MessageWindow messageWindow;


        public CameraManager cameraManager;
        public CinemachineVirtualCameraBase lookingAroundCam;

        public List<GameObject> gameObjectsToEnable;


        public override void Enter() => 
            StartCoroutine(FadeDelay());

        private IEnumerator FadeDelay()
        {
            yield return new WaitForSeconds(1f);
            gameObjectsToEnable.ForEach(o => o.SetActive(true));
            cameraManager.SetActiveVCamera(lookingAroundCam);

            messageWindow.Hide();
            fadingScreen.Hide();

            yield return new WaitForSeconds(1f);
            taskManager.SetTask(findAlcoholTask);

            targetObject.OnPressed += AlcoholFound;
            
            onEnter?.Invoke();
        }

        public override void Exit() => 
            nextState.Enter();

        private void AlcoholFound()
        {
            targetObject.OnPressed -= AlcoholFound;
            var spirit = targetObject.transform;
            spirit.parent = null;
            spirit.position = positionOnTable;
            
            taskManager.FinishTask();
            
            Exit();
        }
    }
}