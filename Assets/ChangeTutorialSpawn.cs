using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTutorialSpawn : MonoBehaviour
{
    public int respawnIndex = -1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MultiPlayerRespawner.instance.respawnLoc = respawnIndex;
        }
    }
}
