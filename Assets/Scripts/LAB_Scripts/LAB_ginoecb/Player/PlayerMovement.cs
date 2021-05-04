using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls player movement behavior given left control stick input
/// </summary>
[RequireComponent(typeof(PlayerState))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Required")]
    [SerializeField] private PlayerState state;
   [Space]

    [Header("Movement")]
    [SerializeField] public TemplateMovement moveInfo;

    private void Awake()
    {
        state = this.GetComponent<PlayerState>();
    }

    public void OnInput(Rigidbody rb, float inputHorizontal, float inputVertical)
    {
        if (state.isDashing.Check())
        {
            rb.velocity = rb.velocity.normalized * moveInfo.dashSpeed;
            return;
        }

        rb.velocity = GetVelocity(rb, inputHorizontal, inputVertical);
    }

    public Vector3 GetVelocity(Rigidbody rb, float inputHorizontal, float inputVertical)
    {
        Vector2 joystickInput = JoystickInput.instance.GetJoystickInput(inputHorizontal, inputVertical);
        return new Vector3(joystickInput.x, 0, joystickInput.y) * moveInfo.moveSpeed;
        //return input.normalized * moveInfo.moveSpeed;
    }

    public void ActivateSpeedBuff(TemplateMovement defaultSpeed, TemplateMovement speedBuffSpeed, float duration)
    {
        StartCoroutine(ApplySpeedBuff(defaultSpeed, speedBuffSpeed, duration));
    }

    private IEnumerator ApplySpeedBuff(TemplateMovement defaultSpeed, TemplateMovement speedBuffSpeed, float duration)
    {
        moveInfo = speedBuffSpeed;
        yield return new WaitForSeconds(duration);
        moveInfo = defaultSpeed;
    }

}
