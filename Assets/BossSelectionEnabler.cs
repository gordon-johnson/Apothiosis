using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSelectionEnabler : MonoBehaviour
{

    public GameObject boss;
    private Health bossHealth;
    [SerializeField] GameObject plutoPlatform;
    [SerializeField] GameObject marsPlatform;
    // Start is called before the first frame update
    void Start()
    {
        bossHealth = boss.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bossHealth.getHealth() <= 0)
        {
            if (GetComponent<SkipToast>().skipTutorial) { 
                marsPlatform.SetActive(true);
                plutoPlatform.SetActive(true);
            }
            boss.SetActive(false);
        }   
    }
}
