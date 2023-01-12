using System.Collections;
using UI;
using UnityEngine;

namespace GameStateMachine
{
    public class MolePlusSpiritState: BaseState
    {
        public TaskManager taskManager;
        public GameTask task;

        public FadingScreen fadingScreen;

        public InteractableObject mole;
        public InteractableObject spirit;
        public InteractableObject moleAndSpirit;

        private bool _moleIsReady;
        private bool _spiritIsReady;
        
        
        public override void Enter()
        {
            StartCoroutine(FadeDelay());

            mole.OnPressed += () => { _moleIsReady = true; MakeDrink();};
            spirit.OnPressed += () => { _spiritIsReady = true; MakeDrink();};
        }

        public void MakeDrink()
        {
            if (_moleIsReady && _spiritIsReady)
            {
                mole.gameObject.SetActive(false);
                spirit.gameObject.SetActive(false);
                moleAndSpirit.gameObject.SetActive(true);
                
                Invoke(nameof(Exit), 1f);
            }
        }
        
        private IEnumerator FadeDelay()
        {
            yield return new WaitForSeconds(1f);

            onEnter?.Invoke();
            fadingScreen.Hide();

            yield return new WaitForSeconds(1f);

            taskManager.SetTask(task);

        }

        public override void Exit()
        {
            taskManager.FinishTask();
            
            nextState.Enter();
        }
    }
}