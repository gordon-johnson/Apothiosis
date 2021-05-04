using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Template Movement variables, for use with speed buff ability
/// </summary>
[CreateAssetMenu(fileName = "New TemplateMovement", menuName = "TemplateMovement")]
public class TemplateMovement : ScriptableObject
{
    [SerializeField] public float moveSpeed;
    [SerializeField] public float dashSpeed;
}
