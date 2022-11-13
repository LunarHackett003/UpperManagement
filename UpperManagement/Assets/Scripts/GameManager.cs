using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public Image levelFader;
    public CanvasGroup deathScreenGroup;
    [SerializeField] int fadeTime;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    public void SceneLoader(int sceneToLoad)
    {
        StartCoroutine(LevelFade(sceneToLoad));
    }


    IEnumerator LevelFade(int sceneToLoad)
    {
        levelFader.gameObject.SetActive(true);
        float currentFade = 0f;
        while (currentFade < fadeTime)
        {
            currentFade += Time.fixedDeltaTime;
            Color col = new Color(0, 0, 0, currentFade);
            levelFader.color = col;

            yield return null;
        }
        LoadNextScene(sceneToLoad);
        yield return null;
        while (currentFade > 0)
        {
            currentFade -= Time.fixedDeltaTime;
            Color col = new Color(0, 0, 0, currentFade);
            GameManager.instance.levelFader.color = col;

            yield return null;
        }
        levelFader.gameObject.SetActive(false);
        yield return null;
    }

    public void TriggerDeath()
    {
        StartCoroutine(DeathScreenFade());
    }
    IEnumerator DeathScreenFade()
    {
        deathScreenGroup.gameObject.SetActive(true);
        float currentFade = 0f;
        while (currentFade < fadeTime)
        {
            currentFade += Time.fixedDeltaTime / 4;
            deathScreenGroup.alpha = Mathf.InverseLerp(0, fadeTime, currentFade);
            yield return null;
        }
        yield return new WaitForSeconds(fadeTime);
        SceneLoader(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        yield return null;
        while (currentFade > 0)
        {
            currentFade -= Time.fixedDeltaTime / 2;
            deathScreenGroup.alpha = Mathf.InverseLerp(0, fadeTime, currentFade);
            yield return null;
        }
        deathScreenGroup.gameObject.SetActive(false);
        yield return null;
    }

    public void LoadNextScene(int sceneIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }
}
