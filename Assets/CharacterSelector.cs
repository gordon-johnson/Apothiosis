using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    public Canvas theCanvas;

    public GameObject plutoWin;
    public GameObject plutoNext;

    #region Scene Management
    public string menuSceneName = "Rough_Menu";
    public string firstLevelName = "LAB_multipleplayers";
    public string secondLevelName = "";
    public string gameoverSceneName = "GameOver";
    public string winSceneName = "";
    #endregion
    public bool shouldSpawnPlayers = false;
    [SerializeField] bool playersHaveSpawned = false;
    private bool canvasSet = false;
    [SerializeField] private bool gameOver = false;
    public GameObject tutorialSpawnLocation;
    public GameObject level1SpawnLoc;
    public GameObject level2SpawnLoc;
    public static CharacterSelector instance;
    #region prefabs
    public GameObject shieldPrefab;
    public GameObject beamPrefab;
    public GameObject bubbleHealPrefab;
    public GameObject speedPrefab;
    public GameObject basePlayerPrefab;
    #endregion

    #region sliders
    public Slider player1Health;
    public Slider player1Special;
    public Slider player2Health;
    public Slider player2Special;
    public Slider player3Health;
    public Slider player3Special;
    public Slider player4Health;
    public Slider player4Special;
    #endregion

    #region players
    public GameObject player1;
    private bool p1Spawned = false;
    public GameObject player2;
    private bool p2Spawned = false;
    public GameObject player3;
    private bool p3Spawned = false;
    public GameObject player4;
    private bool p4Spawned = false;
    #endregion

    public int[] selections = { -1, -1, -1, -1 };
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance != this && instance != null)
        {
            Destroy(gameObject);
        }
        if (instance == null)
        {
            instance = this;
        }
        
    }
    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canvasSet && (SceneManager.GetActiveScene().name != menuSceneName && SceneManager.GetActiveScene().name != gameoverSceneName && SceneManager.GetActiveScene().name != winSceneName))
        {
          //  Debug.Break();
            theCanvas.gameObject.SetActive(true);
            canvasSet = true;
        }
        if (shouldSpawnPlayers)
        {
            if (SceneManager.GetActiveScene().name == menuSceneName)
            {
                playersHaveSpawned = false;
                SpawnAllPlayers();
                shouldSpawnPlayers = false;
                return;
            }
        }
        if (((SceneManager.GetActiveScene().name != menuSceneName && SceneManager.GetActiveScene().name != gameoverSceneName) && !playersHaveSpawned && !gameOver && SceneManager.GetActiveScene().name != winSceneName))
        {
           //theCanvas.gameObject.SetActive(true);
            SpawnAllPlayers();
            Debug.Log("PLAYERS HAVE SPAWNED TRUE");
            playersHaveSpawned = true;
        }
    }

    public void SpawnPlayer(int playerNum)
    {
        if (playersHaveSpawned)
        {
            Debug.Log("players have spawned");
            return;
        }
        if (playerNum == 1)
        {
            player1 = GetPrefab(selections[0]);
            player1.GetComponentInChildren<PlayerController>().playerNum = 1;
            GameObject p1;
            p1 = player1.GetComponentInChildren<Health>().gameObject;
            player1Health.GetComponent<UIController>().trackedObject = p1;
            player1Special.GetComponent<SpecialSliderController>().trackedObject = player1.GetComponentInChildren<PlayerAbility>();
            GameController.Instance.AddPlayer(0, player1);
           //player1.GetComponentInChildren<Health>().takeDamage(2);
        }
        else if (playerNum == 2)
        {
            player2 = GetPrefab(selections[1]);
            player2.GetComponentInChildren<PlayerController>().playerNum = 2;
            GameObject p2;
            p2 = player2.GetComponentInChildren<Health>().gameObject;
          //  p2.GetComponentInChildren<Health>().takeDamage(2);
            player2Health.GetComponent<UIController>().trackedObject = p2;
            player2Special.GetComponent<SpecialSliderController>().trackedObject = player2.GetComponentInChildren<PlayerAbility>();
            GameController.Instance.AddPlayer(1, player2);
        }
        else if (playerNum == 3)
        {
            player3 = GetPrefab(selections[2]);
            player3.GetComponentInChildren<PlayerController>().playerNum = 3;
            GameObject p3;
            p3 = player3.GetComponentInChildren<Health>().gameObject;
         //   p3.GetComponentInChildren<Health>().takeDamage(2);
            player3Health.GetComponent<UIController>().trackedObject = p3;
            player3Special.GetComponent<SpecialSliderController>().trackedObject = player3.GetComponentInChildren<PlayerAbility>();
            GameController.Instance.AddPlayer(2, player3);
        }
        else if (playerNum == 4)
        {
            player4 = GetPrefab(selections[3]);
            player4.GetComponentInChildren<PlayerController>().playerNum = 4;
            GameObject p4;
            p4 = player4.GetComponentInChildren<Health>().gameObject;
           // p4.GetComponentInChildren<Health>().takeDamage(2);
            player4Health.GetComponent<UIController>().trackedObject = p4;
            player4Special.GetComponent<SpecialSliderController>().trackedObject = player4.GetComponentInChildren<PlayerAbility>();
            GameController.Instance.AddPlayer(3, player4);
        }
    }

    public void DespawnPlayer(int playerNum)
    {
        if (playerNum == 1)
        {
            Destroy(player1);
        }
        else if (playerNum == 2)
        {
            Destroy(player2);
        }
        else if (playerNum == 3)
        {
            Destroy(player3);
        }
        else
        {
            Destroy(player4);
        }
    }

    public void SpawnAllPlayers()
    {
        Debug.Log("SPAWN All");
        theCanvas.enabled = true;
        for (int i = 0; i < GameController.Instance.Players.Length; ++i)
        {
            SpawnPlayer(i + 1);
        }
    }

    private GameObject GetPrefab(int index)
    {
        GameObject spawnLocation = new GameObject();
        spawnLocation.transform.position = GetSpawnLoc();
        if (index == 0)
        {
            return Instantiate(shieldPrefab, spawnLocation.transform.position, Quaternion.identity);
        }
        else if (index == 1)
        {
            return Instantiate(beamPrefab, spawnLocation.transform.position, Quaternion.identity);
        }
        else if (index == 2)
        {
            return Instantiate(speedPrefab, spawnLocation.transform.position, Quaternion.identity);
        }
        else if (index == -1)
        {
            return Instantiate(basePlayerPrefab, spawnLocation.transform.position, Quaternion.identity);
        }
        else return Instantiate(bubbleHealPrefab, spawnLocation.transform.position, Quaternion.identity);
    }

    public void GameOver()
    {
        Debug.Log("IN gameover");
       // selections = new int[]{ -1, -1, -1, -1 };
        theCanvas.gameObject.SetActive(false);
        playersHaveSpawned = false;
        shouldSpawnPlayers = true;
        canvasSet = false;
        
        for (int i = 0; i < GameController.Instance.Players.Length; ++i)
        {
            DespawnPlayer(i + 1);
        }
        NewGame();
    }

    public void NewGame()
    {
        Debug.Log("New game called");
        gameOver = false;
        playersHaveSpawned = false;
        theCanvas.gameObject.SetActive(true);
        canvasSet = false;
        Debug.Log("inactive");
        plutoWin.SetActive(false);
        plutoNext.SetActive(false);
        Debug.Log("set inactive");
    }

    public Vector3 GetSpawnLoc()
    {
        GameObject spawnLocation = new GameObject();
        if (SceneManager.GetActiveScene().name == menuSceneName)
        {
            return MultiPlayerRespawner.instance.tutorialRespawnPoints[MultiPlayerRespawner.instance.respawnLoc].transform.position;
        }
        else if (SceneManager.GetActiveScene().name == firstLevelName)
        {
            return level1SpawnLoc.transform.position;
        }
        else if (SceneManager.GetActiveScene().name == secondLevelName)
        {
            return level2SpawnLoc.transform.position;
        }
        else
        {
            Debug.Log("scene names in characterselector are wrong");
            return Vector3.zero;
        }
    }

    public void SwitchPlayer(int playerSelection, Vector3 position, int playerNum)
    {
        GameObject player;
        player = GetPrefab(playerSelection);
        player.transform.position = position;
        player.GetComponentInChildren<PlayerController>().playerNum = playerNum;
        GameObject p;
        p = player.GetComponentInChildren<Health>().gameObject;
        if (playerNum == 1)
        {
            player1Health.GetComponent<UIController>().trackedObject = p;
            player1Special.GetComponent<SpecialSliderController>().trackedObject = player.GetComponentInChildren<PlayerAbility>();
            player1 = player;
        }
        else if (playerNum == 2)
        {
            player2Health.GetComponent<UIController>().trackedObject = p;
            player2Special.GetComponent<SpecialSliderController>().trackedObject = player.GetComponentInChildren<PlayerAbility>();
            player2 = player;
        }
        else if (playerNum == 3)
        {
            player3Health.GetComponent<UIController>().trackedObject = p;
            player3Special.GetComponent<SpecialSliderController>().trackedObject = player.GetComponentInChildren<PlayerAbility>();
            player2 = player;
        }
        else if (playerNum == 4)
        {
            player4Health.GetComponent<UIController>().trackedObject = p;
            player4Special.GetComponent<SpecialSliderController>().trackedObject = player.GetComponentInChildren<PlayerAbility>();
            player2 = player;
        }
        GameController.Instance.AddPlayer(playerNum - 1, player);
        selections[playerNum - 1] = playerSelection;
    }

    public void PlutoWin()
    {
        plutoWin.SetActive(true);
        plutoNext.SetActive(true);
    }

    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("On scene load");
        playersHaveSpawned = false;
    }
}
