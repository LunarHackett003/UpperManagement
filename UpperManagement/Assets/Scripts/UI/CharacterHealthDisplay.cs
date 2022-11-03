using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealthDisplay : MonoBehaviour
{

    [SerializeField] Slider healthBar;
    [SerializeField] Character player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();


        if (healthBar && player)
        {
            healthBar.maxValue = player.GetHealth(false);
            healthBar.value = player.GetHealth(true);
        }
        else { Debug.LogWarning("No player or healthbar found!"); }
    }

    private void FixedUpdate()
    {
        if (healthBar && player)
        {
            healthBar.value = player.GetHealth(true);
        }
    }


}
