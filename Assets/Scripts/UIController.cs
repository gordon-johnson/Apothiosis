using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Slider HealthBar;
    private float timer;
    public GameObject trackedObject;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar.value = 1;
        timer = MultiPlayerRespawner.instance.respawnTime + 1;
        if (!trackedObject)
        {
            Debug.LogWarning("No Tracked Object");
        }
    }


    // Update is called once per frame
    void LateUpdate()
    {
        if (!trackedObject || !trackedObject.GetComponent<Health>() || !HealthBar)
        {
            return;
        }
        HealthBar.value = ((float)trackedObject.GetComponent<Health>().getHealth()) / ((float)trackedObject.GetComponent<Health>().maxHealth);
        if (trackedObject.gameObject && trackedObject.gameObject.CompareTag("Boss") && !trackedObject.gameObject.activeSelf)
        {
            HealthBar.transform.parent.gameObject.SetActive(false);
        }
        else if (trackedObject.gameObject && !trackedObject.gameObject.activeSelf && timer >= MultiPlayerRespawner.instance.respawnTime)
        {
            timer = 0;
        }
        else if (trackedObject.gameObject && !trackedObject.gameObject.activeSelf)
        {
            timer += Time.deltaTime;
            HealthBar.value = timer / MultiPlayerRespawner.instance.respawnTime;
        }
    }
}