using System;
using UnityEngine;

public class MouseRotation: MonoBehaviour
{
    public float minXAngle;
    public float maxXAngle;

    public bool useYClamp = true;
    public float minYAngle;
    public float maxYAngle;

    public static float sensitivity = 40;

    public Vector3 initialRotation;

    private float _rotationX;
    private float _rotationY;

    private void Awake()
    {
        transform.localEulerAngles = initialRotation;
        _rotationX = initialRotation.x;
        _rotationY = initialRotation.y;
    }

    private void LateUpdate()
    {
        _rotationX -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        _rotationY += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        _rotationX = Mathf.Clamp(_rotationX, minXAngle, maxXAngle);
        if(useYClamp)
            _rotationY = Mathf.Clamp(_rotationY, minYAngle, maxYAngle);

        transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);


    }
}