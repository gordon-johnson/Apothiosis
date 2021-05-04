using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBossWhenDead : MonoBehaviour
{
    public Health bossHealth;
    private Health thisHealth;
    public int healAmount = 5;
    public float timeBetweenHeals = 2;
    private bool healing = false;
    bool funcCalled = false;
    public BoxCollider bcEnable;
    public BoxCollider bcDisable;

    // Start is called before the first frame update
    void Start()
    {
        thisHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!healing && thisHealth.getHealth() <= 0)
        {
            StartCoroutine(HealBoss());
            healing = true;
        }
        if (!funcCalled && bossHealth.getHealth() <= 0)
        {
            if (bcEnable) bcEnable.enabled = true;
            if (bcDisable) bcDisable.enabled = false;
            funcCalled = true;
        }
    }

    private IEnumerator HealBoss()
    {
        while (thisHealth.getHealth() <= 0)
        {
            bossHealth.takeDamage(-1 * healAmount);
            yield return new WaitForSeconds(2);
        }
        healing = false;
    }
}
