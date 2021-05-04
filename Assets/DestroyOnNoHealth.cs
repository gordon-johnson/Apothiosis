using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnNoHealth : MonoBehaviour
{
    public GameObject disable;
    public GameObject enable;
    public BoxCollider altEnable;
    public Health teleporterHealth;
    private Health h;
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
            if (enable) enable.SetActive(true);
            if (altEnable) altEnable.enabled = true;
            if (teleporterHealth) teleporterHealth.takeDamage(teleporterHealth.maxHealth);
            if (disable) disable.SetActive(false);

        }
    }
}
