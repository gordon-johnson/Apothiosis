using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintUIManager : MonoBehaviour
{
    public static HintUIManager instance;
    private List<GameObject> textList;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        textList = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegesterText(GameObject text)
    {
        textList.Add(text);
    }

    public void DeactivateAllText()
    {
        for (int i = 0; i < textList.Count; ++i)
        {
            textList[i].SetActive(false);
        }
    }
}
