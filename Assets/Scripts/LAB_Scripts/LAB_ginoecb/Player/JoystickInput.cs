using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInput : MonoBehaviour
{
    [SerializeField] private float deadzone;

    public static JoystickInput instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);
    }

    // Returns a vector 2 of joystick input, accounting for deadzones
    public Vector2 GetJoystickInput(float inputHorizontal, float inputVertical)
    {
        Vector2 input = new Vector2(inputHorizontal, inputVertical);
        input = (input.magnitude < deadzone) ? Vector2.zero : input.normalized * (input.magnitude - deadzone) / (1 - deadzone);
        return input;
    }
}

// Control stick movement heavily influenced by this article: https://www.gamasutra.com/blogs/JoshSutphin/20130416/190541/Doing_Thumbstick_Dead_Zones_Right.php