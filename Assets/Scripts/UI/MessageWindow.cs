using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MessageWindow: MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioClip messageClip;
        
        public Color greenColor;
        public Color orangeColor;
        public Color redColor;

        public TextMeshProUGUI messageText;
        public Image backgroundImage;

        public float fadingTextDuration = 1;
        public float fadingBackDuration = 1;

        private Sequence _disabling;
        
        public void ShowMessage(GameMessage message)
        {
            gameObject.SetActive(false);
            
            _disabling?.Kill();
            backgroundImage.color = GetColor(message.type);
            messageText.text = message.message;
            messageText.color = Color.black;
            
            audioSource.Play();

            gameObject.SetActive(true);
            DisableVia(message.messageDuration);
        }

        public void Hide() => 
            gameObject.SetActive(false);


        private void DisableVia(float time)
        {
            _disabling = DOTween.Sequence()
                .AppendInterval(time)
                .Append(messageText.DOFade(0, fadingTextDuration))
                .Join(backgroundImage.DOFade(0, fadingBackDuration))
                .AppendCallback(() => { _disabling = null; Hide();});
        }

        private Color GetColor(MessageType messageType) =>
            messageType switch
            {
                MessageType.Red => redColor,
                MessageType.Green => greenColor,
                _ => orangeColor
            };
    }
}