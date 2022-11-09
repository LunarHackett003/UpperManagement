using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] bool loadOnStart;

    [SerializeField] int sceneIndex;

    

    private void Start()
    {
        if (loadOnStart)
        {
            TriggerSceneLoad();
        }
    }
    public void TriggerSceneLoad()
    {
        GameManager.instance.SceneLoader(sceneIndex);
    }

}
