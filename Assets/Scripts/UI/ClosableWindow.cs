using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ClosableWindow: MonoBehaviour
    {
        [SerializeField]private Button closeButton;

        private Action _onClose;

        private void Awake()
        {
            closeButton.onClick.AddListener(Close);
        }

        public void Open(Action onClosed)
        {
            _onClose = onClosed;
            gameObject.SetActive(true);
        }

        public void Close()
        {
            _onClose?.Invoke();
            _onClose = null;
            gameObject.SetActive(false);
        }
    }
}