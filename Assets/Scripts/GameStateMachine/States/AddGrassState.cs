using System.Collections;
using Cinemachine;
using UI;
using UnityEngine;

namespace GameStateMachine
{
    public class AddGrassState: BaseState
    {
        public TaskManager taskManager;
        public GameTask addGrassTask;

        public InteractableObject drink;
        public GameObject grass;

        public CameraManager cameraManager;
        public CinemachineVirtualCameraBase drinkCamera;

        public GameObject effects;

        public override void Enter()
        {
            taskManager.SetTask(addGrassTask);
            drink.OnPressed += FinishCooking;
        }

        private void FinishCooking()
        {
            taskManager.FinishTask();
            drink.OnPressed -= FinishCooking;
            grass.gameObject.SetActive(true);
            effects.gameObject.SetActive(true);

            StartCoroutine(FinishAnimation());
        }

        private IEnumerator FinishAnimation()
        {
            cameraManager.SetActiveVCamera(drinkCamera);

            yield return new WaitForSeconds(1f);
            
            Exit();
        }

        public override void Exit()
        {
            nextState.Enter();
        }
    }
}