using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoESpeed : AoEBase
{
    [Header("Required")]
    [SerializeField] private TemplateMovement defaultSpeed;
    [SerializeField] private TemplateMovement speedBuffSpeed;
    [SerializeField] private TemplateAttack defaultFireRate;
    [SerializeField] private TemplateAttack speedBuffFireRate;

    [Header("Ability")]
    [SerializeField] private float duration;

    protected override void OnTriggerEffect(GameObject other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerMovement>() != null)
                other.GetComponent<PlayerMovement>().ActivateSpeedBuff(defaultSpeed, speedBuffSpeed, duration);

            if (other.GetComponentInParent<PlayerMovement>() != null)
                other.GetComponentInParent<PlayerMovement>().ActivateSpeedBuff(defaultSpeed, speedBuffSpeed, duration);

            if (other.GetComponent<PlayerAttack>() != null)
                other.GetComponent<PlayerAttack>().ActivateSpeedBuff(defaultFireRate, speedBuffFireRate, duration);

            if (other.GetComponentInParent<PlayerAttack>() != null)
                other.GetComponentInParent<PlayerAttack>().ActivateSpeedBuff(defaultFireRate, speedBuffFireRate, duration);



        }
    }
}
