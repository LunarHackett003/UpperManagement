using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TriggerEventCaller : MonoBehaviour
{
    [SerializeField] UnityEvent enterEvent, exitEvent;
    [SerializeField] bool allowMultipleActivations;
    bool enterEnabled = true, exitEnabled = true;
    
    [System.Flags]
    public enum Tags
    {
        Player = 1 << 1,
        Enemy = 1 << 2,
    }

    [SerializeField] Tags tagToAccept;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == tagToAccept.ToString())
        {

            if (enterEnabled)
            {
                enterEvent.Invoke();
                if (!allowMultipleActivations)
                {
                    enterEnabled = false;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == tagToAccept.ToString())
        {
            if (exitEnabled)
            {
                exitEvent.Invoke();
                if (!allowMultipleActivations)
                {
                    exitEnabled = false;
                }
            }
        }
    }
}
