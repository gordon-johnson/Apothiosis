using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BossHealthBasedToastCaller))]
public class SkipToast : MonoBehaviour
{
    public GameObject teleporter;
    private BossHealthBasedToastCaller toaster;
    public Health boss;
    public bool selectionMade = false;
    public bool skipTutorial = false;
    List<string> playerSelections;
    private List<Gamepad> gamepads;
    public GameObject normalSkip;
    public GameObject tutorialSkip;
    public GameObject a1;
    public GameObject a2;
    public GameObject a3;
    public GameObject a1Dim;
    public GameObject a2Dim;
    public GameObject a3Dim;
    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    // Start is called before the first frame update
    void Start()
    {
        gamepads = new List<Gamepad>(Gamepad.all);
        playerSelections = new List<string>();
        InitList();
        toaster = GetComponent<BossHealthBasedToastCaller>();
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Health>();
        ToastManager.ToastLong("Press A to do tutorial, Press B to skip tutorial \n (must be unanimous)");
 
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        if (CheckAllPlayersPressA())
        {
            AllPressedA();
        }
        else if (CheckAllPlayersPressB())
        {
            AllPressedB();
        }
        if (selectionMade)
        {
            if (skipTutorial)
            {
                boss.takeDamage(5000);
            }
            else
            {
                toaster.startToast = true;
            }
        }
    }

    private bool CheckAllPlayersPressA()
    {
        if (playerSelections[0] != "A") return false;
        for (int i = 1; i < playerSelections.Count; ++i)
        {
            if (i == 3) break;
            if (playerSelections[i - 1] != playerSelections[i]) return false;
        }
        return true;
    }

    private bool CheckAllPlayersPressB()
    {
        if (playerSelections[0] != "B") return false;
        for (int i = 1; i < playerSelections.Count; ++i)
        {
            if (i == 3) break;
            if (playerSelections[i - 1] != playerSelections[i]) return false;
        }
        return true;
    }

    private void GetInput()
    {
        for (int i = 0; i < gamepads.Count; ++i)
        {
            if (gamepads[i].aButton.wasPressedThisFrame)
            {
                playerSelections[i] = "A";
                if (i == 0) a1.SetActive(true);
                if (i == 1) a2.SetActive(true);
                if (i == 2) a3.SetActive(true);
                if (!selectionMade)
                {
                    if (i == 0) b1.SetActive(false);
                    if (i == 1) b2.SetActive(false);
                    if (i == 2) b3.SetActive(false);
                }
            }
            else if (gamepads[i].bButton.wasPressedThisFrame)
            {
                if (!selectionMade)
                {
                    playerSelections[i] = "B";
                    if (i == 0) b1.SetActive(true);
                    if (i == 1) b2.SetActive(true);
                    if (i == 2) b3.SetActive(true);
                }
                if (i == 0) a1.SetActive(false);
                if (i == 1) a2.SetActive(false);
                if (i == 2) a3.SetActive(false);
            }
        }
    }

    private void InitList()
    {
        for (int i = 0; i < gamepads.Count; ++i)
        {
            playerSelections.Add("");
        }
    }

    private void AllPressedA()
    {
        if (!selectionMade)
        {
            skipTutorial = false;
            selectionMade = true;
            tutorialSkip.SetActive(false);
        //    normalSkip.SetActive(true);
            a1Dim.SetActive(true);
            a2Dim.SetActive(true);
            a3Dim.SetActive(true);
        }
        ToastManager.instance.skipCurrentToast = true;
        ResetList();
    }

    private void AllPressedB()
    {
        if (!selectionMade)
        {
            teleporter.SetActive(false);
            skipTutorial = true;
            selectionMade = true;
            tutorialSkip.SetActive(false);
        //    normalSkip.SetActive(true);
            a1Dim.SetActive(true);
            a2Dim.SetActive(true);
            a3Dim.SetActive(true);
        }
        ToastManager.instance.skipCurrentToast = true;
        ResetList();
    }

    private void ResetList()
    {
        for (int i = 0; i < playerSelections.Count; ++i)
        {
            playerSelections[i] = "";
        }
        a1.SetActive(false);
        a2.SetActive(false);
        a3.SetActive(false);
        b1.SetActive(false);
        b2.SetActive(false);
        b3.SetActive(false);
    }
}
