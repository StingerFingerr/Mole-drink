using DG.Tweening;
using UnityEngine;

namespace GameStateMachine
{
    public class CreditsState: BaseState
    {
        public RectTransform creditsTransform;
        public Vector2 targetCreditsPos;
        public float creditsDuration;
        
        public override void Enter()
        {
            Invoke(nameof(ShowCredits), 1f);
        }

        public void ShowCredits()
        {
            creditsTransform.transform.parent.gameObject.SetActive(true);
            creditsTransform.DOLocalMove(targetCreditsPos, creditsDuration).SetEase(Ease.Linear);
        }

        public override void Exit()
        {
            
        }
    }
}