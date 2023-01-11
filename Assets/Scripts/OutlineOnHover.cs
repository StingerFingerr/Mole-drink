using UnityEngine;

public class OutlineOnHover : MonoBehaviour
{
    public Outline outline;
    
    private void OnMouseEnter() => 
        outline.OutlineWidth = 4;

    private void OnMouseExit() => 
        outline.OutlineWidth = 0;
}
