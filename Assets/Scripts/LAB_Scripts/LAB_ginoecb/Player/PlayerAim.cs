using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private Vector3 prevInput = Vector3.zero; //Vector3.forward;
    [SerializeField] private Vector3 smoothing;
    [SerializeField] private float smoothTime = 0.2f;
    [SerializeField] private float assistAngleMin = 13f;
    [SerializeField] private float assistAngleMax = 20f;
    [SerializeField] private float assistAngle;
    [SerializeField] private LayerMask mask;

    public Vector3 _target;

    // Returns dummy position which player fires at
    public Vector3 GetRotation(float inputHorizontal, float inputVertical, Vector3 offset)
    {
        Vector3 input = GetInputRotation(inputHorizontal, inputVertical, offset);
        _target = input;
        input = Vector3.SmoothDamp(this.transform.rotation.eulerAngles, input, ref smoothing, smoothTime);
        Debug.DrawRay(this.transform.position, input * 5, Color.red);
        return input + this.transform.position;
    }

    public Vector3 GetRotation(float inputHorizontal, float inputVertical)
    {
        Vector3 input = GetInputRotation(inputHorizontal, inputVertical);
        _target = input;
        input = Vector3.SmoothDamp(this.transform.rotation.eulerAngles, input, ref smoothing, smoothTime);
        Debug.DrawRay(this.transform.position, input * 5, Color.red);
        return input + this.transform.position;
    }

    private Vector3 GetInputRotation(float inputHorizontal, float inputVertical, Vector3 offset)
    {
        Vector3 target = CheckPrevRotation(inputHorizontal, inputVertical);

        assistAngle = offset == Vector3.zero ? assistAngleMin : assistAngleMax;

        //Debug.DrawRay(this.transform.position, Quaternion.AngleAxis(-1 * assistAngle, Vector3.up) * target * 50, Color.red);
        //Debug.DrawRay(this.transform.position, Quaternion.AngleAxis(assistAngle, Vector3.up) * target * 50, Color.red);

        RaycastHit hit, hitLeft, hitRight;
        if (Physics.Raycast(this.transform.position, target, out hit, 50, mask))
        {
            return target;
        }
        else if (Physics.Raycast(this.transform.position, Quaternion.AngleAxis(-1 * assistAngle, Vector3.up) * target, out hitLeft, 50, mask))
        {
            target = hitLeft.point - this.transform.position;
            //Debug.Log(target);
        }
        else if (Physics.Raycast(this.transform.position, Quaternion.AngleAxis(-1 * assistAngle/2, Vector3.up) * target, out hitRight, 50, mask))
        {
            target = hitRight.point - this.transform.position;
            //Debug.Log(target);
        }
        else if (Physics.Raycast(this.transform.position, Quaternion.AngleAxis(assistAngle, Vector3.up) * target, out hitRight, 50, mask))
        {
            target = hitRight.point - this.transform.position;
            //Debug.Log(target);
        }
        else if (Physics.Raycast(this.transform.position, Quaternion.AngleAxis(assistAngle/2, Vector3.up) * target, out hitRight, 50, mask))
        {
            target = hitRight.point - this.transform.position;
            //Debug.Log(target);
        }
        return target;
    }

    private Vector3 GetInputRotation(float inputHorizontal, float inputVertical)
    {
        Vector3 target = CheckPrevRotation(inputHorizontal, inputVertical);

        //assistAngle = offset == Vector3.zero ? assistAngleMin : assistAngleMax;
        assistAngle = assistAngleMax;

        //Debug.DrawRay(this.transform.position, Quaternion.AngleAxis(-1 * assistAngle, Vector3.up) * target * 50, Color.red);
        //Debug.DrawRay(this.transform.position, Quaternion.AngleAxis(assistAngle, Vector3.up) * target * 50, Color.red);

        RaycastHit hit, hitLeft, hitRight;
        if (Physics.Raycast(this.transform.position, target, out hit, 50, mask))
        {
            return target;
        }
        else if (Physics.Raycast(this.transform.position, Quaternion.AngleAxis(-1 * assistAngle, Vector3.up) * target, out hitLeft, 50, mask))
        {
            target = hitLeft.point - this.transform.position;
            //Debug.Log(target);
        }
        else if (Physics.Raycast(this.transform.position, Quaternion.AngleAxis(-1 * assistAngle/2, Vector3.up) * target, out hitRight, 50, mask))
        {
            target = hitRight.point - this.transform.position;
            //Debug.Log(target);
        }
        else if (Physics.Raycast(this.transform.position, Quaternion.AngleAxis(assistAngle, Vector3.up) * target, out hitRight, 50, mask))
        {
            target = hitRight.point - this.transform.position;
            //Debug.Log(target);
        }
        else if (Physics.Raycast(this.transform.position, Quaternion.AngleAxis(assistAngle/2, Vector3.up) * target, out hitRight, 50, mask))
        {
            target = hitRight.point - this.transform.position;
            //Debug.Log(target);
        }
        return target;
    }

    private Vector3 CheckPrevRotation(float inputHorizontal, float inputVertical)
    {
        Vector2 joystickInput = new Vector2(inputHorizontal, inputVertical);

        if (joystickInput == Vector2.zero)
            return prevInput;

        Vector3 input = new Vector3(joystickInput.x, 0, joystickInput.y).normalized;

        prevInput = input;
        return input;
    }

    private void DrawAim(Vector3 target)
    {
        Debug.DrawRay(this.transform.position, target, Color.magenta);
        Debug.DrawRay(this.transform.position, Quaternion.AngleAxis(-1 * assistAngle, Vector3.up) * target, Color.magenta);
        Debug.DrawRay(this.transform.position, Quaternion.AngleAxis(-1 * assistAngle / 2, Vector3.up) * target, Color.magenta);
        Debug.DrawRay(this.transform.position, Quaternion.AngleAxis(assistAngle, Vector3.up) * target, Color.magenta);
        Debug.DrawRay(this.transform.position, Quaternion.AngleAxis(assistAngle / 2, Vector3.up) * target, Color.magenta);
    }

    private void Update()
    {
        DrawAim(_target);
    }
}
