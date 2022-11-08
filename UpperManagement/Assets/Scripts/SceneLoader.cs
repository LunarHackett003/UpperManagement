using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] bool loadOnStart;

    [SerializeField] int sceneIndex;
    private void Start()
    {
        if (loadOnStart)
        {

        }
    }


    public void LoadNextScene()
    {

    }
}
