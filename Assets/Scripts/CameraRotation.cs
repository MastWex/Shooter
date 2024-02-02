using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float RotationSpeed = 1;
    public float minAngle;
    public float maxAngle;
    public Transform CameraAxisTransform;
    void Start()
    {
        
    }

    void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse X"), 0);
        var newAngleX = Mathf.Clamp(CameraAxisTransform.localEulerAngles.x - Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse Y"), minAngle, maxAngle);
        CameraAxisTransform.localEulerAngles = new Vector3(newAngleX, 0, 0);
    }
}
