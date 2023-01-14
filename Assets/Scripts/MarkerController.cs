using System;
using UnityEngine;

public class MarkerController: MonoBehaviour
{
    public static MarkerController instance;

    private void Awake()
    {
        if(instance is null)
            instance = this;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    public void Show()
    {
        gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}