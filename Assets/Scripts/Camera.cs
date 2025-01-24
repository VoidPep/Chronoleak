using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 _velocity = Vector3.zero;
    
    void Update()
    {
        var targetPosition = target.TransformPoint(new Vector3(0, 5, -10));
    
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);
    }
}
