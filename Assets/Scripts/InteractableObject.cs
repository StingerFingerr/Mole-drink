using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject: MonoBehaviour
{
    public Action OnPressed;
    public List<Component> destroyComponentsOnInteract;
    public UnityEvent onInteract;
    
    private void OnMouseDown()
    {
        OnPressed?.Invoke();
        onInteract?.Invoke();
    }

    public void Interact() => 
        destroyComponentsOnInteract.ForEach(Destroy);
}