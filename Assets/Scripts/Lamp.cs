using DG.Tweening;
using UnityEngine;

public class Lamp: MonoBehaviour
{
    public Light bulb;
    public float targetBulbIntensity = 20;
    public Light spotLight;
    public float targetSpotLightIntensity = 1;

    public float enablingDuration = 1;
    
    public void EnableLight()
    {
        bulb.DOIntensity(targetBulbIntensity, enablingDuration);
        spotLight.DOIntensity(targetSpotLightIntensity, enablingDuration);
    }
}