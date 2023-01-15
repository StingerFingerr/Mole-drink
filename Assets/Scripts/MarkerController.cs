using System;
using UnityEngine;

public class MarkerController: MonoBehaviour
{
    public static MarkerController instance;

    public bool IsActive => gameObject.activeSelf;

    private void Awake()
    {
        if(instance is null)
            instance = this;
    }

    private void Start()
    {
        Hide();
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