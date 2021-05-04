using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnStart : MonoBehaviour
{
    public bool loadMenu = false;
    public bool loadFirstLevel = false;
    public bool loadSecondLevel = false;
    public bool loadGameOver = false;
    public string sceneToLoad = "";
    public MenuInput buttons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (buttons.PressedA() || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (loadMenu)
            {
                MultiPlayerRespawner.instance.respawnLoc = 0;
                SceneManager.LoadScene(CharacterSelector.instance.menuSceneName);
            }
            else if (loadFirstLevel)
            {
                SceneManager.LoadScene(CharacterSelector.instance.firstLevelName);
            }
            else if (loadSecondLevel)
            {
                SceneManager.LoadScene(CharacterSelector.instance.secondLevelName);
            }
            else if (loadGameOver)
            {
                SceneManager.LoadScene(CharacterSelector.instance.gameoverSceneName);
            }
            else
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
        if (buttons.PressedB())
        {
            if (loadMenu)
            {
                //MultiPlayerRespawner.instance.respawnLoc = MultiPlayerRespawner.instance.tutorialRespawnPoints.Length - 1;
                CharacterSelector.instance.NewGame();
                SceneManager.LoadScene(GameController.Instance.loadedLevel);
            }
        }
    }
}
