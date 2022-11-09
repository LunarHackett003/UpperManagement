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
        InitialiseFollower();
    }

    void InitialiseFollower()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        if (obj)
        {
            cameraFollow = obj.GetComponent<Character>();
        }
    }

    private void FixedUpdate()
    {
        if (cameraFollow)
        {
            transform.position = Vector3.Lerp(transform.position, cameraFollow.transform.position + offset + ((Vector3)cameraFollow.rb.velocity / lookaheadDivider), Time.fixedDeltaTime * lerpSpeed);
        }
        else
        {
            InitialiseFollower();
        }
    }
}
