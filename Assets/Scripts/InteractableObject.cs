using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject: MonoBehaviour
{
    public MessageWindow messageWindow;
    public GameMessage interactMessage;
    
    public Action OnPressed;
    public UnityEvent onInteract;

    private bool _nextMessageAllowed = true;
    private bool _isActive;
    
    private void OnMouseDown()
    {
        if (_isActive is false)
            return;
        ShowMessage();
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