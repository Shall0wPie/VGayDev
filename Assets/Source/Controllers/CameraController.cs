using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float smoothness = 0.3f;
    public Vector3 offset;
    public Quaternion rotation;

    private Transform target;
    private Vector3 offsetPosition;
    private Vector3 velocity;


    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
        transform.SetPositionAndRotation(target.position + offset, rotation);
    }

    void Update()
    {
        offsetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, offsetPosition, ref velocity, smoothness);
    }
}
