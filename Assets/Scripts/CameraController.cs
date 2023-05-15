using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target;
    public float gap = 5f;

    float rotX;
    float rotY;

    public float minVerAngle = -3f;
    public float maxVerAngle = 75f;
    public Vector2 framingBalance;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {

        rotX += Input.GetAxis("Mouse Y");
        rotX = Mathf.Clamp(rotX, minVerAngle,maxVerAngle);
        rotY += Input.GetAxis("Mouse X");

        var targetRotation = Quaternion.Euler(rotX,rotY,0);

        var focusPos = Target.position + new Vector3(framingBalance.x, framingBalance.y);

        transform.position = focusPos - targetRotation * new Vector3(0,0,gap);
        transform.rotation = targetRotation;

    }

    public Quaternion flatRotation => Quaternion.Euler(0,rotY, 0);
}
