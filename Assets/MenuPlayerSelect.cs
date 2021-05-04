using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayerSelect : MonoBehaviour
{
    public Sprite shield;
    public Sprite BeamHeal;
    public Sprite Speed;
    public Sprite AoEHeal;
    public static MenuPlayerSelect instance;

    private void Awake()
    {
       // DontDestroyOnLoad(gameObject);
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
