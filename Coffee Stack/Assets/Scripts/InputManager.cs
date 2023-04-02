using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Action<float> onAnyTouch;

    public void Touch(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            onAnyTouch(ctx.ReadValue<float>());
        }
        else if(ctx.canceled)
        {
            onAnyTouch(0);
        }
    }
}
