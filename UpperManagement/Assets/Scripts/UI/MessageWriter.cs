using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageWriter : MonoBehaviour
{
    [SerializeField] bool writeOnStart;
    [TextArea] public string stringToWrite;
    [SerializeField] float characterWriteWait;
    [SerializeField] UnityEngine.UI.Text textToWriteTo;

    private void Start()
    {
        if (writeOnStart)
        {
            StartWriting();
        }
    }

    public void StartWriting()
    {
        StartCoroutine(WriteText());
    }

    IEnumerator WriteText()
    {
        textToWriteTo.text = "";
        for (int i = 0; i < stringToWrite.Length; i++)
        {
            textToWriteTo.text += stringToWrite[i];
            yield return new WaitForSeconds(characterWriteWait);
        }
        yield return null;
    }

}
