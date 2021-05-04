using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotation : MonoBehaviour
{
	public Vector3 rotation;
	public float speed;

    void Update()
    {
		transform.Rotate(rotation * Time.deltaTime * speed);
    }
}
