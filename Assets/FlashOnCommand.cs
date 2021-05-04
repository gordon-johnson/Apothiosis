using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashOnCommand : MonoBehaviour
{
    public static FlashOnCommand instance;
    public GameObject ref1;
    public GameObject ref2;
    public GameObject ref3;
    public GameObject ref4;
    public GameObject ref5;
    public GameObject ref6;
    public static float flashTime = 7f;
    //public GameObject ref7;
    //public GameObject ref8;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static IEnumerator DoFlash()
    {
        float time = 0;
        float prevSec = 0;
        bool setting = false;
        while (time < flashTime)
        {
            if (time > prevSec)
            {
                time += Time.deltaTime;
                instance.SetAll(setting);
                setting = !setting;
                prevSec = time + 0.5f;
            }
            time += Time.deltaTime;
            yield return null;
        }
        instance.SetAll(true);

    }

    private void SetAll(bool setting)
    {
        ref1.SetActive(setting);
        ref2.SetActive(setting);
        ref3.SetActive(setting);
        ref4.SetActive(setting);
        ref5.SetActive(setting);
        ref6.SetActive(setting);
    }


}
