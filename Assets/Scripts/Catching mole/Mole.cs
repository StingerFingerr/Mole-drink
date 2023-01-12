using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Mole: MonoBehaviour
{
    public InteractableObject onCatch;
    public BoxCollider hitBox;

    public Vector3 topPosition;
    public Vector3 bottomPosition;
    
    private Coroutine _moleAnimation;
    private Tween _currentTween;
    
    private void Awake()
    {
        onCatch.OnPressed += StopAnimation;
    }

    private void StopAnimation()
    {
        onCatch.OnPressed -= StopAnimation;
        
        StopCoroutine(_moleAnimation);
        _currentTween.Kill();
    }

    public void ChangeHole(Hole newHole)
    {
        _moleAnimation = StartCoroutine(SwitchHoleAnimation(newHole));
    }

    private IEnumerator SwitchHoleAnimation(Hole hole)
    {
        Transform tr = transform;
        _currentTween = tr.DOLocalMove(bottomPosition, .2f);
        yield return new WaitForSeconds(.2f);

        hitBox.enabled = false;
        
        tr.parent = hole.transform;
        tr.localPosition = Vector3.down;

        _currentTween = tr.DOLocalMove(topPosition, .3f);
        yield return new WaitForSeconds(.2f);
        hitBox.enabled = true;

    }
}