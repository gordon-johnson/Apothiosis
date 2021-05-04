using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBeamAbility : PlayerAoEAbility
{
    [SerializeField] private float spawnDistance;

    public override void SpawnAbilityPrefab(Vector3 rotation)
    {
        AoEInstance = Instantiate(AoEPrefab, this.transform.position, Quaternion.identity);
        SetRotation(AoEInstance, rotation);
        AoEInstance.transform.position += AoEInstance.transform.forward * spawnDistance;
        AoEInstance.transform.parent = transform;
       // AoEInstance.GetComponent<HealingBeamController>().spawner = transform;
    }

    private void SetRotation(GameObject obj, Vector3 position)
    {
        obj.transform.LookAt(position);
    }
}
