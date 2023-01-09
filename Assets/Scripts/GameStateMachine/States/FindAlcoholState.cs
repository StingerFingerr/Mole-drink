using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinemachine;
using UI;
using UnityEngine;

namespace GameStateMachine
{
    public class FindAlcoholState: BaseState
    {
        public FadingScreen fadingScreen;

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
            fadingScreen.Hide();
        }


        public override void Exit()
        {
            
        }
    }
}