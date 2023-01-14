using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameStateMachine
{
    public class TimeLapsState: BaseState
    {
        public FadingScreen fadingScreen;
        public Animator curtainsAnimator;
        public TextMeshProUGUI daysText;
        public MeshRenderer drinkMesh;
        public int requiredDays = 40;
        public List<GameObject> effects;

        public float initialTimeBetweenDayTiks = .4f;
        public float accel = .015f;
        public float minTimeBetweenDayTiks = .1f;

        public Color targetColor;

        public MessageWindow messageWindow;
        public GameMessage onHideMessage;
        
        public Button hideButton;
        public Button continueButton;

        private int _currentDay = 0;
        
        private static readonly int Show = Animator.StringToHash("Show");
        private static readonly int Hide = Animator.StringToHash("Hide");

        public override void Enter()
        {
            curtainsAnimator.gameObject.SetActive(true);
            curtainsAnimator.SetTrigger(Show);

            ColorChanging();
            StartCoroutine(DaysCounting());
            
            onEnter?.Invoke();
        }

        private void ColorChanging()
        {
            float time = 0;
            float delta = initialTimeBetweenDayTiks;
            for (int i = 0; i < requiredDays; i++)
            {
                time += delta;
                
                if(delta > minTimeBetweenDayTiks)
                    delta -= accel;
            }
            
            drinkMesh.material.DOColor(targetColor, time);
        }

        private IEnumerator DaysCounting()
        {
            daysText.gameObject.SetActive(true);
            for (int i = 0; i < requiredDays; i++)
            {
                yield return new WaitForSeconds(initialTimeBetweenDayTiks);
                _currentDay++;
                daysText.text = $"Прошло дней: {_currentDay}";

                if(initialTimeBetweenDayTiks > minTimeBetweenDayTiks)
                    initialTimeBetweenDayTiks -= accel;
            }

            daysText.gameObject.SetActive(false);
            curtainsAnimator.SetTrigger(Hide);

            yield return new WaitForSeconds(.5f);

            hideButton.transform.parent.gameObject.SetActive(true);
            hideButton.onClick.AddListener(ShowOnHideMessage);
            
            //StartCoroutine(PlayEffects());
        }

        private void ShowOnHideMessage()
        {
            hideButton.onClick.RemoveListener(ShowOnHideMessage);
            messageWindow.ShowMessage(onHideMessage);
            
            Invoke(nameof(ShowRetryButton), 2f);
        }

        private void ShowRetryButton()
        {
            continueButton.onClick.AddListener(Exit);
            continueButton.transform.parent.gameObject.SetActive(true);
        }

        private IEnumerator PlayEffects()
        {
            foreach (var effect in effects)
            {
                yield return new WaitForSeconds(.5f);
                effect.gameObject.SetActive(true);
            }

            Invoke(nameof(Exit), 2f);
        }

        public override void Exit()
        {
            continueButton.onClick.RemoveListener(Exit);

            effects.ForEach(e => e.gameObject.SetActive(false));
            fadingScreen.Show();
            
            nextState.Enter();
        }
    }
}