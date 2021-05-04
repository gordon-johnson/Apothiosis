using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsHolder : MonoBehaviour
{

    private float timer;

    private Weapon lastFired;

    private Weapon[] weapons;

    private bool paused;
    private int currentPhase;

    [Serializable]
    public class phase
    {
        public float healthPercentActivation;
        public Weapon[] weapons;
    }

    public phase[] phases;

    // Start is called before the first frame update
    void Start()
    {
        weapons = GetComponentsInChildren<Weapon>();
        lastFired = weapons[0];
        currentPhase = 0;
    }

    // Update is called once per frame
    void Update()
    {
        checkPhase();
        if (!paused)
        {
            if (lastFired.isFinished)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    Weapon nextWeapon = phases[currentPhase].weapons[(int)Mathf.Floor(UnityEngine.Random.Range(0, phases[currentPhase].weapons.Length))];
                    nextWeapon.Activate();
                    lastFired = nextWeapon;
                    timer = lastFired.coolDown;
                }
            }
        }
    }

    private void checkPhase()
    {
        for(int i = 0; i < phases.Length; i++)
        {
            if ((((float)transform.parent.GetComponent<Health>().getHealth())/ ((float)transform.parent.GetComponent<Health>().maxHealth)) * 100 < phases[i].healthPercentActivation)
            {
                currentPhase = i;
            }
        }
    }

    public void PauseAll()
    {
        paused = true;
        foreach(Weapon weapon in weapons)
        {
            weapon.ForceStop();
        }
    }

    public void ResumeAll()
    {
        paused = false;
    }
}
