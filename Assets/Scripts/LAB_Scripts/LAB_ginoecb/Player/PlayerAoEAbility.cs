using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAoEAbility : PlayerAbility
{
    [Header("Required")]
    public GameObject AoEPrefab;
    public GameObject AoEInstance;

    [Header("Ability")]
    [SerializeField] private float AoEDuration;
    public bool attachAsChild;

    public override void Awake()
    {
        base.Awake();
        isAoE = true;
    }

    public override void ActivateAbility(Vector3 rotation)
    {
        StartCoroutine(SpawnAoE(rotation));
        AbilityFlagEnd();
    }

    private IEnumerator SpawnAoE(Vector3 rotation)
    {
        SpawnAbilityPrefab(rotation);
        yield return new WaitForSeconds(this.AoEDuration);
        DespawnAbilityPrefab();
    }

    public override void SpawnAbilityPrefab(Vector3 rotation)
    {
        AoEInstance = attachAsChild ? Instantiate(AoEPrefab, this.transform.position, Quaternion.identity, this.transform) : Instantiate(AoEPrefab, this.transform.position, Quaternion.identity);
        AoEInstance.GetComponent<DestroyOnTimer>().SetTime(AoEDuration);
    }

    public override void DespawnAbilityPrefab()
    {
        Destroy(AoEInstance);
        AoEInstance = null;
    }

    public void ResetAbilityPrefab()
    {
        DespawnAbilityPrefab();
        cooldown.Set(0);
    }
}
