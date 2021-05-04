using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClassSwitch : MonoBehaviour
{
    public bool isShield = false;
    public bool isBeam = false;
    public bool isSpeed = false;
    public bool isAoE = false;
    private int selection = -1;
    // Start is called before the first frame update
    void Start()
    {
        if (isShield)
        {
            selection = 0;
        }
        else if (isBeam)
        {
            selection = 1;
        }
        else if (isSpeed)
        {
            selection = 2;
        }
        else if (isAoE)
        {
            selection = 3;
        }
        else
        {
            Debug.LogWarning("Box Class Switch not set");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int playerNum = other.attachedRigidbody.gameObject.GetComponent<PlayerController>().playerNum;
            if (CharacterSelector.instance.selections[playerNum - 1] == selection)
            {
                return;
            }
            Debug.Log("creating player");
            Vector3 playerPosition = other.attachedRigidbody.gameObject.transform.position;
            CharacterSelector.instance.SwitchPlayer(selection, playerPosition, playerNum);
            Destroy(other.attachedRigidbody.gameObject);
        }
    }


}
