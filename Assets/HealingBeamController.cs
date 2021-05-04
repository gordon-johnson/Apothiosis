using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingBeamController : MonoBehaviour
{
    public int playerNum;
    [SerializeField] private float expansionRate = 0.5f;
    [SerializeField] private float maxExpansion = 25;
    [SerializeField] private int healthGainedPerTick = 1;
    [SerializeField] private float tickRate = 1;
    [SerializeField] private float pushBack = 3;
    public Transform spawner;
    public Vector3 offset;
    List<GameObject> playersInContact;

    // Start is called before the first frame update
    void Start()
    {
        playersInContact = new List<GameObject>();
        StartCoroutine(HealLoop());
        StartCoroutine(Expand());
       //offset = spawner.position - transform.position;
    }

    private void Update()
    {
        if (spawner)
        {
          //  transform.position = spawner.position - offset;
        }
    }
    // Update is called once per frame
    private IEnumerator Expand()
    {
        while (transform.localScale.z < maxExpansion)
        {
            transform.localScale += new Vector3(0, 0, expansionRate);
            transform.position += transform.forward * (expansionRate / 2);
          //  offset = spawner.transform.position - transform.position;
            yield return new WaitForSeconds(.01f);
        }
    }

    private void OnTriggerEnter(Collider other)
    { 
        playersInContact.Add(other.gameObject);
        
    }

    private void OnTriggerExit(Collider other)
    {
        playersInContact.Remove(other.gameObject);
    }

    private IEnumerator HealLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(tickRate);
            healList();
        }
    }

    private void healList()
    {
        for (int i = 0; i < playersInContact.Count; ++i)
        {
            try
            {
                if (playersInContact[i].CompareTag("Player"))
                {
                    try
                    {
                        playersInContact[i].GetComponent<Health>().takeDamage(-1 * healthGainedPerTick);
                    }
                    catch
                    {

                    }
                    try
                    {
                        playersInContact[i].GetComponentInChildren<Health>().takeDamage(-1 * healthGainedPerTick);
                    }
                    catch
                    {

                    }
                    try
                    {
                        playersInContact[i].GetComponentInParent<Health>().takeDamage(-1 * healthGainedPerTick);
                    }
                    catch
                    {

                    }
                    //  playersInContact[i].transform.parent.position += transform.forward * pushBack;
                } 
            }
            catch
            {
                Debug.Log("Something tried to be healed that couldn't be");
            }
        }
    }


}
