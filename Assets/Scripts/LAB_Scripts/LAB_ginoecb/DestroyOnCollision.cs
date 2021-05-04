using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") == false)
            DestroySelf();
    }

    private void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
