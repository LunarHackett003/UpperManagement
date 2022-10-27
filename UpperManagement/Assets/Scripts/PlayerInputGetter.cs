using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputGetter : MonoBehaviour
{
    //reference to the character
    Character chc;


    private void Start()
    {
        chc = GetComponentInParent<Character>();
        if (chc) Debug.Log("found character");
    }

    //input methods. just gets the inputs, feeds them to the character.
    public void GetMoveInput(InputAction.CallbackContext context)
    {
        chc.ivars.moveInput = context.ReadValue<float>();
    }
    public void GetVerticalInput(InputAction.CallbackContext context)
    {
        chc.ivars.verticalInput = context.ReadValue<float>();
    }
    public void GetLightAttackInput(InputAction.CallbackContext context)
    {
        chc.ivars.lightInput = context.ReadValue<float>() >= InputSystem.settings.defaultButtonPressPoint;
    }
    public void GetHeavyAttackInput(InputAction.CallbackContext context)
    {
        chc.ivars.heavyInput = context.ReadValue<float>() >= InputSystem.settings.defaultButtonPressPoint;
    }
    public void GetRangedAttackInput(InputAction.CallbackContext context)
    {
        chc.ivars.rangedInput = context.ReadValue<float>() >= InputSystem.settings.defaultButtonPressPoint;
    }

}
