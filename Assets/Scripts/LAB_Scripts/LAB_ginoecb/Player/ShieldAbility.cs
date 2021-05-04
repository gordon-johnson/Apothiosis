using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAbility : PlayerAoEAbility
{
    [SerializeField] private float spawnDistance;

    public override void SpawnAbilityPrefab(Vector3 rotation)
    {
        base.SpawnAbilityPrefab(rotation);
        SetRotation(AoEInstance, rotation);
        AoEInstance.transform.position += AoEInstance.transform.forward * spawnDistance + Vector3.up * 2;
    }
    
    private void SetRotation(GameObject obj, Vector3 position)
    {
        obj.transform.LookAt(position);
    }
}
