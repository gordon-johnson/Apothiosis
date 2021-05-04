using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallShake : MonoBehaviour
{
	public float mag;
    void Update()
    {
		if (GetComponent<ParticleSystem>().isEmitting)
		{
			Camera.main.GetComponent<Shaker>().shake = true;
			Camera.main.GetComponent<Shaker>().mag = mag;
		}
		else
		{
			Camera.main.GetComponent<Shaker>().shake = false;
		}
	}
	private void OnDestroy()
	{
		Camera.main.GetComponent<Shaker>().shake = false;
	}
}
