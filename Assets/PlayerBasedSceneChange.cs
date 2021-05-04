using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBasedSceneChange : MonoBehaviour
{
    [SerializeField] bool isLevel1 = false;
    [SerializeField] bool isLevel2 = false;
    [SerializeField] bool isLevel3 = false;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Enter();
        }
        else
        {
            Debug.Log(other.tag);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Exit();
        }
    }

    private void Enter()
    {
        if (isLevel1)
        {
            LevelSelectManager.instance.Add1();
        }
        else if (isLevel2)
        {
            LevelSelectManager.instance.Add2();
        }
        else
        {
            LevelSelectManager.instance.Add3();
        }
    }

    private void Exit()
    {
        if (isLevel1)
        {
            LevelSelectManager.instance.Subtract1();
        }
        else if (isLevel2)
        {
            LevelSelectManager.instance.Subtract2();
        }
        else
        {
            LevelSelectManager.instance.Subtract3();
        }
    }
}
