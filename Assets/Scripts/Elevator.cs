using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
	public float speed;
	public float minY = -1.0f;
	public float maxY = 10.0f;
	public float waitTime = 5.0f;
	private bool wait = false;
	private float timer = 0.0f;
	public bool up = true;

	public GameObject ArrowUp, ArrowDown;

	void Update()
    {
		if (!wait)
		{
			if (up)
			{
				ArrowUp.SetActive(true);
				ArrowDown.SetActive(false);
				transform.position += Vector3.up * Time.deltaTime * speed;
				if (transform.position.y >= maxY)
				{
					transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
					wait = true;
					up = false;
				}
			}
			else
			{
				ArrowUp.SetActive(false);
				ArrowDown.SetActive(true);
				transform.position += Vector3.down * Time.deltaTime * speed;
				if (transform.position.y <=minY)
				{
					transform.position = new Vector3(transform.position.x, minY, transform.position.z);
					wait = true;
					up = true;
				}
			}
		}
		else
		{
			timer += Time.deltaTime;
			if (timer >= waitTime)
			{
				timer = 0.0f;
				wait = false;
			}
		}
		
	}
}
