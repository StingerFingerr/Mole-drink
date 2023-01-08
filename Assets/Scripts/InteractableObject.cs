using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject: MonoBehaviour
{
    public Action OnPressed;
    public List<Component> destroyComponentsOnInteract;

    private void OnMouseDown() => 
        OnPressed?.Invoke();

    public void Interact() => 
        destroyComponentsOnInteract.ForEach(Destroy);
}