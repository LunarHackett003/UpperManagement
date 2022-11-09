using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public UnityEngine.UI.Image fader;
    [SerializeField] int fadeTime;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    public void SceneLoader(int sceneToLoad)
    {
        StartCoroutine(ScreenFade(sceneToLoad));
    }


    IEnumerator ScreenFade(int sceneToLoad)
    {
        fader.gameObject.SetActive(true);
        float currentFade = 0f;
        while (currentFade < fadeTime)
        {
            currentFade += Time.fixedDeltaTime;
            Color col = new Color(0, 0, 0, currentFade);
            fader.color = col;

            yield return null;
        }
        LoadNextScene(sceneToLoad);
        yield return null;
        while (currentFade > 0)
        {
            currentFade -= Time.fixedDeltaTime;
            Color col = new Color(0, 0, 0, currentFade);
            GameManager.instance.fader.color = col;

            yield return null;
        }
        fader.gameObject.SetActive(false);
        yield return null;
    }

    public void LoadNextScene(int sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }
}
