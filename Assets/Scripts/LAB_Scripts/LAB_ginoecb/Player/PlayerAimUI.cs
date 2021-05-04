using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimUI : MonoBehaviour
{
    [SerializeField] private PlayerAim aim;
    private Vector3 prevRotation;

    public void SetRotation(float inputHorizontal, float inputVertical)
    {
        Vector2 joystickInput = JoystickInput.instance.GetJoystickInput(inputHorizontal, inputVertical);
        if (joystickInput == Vector2.zero)
            return;

        //if (inputHorizontal == 0 && inputVertical == 0)
        //    return;

        //Vector3 rotation = aim.GetRotation(inputHorizontal, inputVertical);
        Vector3 rotation = aim.GetRotation(joystickInput.x, joystickInput.y);

        // Lock rotation on y axis
        rotation = new Vector3(rotation.x, this.transform.position.y, rotation.z);
        this.transform.LookAt(rotation);
        this.transform.rotation *= Quaternion.Euler(90, 0, 0);

        // Do not apply new rotation if it is not locked on y axis
        /*if (this.transform.localRotation.eulerAngles.x != 0 || this.transform.localRotation.eulerAngles.y != 0)
        {
            this.transform.LookAt(prevRotation);
            this.transform.rotation *= Quaternion.Euler(90, 0, 0);
            return;
        }*/
        prevRotation = rotation;
    }
}
