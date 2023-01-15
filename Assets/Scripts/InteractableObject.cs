using System;
using System.Collections;
using UI;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject: MonoBehaviour
{
    public MessageWindow messageWindow;
    public GameMessage interactMessage;

    public static Action OnClicked;
    public Action OnPressed;
    public UnityEvent onInteract;

    private bool _nextMessageAllowed = true;
    private bool _isActive;
    
    private void OnMouseUp()
    {
        if (_isActive is false)
            return;
        if(UiController.IsUiClicked)
            return;
        if(Time.timeScale == 0)
            return;

        ShowMessage();
        OnClicked?.Invoke();
        OnPressed?.Invoke();
        onInteract?.Invoke();
    }

    private void OnEnable() => 
        _isActive = true;

    private void OnDisable() => 
        _isActive = false;

    private void ShowMessage()
    {
        if(messageWindow is null)
            return;
        if(_nextMessageAllowed is false)
            return;
        _nextMessageAllowed = false;
        
        messageWindow?.ShowMessage(interactMessage);
        StartCoroutine(ResetNextMessageFlag(interactMessage.messageDuration));
    }

    private IEnumerator ResetNextMessageFlag(float duration)
    {
        yield return new WaitForSeconds(duration);
        _nextMessageAllowed = true;
    } 

}