using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target;
    public float speed = 5;
    private Vector3 _startDistance;
    
    private void Start()
    {
        _startDistance = transform.position - target.position;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + _startDistance, Time.deltaTime * speed);
    }
}
