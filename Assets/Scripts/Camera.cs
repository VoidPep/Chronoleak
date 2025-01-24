using System;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target;
    public Vector3 offset = new(0f, 2f, -5f);

    [Header("Camera Settings")]
    public float followSpeed = 5f;
    public float rotationSpeed = 10f;

    private void LateUpdate()
    {
        var targetPosition = target.position + target.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        var targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}