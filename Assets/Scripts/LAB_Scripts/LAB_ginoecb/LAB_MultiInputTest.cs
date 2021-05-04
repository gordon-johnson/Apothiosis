using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class LAB_MultiInputTest : MonoBehaviour
{

    [SerializeField] private List<Gamepad> gamepads;

    private void Awake()
    {
    }

    private void Update()
    {
        gamepads = new List<Gamepad>(Gamepad.all);
        /*
        foreach (Gamepad gamepad in gamepads)
            Debug.Log(gamepad.name);
        */

        for (int i = 0; i < gamepads.Count; i++)
        {
            Debug.Log(i + " " + gamepads[i].name);
        }

        var gp = gamepads[0];
        if (gp.aButton.wasPressedThisFrame)
        {
            Debug.Log("Pressed A button");
        }
    }
}
