using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ClosableWindow: MonoBehaviour
    {
        public Action OnClose;
        [SerializeField]private Button closeButton;

        private void Awake()
        {
            closeButton.onClick.AddListener(() => OnClose?.Invoke());
        }
    }
}