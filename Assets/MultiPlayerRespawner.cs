using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiPlayerRespawner : MonoBehaviour
{
    [SerializeField] public float respawnTime = 5;
    public static MultiPlayerRespawner instance;
    [SerializeField] int countDead = 0;
    public int respawnLoc = 0;
    [SerializeField] public GameObject[] tutorialRespawnPoints;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (countDead >= GameController.Instance.Players.Length && (SceneManager.GetActiveScene().name != CharacterSelector.instance.menuSceneName && SceneManager.GetActiveScene().name != CharacterSelector.instance.gameoverSceneName)
            && SceneManager.GetActiveScene().name != CharacterSelector.instance.winSceneName)
        {
            Debug.Log(countDead);
            GameOver();
        }
    }

    private IEnumerator DoRespawn(GameObject player)
    {
        if (SceneManager.GetActiveScene().name == CharacterSelector.instance.menuSceneName)
        {
            yield return null;
            GameController.Instance.Players[GetPlayerIndex(player)].GetComponentInChildren<Health>().reset();
            player.transform.position = CharacterSelector.instance.GetSpawnLoc();
			player.GetComponent<Health>().setInvincible(5);
			player.GetComponent<Rigidbody>().velocity = Vector3.zero;
			GameObject newRespwan = Instantiate(player.GetComponent<Health>().respawn);
			newRespwan.transform.position = player.transform.position;
		}
        else
        {
            Debug.Log(GetPlayerIndex(player));
            countDead += 1;
            //Debug.Log(player.name);

            //var thing = player.GetComponentInChildren<Health>().gameObject;
            player.SetActive(false);
            yield return new WaitForSeconds(respawnTime);
            player.SetActive(true);
            GameController.Instance.Players[GetPlayerIndex(player)].SetActive(true);
            Debug.Log(0);
            GameController.Instance.Players[GetPlayerIndex(player)].GetComponent<Health>().reset();
            player.transform.position = CharacterSelector.instance.GetSpawnLoc();
            player.GetComponent<Health>().setInvincible(5);
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
			GameObject newRespwan = Instantiate(player.GetComponent<Health>().respawn);
			newRespwan.transform.position = player.transform.position;
			countDead -= 1;
        }
    }

    public void Respawn(GameObject player)
    {
        StartCoroutine(DoRespawn(player));
    }

    private int GetPlayerIndex(GameObject gameObject)
    {
        try
        {
            if (gameObject.CompareTag("Player"))
            {
                return (gameObject.GetComponent<PlayerController>().playerNum - 1);
            }
        }
        catch
        {

        }
        try
        {
            if (gameObject.CompareTag("Player"))
            {
                return (gameObject.GetComponentInChildren<PlayerController>().playerNum - 1);
            }
        }
        catch
        {

        }
        try
        {
            if (gameObject.CompareTag("Player"))
            {
                return (gameObject.GetComponentInParent<PlayerController>().playerNum - 1);
            }
        }
        catch
        {

        }
        // Please dont do this
        return -1;
    }

    void GameOver()
    {
        countDead = 0;
        CharacterSelector.instance.GameOver();
        SceneManager.LoadScene(CharacterSelector.instance.gameoverSceneName);
    }
}
