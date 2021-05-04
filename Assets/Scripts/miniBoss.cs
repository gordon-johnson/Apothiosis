using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniBoss : MonoBehaviour
{
	[SerializeField] private GameObject eye;
	[SerializeField] private Light eyeLight;
	private float minEyeScaleSize = 0.70f;
	private float maxEyeScaleSize = 1.30f;
	private float eyeScaleLight = 2.0f;
	private Vector3 eyeScaleSpeed = Vector3.one * 5.0f;
	private Vector3 minEyeScale;
	private Vector3 maxEyeScale;

	private Vector3 targetPosition;
	public float movementSpeed;
	private bool moving;
	private float waitTimer;
	private float waitTime;

	private WeaponsHolder weapons;

	private void Start()
    {
		minEyeScale = eye.transform.localScale * minEyeScaleSize;
		maxEyeScale = eye.transform.localScale * maxEyeScaleSize;

		moving = false;
		waitTime = 4f;
		waitTimer = 0.1f;

		weapons = GetComponentInChildren<WeaponsHolder>();
	}

    private void Update()
    {
		Spin();
		EyePulse();
		Move();
    }

	private void Spin()
	{
		transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime * 0.5f);
	}

	private void EyePulse()
	{
		if (moving)
		{
			eyeLight.intensity = 0;
		}
		else
		{
			if (eye.transform.localScale.x <= minEyeScale.x || eye.transform.localScale.x >= maxEyeScale.x)
			{
				eyeScaleSpeed *= -1;
				eyeScaleLight *= -1;
			}
			eye.transform.localScale += eyeScaleSpeed * Time.deltaTime;
			eyeLight.intensity += eyeScaleLight * Time.deltaTime;
		}
	}

	private void Move()
	{
		if (!moving)
		{
			weapons.ResumeAll();
			targetPosition = new Vector3(Random.Range(-55.0f, 55.0f), transform.position.y, Random.Range(-30.0f, 30.0f));
            if(GetComponent<Health>().getHealth() < GetComponent<Health>().maxHealth * 0.3f)
            {
                waitTimer -= Time.deltaTime;
            }
			if (waitTimer <= 0.0f)
			{
				moving = true;
				waitTimer = waitTime;
			}
		}

		if (moving)
		{
			weapons.PauseAll();
            float positionY = transform.position.y;
			Vector3 target = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
            transform.position = new Vector3(target.x, positionY, target.z);
			transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

			if (transform.position.x == targetPosition.x && transform.position.z == targetPosition.z)
			{
				moving = false;
				transform.eulerAngles = new Vector3(30.0f, 0.0f, 0.0f);
			}
		}
	}
}
