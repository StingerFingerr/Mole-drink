using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MessageWindow: MonoBehaviour
    {
        public TextMeshProUGUI messageText;
        public TextMeshProUGUI buttonText;
        public Button confirmButton;

        private Action _onConfirm;

        private void Awake()
        {
            confirmButton.onClick.AddListener(Confirm);
        }

        public void ShowMessage(GameMessage message, Action onConfirm = null)
        {
            messageText.text = message.message;
            buttonText.text = message.buttonName;
            _onConfirm = onConfirm;
            gameObject.SetActive(true);
        }

        private void Confirm()
        {
            _onConfirm?.Invoke();
            _onConfirm = null;
            gameObject.SetActive(false);
        }
    }
}