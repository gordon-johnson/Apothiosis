using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerState))]
public class PlayerAttack : MonoBehaviour
{
    [Header("Required")]
    [SerializeField] private PlayerState state;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject boss;

    [Header("Attack")]
    [SerializeField] private float cooldown;
    [SerializeField] private TemplateAttack attackInfo;
    [SerializeField] private float movementOffset;

    private void Awake()
    {
        state = this.GetComponent<PlayerState>();
    }

    private void Update()
    {
        if (cooldown > 0)
            cooldown -= Time.deltaTime;
    }

    // Instantiate attack prefab in direction of boss
    public void OnInput(Transform transform, bool input, Vector3 offset, Vector3 rotation)
    {
        if (input == false || cooldown > 0)//state.isCastingAbility.Check() || cooldown > 0)
            return;

        cooldown = attackInfo.fireRate;
        GameObject projectileInstance = Instantiate(projectile, this.transform.position, Quaternion.identity);
        projectileInstance.GetComponent<ProjectileMovement>().SetRotation(rotation);
        projectileInstance.transform.position += offset * Time.deltaTime * movementOffset;
        AudioManager.playSound("Laser");
    }

    public void ActivateSpeedBuff(TemplateAttack defaultAttack, TemplateAttack speedBuffAttack, float duration)
    {
        StartCoroutine(ApplySpeedBuff(defaultAttack, speedBuffAttack, duration));
    }

    private IEnumerator ApplySpeedBuff(TemplateAttack defaultAttack, TemplateAttack speedBuffAttack, float duration)
    {
        attackInfo = speedBuffAttack;
        yield return new WaitForSeconds(duration);
        attackInfo = defaultAttack;
    }

}
