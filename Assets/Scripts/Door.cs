using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    public bool usePosChange;
    public Vector3 openedPos;
    public Vector3 closedPos;

    public bool useRotChange;
    public Vector3 openedRot;
    public Vector3 closedRot;

    public float openingDuration = .5f;

    public UnityEvent onOpened;
    public UnityEvent onClosed;
    
    private bool _isOpened;


    public void ToggleState()
    {
        if (_isOpened)
            Close();
        else
            Open();
    }

    public void Open()
    {
        if(_isOpened)
            return;

        _isOpened = true;
        
        if (usePosChange)
            transform.DOLocalMove(openedPos, openingDuration).OnKill(() => _isOpened = true);
        
        if (useRotChange)
            transform.DOLocalRotate(openedRot, openingDuration).OnKill(() => _isOpened = true);
        
        onOpened?.Invoke();
    }

    public void Close()
    {
        if(_isOpened is false)
            return;

        _isOpened = false;
        
        if (usePosChange)
            transform.DOLocalMove(closedPos, openingDuration).OnKill(() => _isOpened = false);
        
        if (useRotChange)
            transform.DOLocalRotate(closedRot, openingDuration).OnKill(() => _isOpened = false);

        onClosed?.Invoke();
    }
}