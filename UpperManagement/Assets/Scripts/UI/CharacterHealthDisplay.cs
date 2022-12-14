using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealthDisplay : MonoBehaviour
{

    [SerializeField] Slider healthBar;
    [SerializeField] protected DamageableEntity targ;
    [SerializeField] bool playerBar;

    private void Start()
    {
        if (playerBar)
        {
            targ = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        }

        if (healthBar && targ)
        {

            healthBar.maxValue = targ.GetHealth(false);
            healthBar.value = targ.GetHealth(true);
        }
        else { Debug.LogWarning("No player or healthbar found!"); }
    }

    private void FixedUpdate()
    {
        if (healthBar && targ)
        {
            healthBar.value = targ.GetHealth(true);
        }
    }


}
