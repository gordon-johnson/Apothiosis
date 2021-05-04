using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawningBlockController : MonoBehaviour
{
    private Health h;
    public int respawnTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        h = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (h.getHealth() <= 0)
        {
            StartCoroutine(Hide());
        }
    }

    private IEnumerator Hide()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(respawnTime);
        //could make respawn, but not sure we want to
    }

}
