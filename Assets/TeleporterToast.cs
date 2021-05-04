using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterToast : MonoBehaviour
{
    private bool funcCalled = false;
    public bool startToast = false;
    private bool calledFunc = false;
    public Health shieldHealth;
    public string[] instructionList = {
        "The teleporter shield is down! \n Use the healer to repair it and \n prevent Janus' energy siphon",
        "Protect the teleporter and defeat Janus to face other Titans",
    };
    public float[] instructionPercentages =
    {
        0f,
        0.1f
    };
    [SerializeField] int index = 0;

    public Health bossHealth;
    // Start is called before the first frame update

    private void Start()
    {
        for (int i = 0; i < instructionList.Length; ++i)
        {
            instructionList[i] = instructionList[i].Replace('&', '\n');
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (! startToast && shieldHealth.getHealth() <= 0)
        {
            startToast = true;
        }
        if (startToast && index < instructionList.Length && ((float)bossHealth.getHealth() / (float)bossHealth.maxHealth) >= instructionPercentages[index])
        {
            //Debug.Log((float)bossHealth.getHealth() / (float)bossHealth.maxHealth);
            ToastManager.Toast(instructionList[index]);
            ++index;
        }
    }
}
