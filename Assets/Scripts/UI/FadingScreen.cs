using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class FadingScreen: MonoBehaviour
    {
        public Image fadingImage;

        public void Show()
        {
            gameObject.SetActive(true);
            fadingImage.DOFade(1, 1f);
        }

        public void Hide()
        {
            fadingImage.DOFade(0, 1f).OnKill(() => {gameObject.SetActive(false);});
        }
    }
}