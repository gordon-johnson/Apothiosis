using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthBasedToastCaller : MonoBehaviour
{
    private bool funcCalled = false;
    public bool startToast = false;
    private bool calledFunc = false;
    public BoxCollider bc;
    public string[] instructionList = {
        "Use LEFT STICK to MOVE",
        "Use RIGHT STICK to AIM and \n RIGHT TRIGGER to SHOOT",
        "Use low ground to avoid attacks",
        "Use LEFT TRIGGER to DASH",
        "Get to high ground!",
        "DASHING makes you INVULNERABLE \n Use it to dodge through attacks",
        "Use either BUMPER to use the SPECIAL",
        "Go get him!",
        "Step on the BLUE plate to fight Pluto"
    };
    public float[] instructionPercentages =
    {
        1.1f,
        1.1f,
        .90f,
        .75f,
        .65f,
        .55f,
        .4f,
        .3f,
        0f
    };

    public GameObject[] instructionImgs;

    [SerializeField] int index = 0;

    public GameObject boss;
    private Health bossHealth;
    // Start is called before the first frame update

    private void Start()
    {
        bossHealth = boss.GetComponent<Health>();
        for (int i = 0; i < instructionList.Length; ++i)
        {
            instructionList[i] = instructionList[i].Replace('&', '\n');
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startToast && index < instructionList.Length && ((float)bossHealth.getHealth() / (float)bossHealth.maxHealth) <= instructionPercentages[index])
        {
            //Debug.Log((float)bossHealth.getHealth() / (float)bossHealth.maxHealth);
            ToastManager.Toast(instructionList[index]);
            for (int i = 0; i < instructionImgs.Length; ++i)
            {
                if (instructionImgs[i]) instructionImgs[i].SetActive(false);
            }
            StartCoroutine(DisableAllImgs());
            if (instructionImgs[index]) instructionImgs[index].SetActive(true);
            ++index;
            if (!calledFunc && ((float)bossHealth.getHealth() / (float)bossHealth.maxHealth) <= 0.4)
            {
                calledFunc = true;
                StartCoroutine(FlashOnCommand.DoFlash());
            }
            if (!calledFunc && bossHealth.getHealth() <= 0)
            {
                calledFunc = true;
                bc.enabled = true;
            }
        }
        if (!startToast && !funcCalled && bossHealth.getHealth() <= 0)
        {
            //give the instructions for stepping on the platform if it was skipped
            ToastManager.Toast("Step on the BLUE plate to fight Pluto (easy) \n Step on the RED plate to fight Mars (harder)");
            funcCalled = true;
        }
    }

    private IEnumerator DisableAllImgs()
    {
        yield return new WaitForSeconds(10f);
    }
}
