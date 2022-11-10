using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDisabler : MonoBehaviour
{

    //Disables GameObjects depending on the presence of certain other objects such as the Game Manager, or if not in the editor.
    [System.Flags]
    enum ObjectPresences
    {
        GameManager = 1 << 1,
        Boss = 1 << 2,
    }

    [SerializeField] ObjectPresences objectPresences = ObjectPresences.GameManager;

    // Start is called before the first frame update
    void Start()
    {
        switch (objectPresences)
        {
            case ObjectPresences.GameManager:
                if (GameManager.instance)
                {
                    gameObject.SetActive(false);
                }
                break;
            case ObjectPresences.Boss:
                
                break;
            default:
                break;
        }
    }
}
