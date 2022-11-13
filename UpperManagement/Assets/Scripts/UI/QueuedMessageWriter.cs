using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class QueuedMessageWriter : MonoBehaviour
{
    [System.Serializable]
    public class QueuedMessage
    {
        [TextArea]
        public string message;
        public float timeWhenDone;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
