using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Template Movement variables, for use with speed buff ability
/// </summary>
[CreateAssetMenu(fileName = "New TemplateAttack", menuName = "TemplateAttack")]
public class TemplateAttack : ScriptableObject
{
    [SerializeField] public float fireRate;
}
