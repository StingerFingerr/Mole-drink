using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class BackButton: MonoBehaviour
    {
        public Button button;
        
        private void OnEnable()
        {
            button.onClick.AddListener(OnClicked);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {
            UiController.instance.SetUiClicked();
        }
    }
}