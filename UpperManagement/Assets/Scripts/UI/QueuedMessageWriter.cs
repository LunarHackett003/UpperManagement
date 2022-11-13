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

    [SerializeField]
    MessageWriter mWriter;
    public List<QueuedMessage> messages = new List<QueuedMessage>();
    int messageIndex;
    public UnityEvent eventWhenFinished;
    // Start is called before the first frame update
    void Start()
    {
        messageIndex = 0;
        mWriter.stringToWrite = messages[messageIndex].message;
    }

    private void FixedUpdate()
    {
        
    }

    public void TriggerWriteDelay()
    {
        mWriter.StartWriting();
        StartCoroutine(WriteDelay());
    }
    void InvokeEvent()
    {
        eventWhenFinished.Invoke();
    }

    IEnumerator WriteDelay()
    {

        yield return new WaitForSeconds(messages[messageIndex].timeWhenDone);
        messageIndex++;
        if (messageIndex < messages.Count)
        {
            mWriter.stringToWrite = messages[messageIndex].message;
            TriggerWriteDelay();
            yield return null;
        }
        else
        {
            mWriter.stringToWrite = "";
            mWriter.StartWriting();
            InvokeEvent();
            yield return null;
        }
        yield return null;
    }

}
