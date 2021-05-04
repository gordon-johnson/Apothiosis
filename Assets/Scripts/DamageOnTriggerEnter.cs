using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTriggerEnter : MonoBehaviour
{
    public int damage;
    public bool playerFriendly;
    public bool destroyOnCollison = true;
	public bool explode = false;
	public GameObject explosion;

	private float timer;

	private void Start()
	{
		/*
        if (explosion != null)
    		explosion.Stop();
		timer = 0.0f;
		*/
	}

	private void Update()
	{
		if (timer > 0.0f)
		{
			timer -= Time.deltaTime;
			if (timer <= 0.0f)
			{
				Destroy(gameObject);
			}
		}
	}

	private void OnTriggerStay(Collider other)
    {
        if (!other.attachedRigidbody)
        {
            return;
        }
        if (other.attachedRigidbody.GetComponent<Health>() && !other.attachedRigidbody.GetComponent<Health>().Invicible())
        {
            if(other.attachedRigidbody.GetComponent<Health>().isPlayer != playerFriendly)
            {
                other.attachedRigidbody.GetComponent<Health>().takeDamage(damage);
                if (destroyOnCollison)
                {
					if (explode)
					{
                        gameObject.GetComponent<Collider>().enabled = false;
                        gameObject.GetComponent<MeshRenderer>().enabled = false;
						
						if (gameObject.GetComponent<EnemyProjectile>())
						{
							// gameObject.GetComponent<EnemyProjectile>().speed = 0.1f;
						}
						
						if (gameObject.GetComponent<TrailRenderer>()) {
							gameObject.GetComponent<TrailRenderer>().enabled = false;
						}
						// explosion.Play();
						GameObject newExplosion = Instantiate(explosion);
						newExplosion.transform.position = transform.position;
						Destroy(gameObject);
						//timer = explosion.main.startLifetimeMultiplier;
					}
					else
					{
						Destroy(gameObject);
					}
				}
			}
        }
    }
}
