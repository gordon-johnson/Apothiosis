using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
	private Transform target;
	private Vector3 initialPos;
	public bool shake;
	public float mag;

	private void Start()
    {
		target = GetComponent<Transform>();
		initialPos = target.localPosition;
		shake = true;
    }

	private void Update()
	{
		if (shake)
		{
			Vector3 randomPos = new Vector3(initialPos.x + Random.Range(-mag, mag), initialPos.y + Random.Range(-mag, mag), initialPos.z);
			target.localPosition = randomPos;
		}
		else
		{
            target.localPosition = initialPos;
		}
	}
}
