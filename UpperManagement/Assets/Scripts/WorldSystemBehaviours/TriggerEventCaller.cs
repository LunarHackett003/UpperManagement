using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TriggerEventCaller : MonoBehaviour
{
    [SerializeField] UnityEvent enterEvent, exitEvent;
    [SerializeField] bool allowMultipleActivations;
    bool enterEnabled = true, exitEnabled = true;
    [SerializeField] string tagToAccept;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == tagToAccept)
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
        if (collision.tag == tagToAccept)
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
