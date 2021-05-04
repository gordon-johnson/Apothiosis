using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBody : MonoBehaviour
{

    private SpiderLeg[] legs;

    public float downTime;
    private float downTimer;

    public float dropDistance;

    // Start is called before the first frame update
    void Start()
    {
        legs = GetComponentsInChildren<SpiderLeg>();
        downTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(downTimer > 0)
        {
            downTimer -= Time.deltaTime;
            if(downTimer <= 0)
            {
                foreach (SpiderLeg leg in legs)
                {
                    leg.Reset();
                    GetComponentInChildren<WeaponsHolder>().ResumeAll();
                }
                transform.position += Vector3.up * dropDistance;
            }
        } else
        {
            bool legAlive = false;
            foreach (SpiderLeg leg in legs)
            {
                if (!leg.isDead())
                {
                    legAlive = true;
                }
            }
            if (!legAlive)
            {
                downTimer = downTime;
                transform.position += Vector3.down * dropDistance;
                GetComponentInChildren<WeaponsHolder>().PauseAll();
            }
        }
    }
}
