using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// <summary>
/// Template Projectile variables, for use with speed buff ability
/// </summary>
[CreateAssetMenu(fileName = "New TemplateProjectile", menuName = "TemplateProjectile")]
public class TemplateProjectile: ScriptableObject
{
    [SerializeField] public Vector3 localScale;
    [SerializeField] public float speed;
}