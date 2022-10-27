using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform cameraFollow;
    [SerializeField] Vector3 offset;
    [SerializeField] float lerpSpeed;
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, cameraFollow.position + offset, Time.fixedDeltaTime * lerpSpeed);
    }
}
