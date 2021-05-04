using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAtPlayer : MonoBehaviour
{

    GameObject targetPlayer;

    private void Start()
    {
        updateTargetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        updateTargetPlayer();
        transform.LookAt(targetPlayer.transform,Vector3.up);
    }

    private void updateTargetPlayer()
    {
        targetPlayer = GameController.Instance.Players[0];
        int i = 0;
        while (!targetPlayer.active && i < 4)
        {
            i++;
            targetPlayer = GameController.Instance.Players[i];
        }
    }
}
