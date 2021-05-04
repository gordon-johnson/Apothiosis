using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuInput : MonoBehaviour
{
    private List<Gamepad> gamepads;

    private void Update()
    {
        gamepads = new List<Gamepad>(Gamepad.all);
    }

    public bool PressedA()
    {
        foreach (Gamepad gamepad in gamepads)
            if (gamepad.aButton.wasPressedThisFrame) { return true; }

        return false;
    }

    public bool PressedB()
    {
        foreach (Gamepad gamepad in gamepads)
            if (gamepad.bButton.wasPressedThisFrame) { return true; }

        return false;
    }
}
