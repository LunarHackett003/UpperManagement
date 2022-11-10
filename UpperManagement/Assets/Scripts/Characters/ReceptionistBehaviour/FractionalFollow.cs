using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractionalFollow : MonoBehaviour
{

    [SerializeField] Character cameraFollow;
    [SerializeField] Vector3 offset;
    [SerializeField] float lerpSpeed;
    [SerializeField] float positionDivider;
    [SerializeField] Vector3 startPosition; 
    private void Start()
    {
        InitialiseFollower();
        startPosition = transform.position;
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
            transform.position = Vector3.Lerp(transform.position, new Vector3((cameraFollow.transform.position.x - transform.position.x) / positionDivider , startPosition.y, startPosition.z), Time.fixedDeltaTime * lerpSpeed);
        }

    }
}
