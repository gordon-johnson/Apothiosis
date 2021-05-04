using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelectionsUIController : MonoBehaviour
{
    [SerializeField] int playerNum;
    private int selectedCharacter = 0;
    private List<string> characterList;
    private List<Sprite> characterImages;
    private List<string> descriptionList;
    private Text selection;
    public Sprite selectedSprite;
    public Text description;
    [SerializeField] private float toggleTime = 0.5f;
    private bool canToggle = true;
    [SerializeField] Image playerImage;
    bool playerSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        selection = GetComponent<Text>();
        characterImages = new List<Sprite>();
        descriptionList = new List<string>();
        characterList = new List<string>();
        characterList.Add("Shield");
        characterList.Add("Resurrector");
        characterList.Add("Speed");
        characterList.Add("Healer");
        descriptionList.Add("Shield \n yourself and \n teammates");
        descriptionList.Add("Revive all \n downed \n teammates");
        descriptionList.Add("Increase fire \n and \n movement \n speed");
        descriptionList.Add("Heal \n yourself and \n teammates");
        characterImages.Add(MenuPlayerSelect.instance.shield);
        characterImages.Add(MenuPlayerSelect.instance.BeamHeal);
        characterImages.Add(MenuPlayerSelect.instance.Speed);
        characterImages.Add(MenuPlayerSelect.instance.AoEHeal);
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerSpawned && canToggle && Input.GetAxis("Horizontal" + playerNum.ToString()) < -0.5) {
            selectedCharacter -= 1;
            selectedCharacter = selectedCharacter < 0 ? characterList.Count - 1 : selectedCharacter;
            Select();
        }
        else if (!playerSpawned && canToggle && Input.GetAxis("Horizontal" + playerNum.ToString()) > 0.5)
        {
            selectedCharacter += 1;
            selectedCharacter = selectedCharacter >= characterList.Count ? 0 : selectedCharacter;
            Select();
            canToggle = false;
            StartCoroutine(ResetToggle());
        }
        if (!playerSpawned && Input.GetButton("Submit" + playerNum.ToString()))
        {
            playerSpawned = true;
            CharacterSelector.instance.SpawnPlayer(playerNum);
        }
        if (playerSpawned && Input.GetButton("Cancel" + playerNum.ToString()))
        {
            playerSpawned = false;
            CharacterSelector.instance.DespawnPlayer(playerNum);
        }
    }

    void Select()
    {
        selection.text = "Player " + playerNum.ToString() + ": " + characterList[selectedCharacter];
        canToggle = false;
        CharacterSelector.instance.selections[playerNum - 1] = selectedCharacter;
        playerImage.sprite = characterImages[selectedCharacter];
        description.text = descriptionList[selectedCharacter];
        StartCoroutine(ResetToggle());
    }

    private IEnumerator ResetToggle()
    {
        yield return new WaitForSeconds(toggleTime);
        canToggle = true;
    }


}
