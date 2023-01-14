using UnityEngine;

public class SoundOnInteract: MonoBehaviour
{
    public AudioSource audioSource;


    private void OnEnable() => 
        InteractableObject.OnClicked += PlaySound;

    private void OnDisable() => 
        InteractableObject.OnClicked -= PlaySound;

    private void PlaySound() => 
        audioSource.Play();
}