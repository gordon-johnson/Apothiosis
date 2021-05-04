using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStage : MonoBehaviour
{
    float timer = 2;
    bool flashBlueCalled = false;

    public Health Janus;

    public MoveToPosition lavaLeft;

    public MoveToPosition lavaRight;

    public MoveToPosition lavaFront;

    private void Start()
    {
        lavaLeft.enabled = false;
        lavaRight.enabled = false;
        lavaFront.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (!flashBlueCalled && Janus.getHealth() < Janus.maxHealth * 0.9f && Janus.getHealth() > Janus.maxHealth * 0.85f)
        {
            Debug.Log("should flash blue");
            StartCoroutine(FlashBlue());
            flashBlueCalled = true;
        }*/
        if(Janus.getHealth() < Janus.maxHealth * 0.75f)
        {
            timer -= Time.deltaTime;
            lavaLeft.enabled = true;
            lavaRight.enabled = true;
            lavaFront.enabled = true;

        }
        if (timer < 0)
        {
            timer = 2;
            Debug.Log("Should flash red");
            GetComponent<MaterialFlasher>().flash("Warning", 1f);
        }
    }

    private IEnumerator FlashBlue()
    {
        float time = 8;
        while (time > 0)
        {
            time -= Time.deltaTime;
            GetComponent<MaterialFlasher>().flash("Come", 1f);
            yield return new WaitForSeconds(2f);
        }
        flashBlueCalled = false;
    }
}
