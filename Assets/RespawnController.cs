using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RespawnController : MonoBehaviour
{
    private Health playerHealth;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerAbility ability;
    [SerializeField] private TemplateMovement defaultMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponentInChildren<Health>();
        playerHealth.takeDamage(-1 * playerHealth.maxHealth);

        movement = this.GetComponent<PlayerMovement>();
        ability = this.GetComponent<PlayerAbility>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
       if (playerHealth.getHealth() <= 0)
        {
            // Reset base movement speed
            this.movement.moveInfo = defaultMovement;
            
            // Destroy ability prefab instance
            if (this.ability.isAoE)
            {
                this.GetComponent<PlayerAoEAbility>().ResetAbilityPrefab();
            }

            MultiPlayerRespawner.instance.Respawn(gameObject);
        }
    }
}