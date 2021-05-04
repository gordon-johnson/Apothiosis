using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DestroyAtPosition))]
public class ProjectileMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;

    // Moves projectile towards cached boss position
    private void Update()
    {
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    // Sets rotation of projectile given boss' current position
    public void SetRotation(Vector3 position)
    {
        this.transform.LookAt(position);
    }
}
