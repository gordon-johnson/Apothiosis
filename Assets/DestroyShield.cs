using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShield : MonoBehaviour
{
    [SerializeField] private Health health;

    private void Awake()
    {
        health = this.GetComponent<Health>();
    }

    private void Update()
    {
        if (health.getHealth() <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
