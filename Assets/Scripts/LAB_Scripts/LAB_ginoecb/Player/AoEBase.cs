using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoEBase : MonoBehaviour
{
    [SerializeField] private List<GameObject> playersAffected;

    private void Start()
    {
        //Debug.Log(this.transform.parent.name);
        if (this.transform.parent != null)
        {
            Debug.Log(this.gameObject.GetComponentInParent<PlayerAoEAbility>().attachAsChild);

            if (this.transform.parent.GetComponent<PlayerAoEAbility>() != null && this.gameObject.GetComponentInParent<PlayerAoEAbility>().attachAsChild)
            {
                OnTriggerEffect(this.transform.parent.gameObject);
            }
        }
    }

    // Base class for activating AoE on player
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerAlreadyAffected(other.attachedRigidbody.gameObject))
                return;
            OnTriggerEffect(other.attachedRigidbody.gameObject);
            playersAffected.Add(other.attachedRigidbody.gameObject);
        }
    }

    protected virtual void OnTriggerEffect(GameObject other)
    {
        Debug.Log("Contact with " + other.name);
    }

    // Returns true if player has already been affected by AoE
    private bool PlayerAlreadyAffected(GameObject player)
    {
        for (int i = 0; i < playersAffected.Count; i++)
        {
            if (playersAffected[i] == player)
            {
                return true;
            }
        }
        return false;
    }
}
