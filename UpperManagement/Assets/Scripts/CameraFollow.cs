using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Character cameraFollow;
    [SerializeField] Vector3 offset;
    [SerializeField] float lerpSpeed;
    [SerializeField] float lookaheadDivider;
    private void Start()
    {
        cameraFollow = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, cameraFollow.transform.position + offset + ((Vector3)cameraFollow.rb.velocity / lookaheadDivider), Time.fixedDeltaTime * lerpSpeed);
    }
}
