using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIHandler : MonoBehaviour
{

    public GameEvent specialStart;
    public GameEvent specialEnd;
    public float specialChargeDuration;
    public PlayerState playerState;
    private int playerHealth;
    private int maxPlayerHealth;

    public Slider healthSlider;
    public Slider specialSlider;
    // Start is called before the first frame update
    void Start()
    {
        maxPlayerHealth = playerState.GetComponent<Health>().maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Player1Damaged()
    {
        playerHealth = playerState.GetComponent<Health>().getHealth();
        float percentage = (float)playerHealth / (float)maxPlayerHealth;
        healthSlider.value = percentage * 100;
    }

    public void Player1Special()
    {

    }

    public void BossDamaged()
    {

    }
}
