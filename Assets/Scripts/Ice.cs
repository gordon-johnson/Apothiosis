using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
	public float multiplier = 1.0f;

	private void OnCollisionStay(Collision collision)
	{
		collision.rigidbody.velocity *= multiplier;
	}
}
