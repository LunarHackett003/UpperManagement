using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public Character character;
    Animator anim;

    private void Start()
    {
        anim = character.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (anim && character)
        {
            anim.SetBool("light", character.ivars.lightInput);
            anim.SetBool("walking", character.ivars.moveInput != 0);
            anim.SetBool("heavy", character.ivars.heavyInput);
            anim.SetBool("ranged", character.ivars.rangedInput);
            anim.SetBool("jumping", !character.IsGrounded());
        }

        //help
    }

}
