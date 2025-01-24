using System;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [Header("Target Settings")] public Transform target;
    public Vector3 offset = new(0f, 12f, -8f);

    [Header("Camera Settings")] public float followSpeed = 5f;

    private void Start()
    {
        offset = new Vector3(0f, 12f, -8f);
    }

    private void LateUpdate()
    {
        var desiredPosition = target.position + offset;
        var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed);

        transform.position = smoothedPosition;
        transform.rotation = Quaternion.Euler(50f, 0f, 0f);
    }
}