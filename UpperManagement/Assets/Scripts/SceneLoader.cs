using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] bool loadOnStart;

    [SerializeField] int sceneIndex;
    [SerializeField] int fadeTime;


    private void Start()
    {
        if (loadOnStart)
        {
            LoadNextScene();
        }
    }


    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }


    IEnumerator ScreenFade()
    {
        float currentFade = 0f;

        while (currentFade < fadeTime)
        {
            currentFade += Time.fixedDeltaTime;


            yield return null;
        }
        LoadNextScene();
        yield return null;
    }
}
