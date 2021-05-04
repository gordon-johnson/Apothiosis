using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltPlayerMover : MonoBehaviour
{
	public float speed = 0.5f;

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			other.gameObject.transform.parent.position += Vector3.back * Time.deltaTime * speed;
		}
	}
}
