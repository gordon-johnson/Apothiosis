using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltTeethMovement : MonoBehaviour
{
	public float speed;
	public Vector3 startPos = new Vector3 (0.0f, 0.5f, 0.5f);
	public Vector3 endPos = new Vector3(0.0f, 0.5f, -0.5f);

    void Update()
    {
		transform.localPosition += Vector3.back * Time.deltaTime * speed;
		if (transform.localPosition.z < endPos.z)
		{
			transform.localPosition = startPos;
		}
    }
}
