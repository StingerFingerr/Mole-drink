using UnityEngine;
using UnityEngine.Events;

public class ResetableObject: MonoBehaviour
{
    public UnityEvent onReset;

    public void ResetState() => 
        onReset?.Invoke();
}