using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelControl : MonoBehaviour
{
    public string levelName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //SceneManager.LoadScene(levelName);
            GameManager.instance.SceneLoader(SceneManager.GetSceneByName(levelName).buildIndex);
        }
    }
}
