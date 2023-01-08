using System;
using UnityEngine;

public class OutlineOnHover : MonoBehaviour
{
    public Outline outline;
    
    private void OnMouseEnter()
    {
        outline.enabled = true;
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
    }
}
