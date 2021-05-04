using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    [SerializeField] private int health;
    public bool isPlayer;
    private bool isInvincible;
    private float invinciblilityTimer;
    public bool alwaysInvincible;
	public GameObject explosion;
	public GameObject respawn;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        isInvincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > maxHealth)
            health = maxHealth;

        if (isInvincible)
        {
            invinciblilityTimer -= Time.deltaTime;
            if (invinciblilityTimer <= 0)
            {
                isInvincible = false;
            }
        }
        if (alwaysInvincible)
        {
            isInvincible = true;
        }
    }

    public int getHealth()
    {
        return health;
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        if (GetComponent<MaterialFlasher>())
        {
            GetComponent<MaterialFlasher>().flash("Hurt", 0.05f);
        }
        if (this.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            setInvincible(0.5f);
            if (GetComponent<MaterialFlasher>())
            {
                GetComponent<MaterialFlasher>().flash("Hurt", 0.5f);
            }
        }
		if (health <= 0 && this.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			GameObject newExplosion = Instantiate(explosion);
			newExplosion.transform.position = transform.position;
		}
    }

    public void setInvincible(float time)
    {
        isInvincible = true;
        invinciblilityTimer = time;
    }

    public bool Invicible()
    {
        return isInvincible;
    }

    public void reset()
    {
        health = maxHealth;
        isInvincible = false;
    }

    public bool isDead()
    {
        return health <= 0;
    }
}
