using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UI;
using UnityEngine;

namespace GameStateMachine
{
    public class FindGrassState: BaseState
    {
        public TaskManager taskManager;
        public GameTask task;
        public FadingScreen fadingScreen;
        
        public InteractableObject garden;
        public List<GameObject> grasses;

        public override void Enter()
        {
            onEnter?.Invoke();

            StartCoroutine(FadeDelay());
        }

        private IEnumerator FadeDelay()
        {
            yield return new WaitForSeconds(1f);
            fadingScreen.Hide();
            
            taskManager.SetTask(task);
            
            garden.OnPressed += CollectGrass;
        }

        private void CollectGrass()
        {
            garden.OnPressed -= CollectGrass;

            StartCoroutine(CollectingGrassAnimation());
        }

        private IEnumerator CollectingGrassAnimation()
        {
            foreach (var grass in grasses)
            {
                grass.gameObject.SetActive(false);
                yield return new WaitForSeconds(.5f);
            }

            Exit();
        }

        public override void Exit()
        {
            taskManager.FinishTask();
            nextState.Enter();
        }
    }
}