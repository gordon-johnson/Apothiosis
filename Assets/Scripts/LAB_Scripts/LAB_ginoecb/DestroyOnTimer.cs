using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTimer : MonoBehaviour
{

    public float timer;

    public GameObject[] spawns;


    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            if (spawns.Length > 0)
            {
                foreach(GameObject spawn in spawns)
                {
                    GameObject newSpawn = Instantiate(spawn);
                    newSpawn.transform.position = transform.position;
                }
            }
            Destroy(gameObject);
        }
    }

    public void SetTime(float newTime)
    {
        timer = newTime;
    }
}
