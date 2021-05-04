using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    public static LevelSelectManager instance;
    [SerializeField] int l1VoteCount = 0;
    [SerializeField] int l2VoteCount = 0;
    [SerializeField] int l3VoteCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
    }

    private void Reset()
    {
        l1VoteCount = 0;
        l2VoteCount = 0;
        l3VoteCount = 0;
    }

    private void CheckAndLoad()
    {
        if ((l1VoteCount + l2VoteCount + l3VoteCount) >= GameController.Instance.Players.Length)
        {
            if (l1VoteCount > l2VoteCount && l1VoteCount > l3VoteCount)
            {
                CharacterSelector.instance.GameOver();
                GameController.Instance.loadedLevel = CharacterSelector.instance.firstLevelName;
                SceneManager.LoadScene(CharacterSelector.instance.firstLevelName);
                CharacterSelector.instance.GameOver();
            }
            else if (l2VoteCount > l1VoteCount && l2VoteCount > l3VoteCount)
            {
                CharacterSelector.instance.GameOver();
                GameController.Instance.loadedLevel = CharacterSelector.instance.secondLevelName;
                SceneManager.LoadScene(CharacterSelector.instance.secondLevelName);
                CharacterSelector.instance.GameOver();
            }
            // implement if we add a third level
            else if (l3VoteCount > l1VoteCount && l3VoteCount > l2VoteCount)
            {
                CharacterSelector.instance.GameOver();
                GameController.Instance.loadedLevel = CharacterSelector.instance.firstLevelName;
                SceneManager.LoadScene(CharacterSelector.instance.firstLevelName);
                CharacterSelector.instance.GameOver();
            }
            else
            {
                //todo implement random choosing
                int rand = Random.Range(0, 1);
                if (rand == 0)
                {
                    CharacterSelector.instance.GameOver();
                    GameController.Instance.loadedLevel = CharacterSelector.instance.firstLevelName;
                    SceneManager.LoadScene(CharacterSelector.instance.firstLevelName);
                    CharacterSelector.instance.GameOver();
                }
                else
                {
                    CharacterSelector.instance.GameOver();
                    GameController.Instance.loadedLevel = CharacterSelector.instance.secondLevelName;
                    SceneManager.LoadScene(CharacterSelector.instance.secondLevelName);
                    CharacterSelector.instance.GameOver();
                }
            }
            Reset();
        }
    }

    public void Add1()
    {
        l1VoteCount++;
        CheckAndLoad();
    }

    public void Subtract1()
    {
        l1VoteCount--;
        CheckAndLoad();
    }

    public void Add2()
    {
        Debug.Log("2 added");
        l2VoteCount++;
        CheckAndLoad();
    }

    public void Subtract2()
    {
        l2VoteCount--;
        CheckAndLoad();
    }

    public void Add3()
    {
        l1VoteCount++;
        CheckAndLoad();
    }

    public void Subtract3()
    {
        l1VoteCount--;
        CheckAndLoad();
    }
}
