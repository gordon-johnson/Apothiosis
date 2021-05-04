using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintUIActivator : MonoBehaviour
{
    public GameObject text;

    private void Start()
    {
        HintUIManager.instance.RegesterText(text);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HintUIManager.instance.DeactivateAllText();
            text.SetActive(true);
        }
        else
        {
            Debug.Log(other.tag);
        }
    }
}
