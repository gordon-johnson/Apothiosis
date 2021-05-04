using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSpammer : MonoBehaviour
{
    public GameObject ringPrefab;
    public float delay = 5;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(MakeRing());
    }

    IEnumerator MakeRing()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            Instantiate(ringPrefab, transform.position, Quaternion.identity);
        }
    }
}
