using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    [Header("Required")]
    [SerializeField] public PlayerState state;

    [Header("Ability")]
    [SerializeField] public _float cooldown;
    [SerializeField] public _float cooldownMax;
    public bool isAoE;

    public virtual void Awake()
    {
        state = this.GetComponent<PlayerState>();
        //cooldown.Set(cooldownMax.Check());
    }

    public void Update()
    {
        if (cooldown.Check() > 0)
            cooldown -= Time.deltaTime;

    }

    // Instantiate attack prefab in direction of boss
    public void OnInput(Transform transform, bool input, Vector3 rotation)
    {
        if (input == false || cooldown.Check() > 0)
            return;
        cooldown.Set(cooldownMax.Check());
        AbilityFlagStart();
        ActivateAbility(rotation);
    }

    public virtual void ActivateAbility(Vector3 rotation)
    {
        // TODO: Implement functionality in child classes
        Debug.Log("Activated ability");
        // TODO: Make sure the two following lines occur at the very end of the ability's activation
        state.isCastingAbility.Set(false);
        return;
    }

    public virtual void SpawnAbilityPrefab()
    {
        // TODO: Implement functionality in child classes
        return;
    }

    public virtual void SpawnAbilityPrefab(Vector3 rotation)
    {
        // TODO: Implement functionality in child classes
        return;
    }

    public virtual void DespawnAbilityPrefab()
    {
        // TODO: Implement functionality in child classes
        return;
    }

    protected void AbilityFlagStart()
    {
        state.isCastingAbility.Set(true);
    }

    protected void AbilityFlagEnd()
    {
        state.isCastingAbility.Set(false);
    }

    #region Custom Classes

    // int value that requires explicit function calls for read and write
    [System.Serializable]
    public class _float
    {
        [SerializeField] private float variable;

        public float Check()
        {
            return variable;
        }

        public void Set(float value)
        {
            variable = value;
        }

        public _float(float value)
        {
            Set(value);
        }

        #region Overloaded Operators

        public static _float operator +(_float instance, float value)
        {
            instance.variable += value;
            return instance;
        }

        public static _float operator -(_float instance, float value)
        {
            instance.variable -= value;
            return instance;
        }

        #endregion Overloaded Operators
    }

    #endregion Custom Classes

}
