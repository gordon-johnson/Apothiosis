using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject[] Players;
    public string loadedLevel = "";
   // public List<GameObject> PlayerHealth;

    public Canvas canvas;

    public GameObject winScreen;

    public GameObject loseScreen;

    public Health boss;

    public static GameController Instance;

    private void Awake()
    {
        if (GameController.Instance)
        {
            Destroy(gameObject);
        } else
        {
            GameController.Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
      //  winScreen.active = false;
      //  loseScreen.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!boss && GameObject.FindGameObjectWithTag("Boss"))
        {
            boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Health>();
        }
        if ( SceneManager.GetActiveScene().name != CharacterSelector.instance.winSceneName && SceneManager.GetActiveScene().name != CharacterSelector.instance.menuSceneName 
            && SceneManager.GetActiveScene().name != CharacterSelector.instance.gameoverSceneName && boss.getHealth() <= 0)
        {
            if (SceneManager.GetActiveScene().name != CharacterSelector.instance.firstLevelName)
            {
                CharacterSelector.instance.GameOver();
                SceneManager.LoadScene(CharacterSelector.instance.winSceneName);
            }
            else
            {
                if (boss.gameObject.activeSelf)
                {
                    CharacterSelector.instance.PlutoWin();
                    boss.gameObject.SetActive(false);
                }
            }
        }
        /*
        int playerTotalHealth = 0;
        foreach(GameObject player in Players)
        {
            if(player.GetComponentInChildren<Health>().getHealth() > 0)
            playerTotalHealth += player.GetComponentInChildren<Health>().getHealth();
        }
        if(playerTotalHealth <= 0 && !winScreen.active)
        {
            loseScreen.active = true;
        }
        if (boss.getHealth() <= 0 && !loseScreen.active)
        {
            winScreen.active = true;
        }
        if(Input.GetButton("Submit") && (winScreen.active || loseScreen.active))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }*/
    }

    public void AddPlayer(int index, GameObject player)
    {
        Players[index] = player;
    }
}
