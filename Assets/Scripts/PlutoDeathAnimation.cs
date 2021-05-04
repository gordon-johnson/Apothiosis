using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlutoDeathAnimation : MonoBehaviour
{


	void Start()
    {

	}

    void Update()
    {
        if (GetComponent<Health>().isDead())
		{
			// Disable components
			GetComponentInChildren<Animator>().Rebind();
			GetComponentInChildren<Animator>().enabled = false;
			GetComponentInChildren<WeaponsHolder>().enabled = false;
			GetComponent<CapsuleCollider>().enabled = false;
			GetComponent<BurrowMovement>().enabled = false;
			GetComponent<BoxCollider>().enabled = false;
			GetComponent<MaterialFlasher>().enabled = false;





		}
    }
}
