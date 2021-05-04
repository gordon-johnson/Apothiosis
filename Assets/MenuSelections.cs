using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelections : MonoBehaviour
{
    public static MenuSelections instance;
    public int[] choices = { 0, 0, 0, 0 };
    public GameObject player1Ref;

    private void Start()
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
}
