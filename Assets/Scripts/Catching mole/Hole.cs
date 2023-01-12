using DG.Tweening;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public GameObject dustFx;

    public void Show()
    {
        transform.DOScale(1f, .5f);
        dustFx.gameObject.SetActive(true);
    }
        
}