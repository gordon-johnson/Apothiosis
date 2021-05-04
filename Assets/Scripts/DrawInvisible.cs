using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Draws a wire cube that is only visible in the editor Scene, not in game
/// </summary>
public class DrawInvisible : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(this.transform.position, this.transform.localScale);
    }
}
