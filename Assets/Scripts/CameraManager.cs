using Cinemachine;
using UnityEngine;

public class CameraManager: MonoBehaviour
{
    private CinemachineVirtualCameraBase _currentCamera;

    public void SetActiveVCamera(CinemachineVirtualCameraBase camera)
    {
        _currentCamera?.gameObject.SetActive(false);
        _currentCamera = camera;
        _currentCamera.gameObject.SetActive(true);
    }
}