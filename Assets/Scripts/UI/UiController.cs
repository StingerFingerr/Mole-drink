using UnityEngine;

namespace UI
{
    public class UiController: MonoBehaviour
    {
        public GameObject settings;

        public static bool IsUiClicked { get; private set; }


        public static UiController instance;

        private void Awake()
        {
            if (instance is null)
                instance = this;
        }

        public void SetUiClicked()
        {
            IsUiClicked = true;
            Invoke(nameof(ResetUiClicked), .5f);
        }

        private void ResetUiClicked()
        {
            IsUiClicked = false;
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (settings.gameObject.activeSelf)
                    settings.gameObject.SetActive(false);
                else
                    settings.gameObject.SetActive(true);
            }
        }
    }
}