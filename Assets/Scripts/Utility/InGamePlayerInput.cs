using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InGamePlayerInput : MonoBehaviour
{
    [SerializeField]
    private InputActionProperty InputActionProperty;

    private void Update()
    {
        InputActionProperty.action.performed += OnPerformed;
    }

    private void OnPerformed(InputAction.CallbackContext context)
    {
        Debug.Log(context.valueType);
        /*
        if (!typeof(Vector2).IsAssignableFrom(context.valueType))
            return;

        var inputValue = context.ReadValue<Vector2>();

        print($"inputValue{inputValue}");
        */
    }
}
