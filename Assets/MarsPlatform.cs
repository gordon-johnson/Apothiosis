using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarsPlatform : MonoBehaviour
{
    public Health Mars;
	public GameObject e1, e2, g1, g2;

    public float time;

    private float timer;

    private bool activated;

    public float moveDistance;

    private void Start()
    {
		timer = time;
		activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Mars.getHealth() < Mars.maxHealth * 0.20f && !activated)
        {
            activated = true;
        }
        if(timer > 0 && activated)
        {
			g1.GetComponent<GearRotation>().rotation.y = 1;
			g2.GetComponent<GearRotation>().rotation.y = -1;
			transform.RotateAroundLocal(Vector3.up, (360 / time) * Time.deltaTime * Mathf.Deg2Rad);
            transform.position += Vector3.up * (moveDistance / time) * Time.deltaTime;
            timer -= Time.deltaTime;
        }
		if (timer <= 0)
		{
			e1.SetActive(true);
			timer -= Time.deltaTime;
		}
		if (timer <= -3)
		{
			e2.SetActive(true);
		}
	}
}
