using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Performs player controller behaviors given controller input
/// </summary>
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAim))]
[RequireComponent(typeof(PlayerAttack))]
[RequireComponent(typeof(PlayerDash))]
[RequireComponent(typeof(PlayerAbility))]
public class PlayerController : MonoBehaviour
{
    [Header("Required")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerAim aim;
    [SerializeField] private PlayerAimUI aimUI;
    [SerializeField] private PlayerAttack attack;
    [SerializeField] private PlayerDash dash;
    [SerializeField] private PlayerAbility ability;
    public int playerNum = -1;
    [Header("Gamepads")]
    private Gamepad gamepad;
    [SerializeField] private ControllerInput input;

    #region Initialization

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        movement = this.GetComponent<PlayerMovement>();
        aim = this.GetComponent<PlayerAim>();
        aimUI = this.GetComponentInChildren<PlayerAimUI>();
        attack = this.GetComponent<PlayerAttack>();
        dash = this.GetComponent<PlayerDash>();
        ability = this.GetComponent<PlayerAbility>();

        input = this.gameObject.AddComponent<ControllerInput>();
        Debug.Log(playerNum);
        input.OnAwake(playerNum);
    }

    #endregion Initialization

    // NOTE: Input was refactored to pull from ControllerInput instance
    private void Update()
    {
        // Movement
        movement.OnInput(rb, input.LS_X, input.LS_Y);
        // Attack
        Vector3 offset = movement.GetVelocity(rb, input.LS_X, input.LS_Y);
        Vector3 rotation = aim.GetRotation(input.RS_X, input.RS_Y, offset);
        attack.OnInput(this.transform, input.RT, offset, rotation);
        aimUI.SetRotation(input.RS_X, input.RS_Y);
        // Dash
        dash.OnInput(rb, input.LT);
        // Ability
        ability.OnInput(this.transform, input.LB || input.RB, rotation);
    }
}

/// <summary>
/// Helper class for reading Xbox controller inputs
/// </summary>
public class ControllerInput : MonoBehaviour
{
    // Button input
    public float LS_X;
    public float LS_Y;
    public float RS_X;
    public float RS_Y;
    public bool RT;
    public bool LT;
    public bool LB;
    public bool RB;
    public bool A;
    public bool B;

    // Controller specification
    public List<Gamepad> gamepads;
    public Gamepad _gamepad;
    private int num;

    public void OnAwake(int controllerNum)
    {
        num = controllerNum;
        gamepads = new List<Gamepad>(Gamepad.all);
        foreach (Gamepad gamepad in gamepads)
            Debug.Log(gamepad.name);
    }

    public void OnUpdate()
    {
        gamepads = new List<Gamepad>(Gamepad.all);
        if (num - 1 < gamepads.Count)
            _gamepad = gamepads[num - 1];
        OnNoGamepadDetected();
    }

    private void Update()
    {
        OnUpdate();

        if (NoGamepadDetected())
            return;

        LS_X = _gamepad.leftStick.x.ReadValue();
        LS_Y = _gamepad.leftStick.y.ReadValue();
        RS_X = _gamepad.rightStick.x.ReadValue();
        RS_Y = _gamepad.rightStick.y.ReadValue();
        RT = _gamepad.rightTrigger.isPressed;
        LT = _gamepad.leftTrigger.wasPressedThisFrame;
        RB = _gamepad.rightShoulder.wasPressedThisFrame;
        LB = _gamepad.leftShoulder.wasPressedThisFrame;
        A = _gamepad.aButton.wasPressedThisFrame;
        B = _gamepad.bButton.wasPressedThisFrame;
    }

    private void OnNoGamepadDetected()
    {
        if (_gamepad == null)
        {
            //Debug.LogError("No gamepad detected for Player " + num.ToString());
        }
    }

    private bool NoGamepadDetected()
    {
        return _gamepad == null;
    }
}