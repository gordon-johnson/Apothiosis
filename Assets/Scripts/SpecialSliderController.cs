using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialSliderController : MonoBehaviour
{
    public Slider slide;
    public PlayerAbility trackedObject = null;


    // Start is called before the first frame update
    void Start()
    {
        slide.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (trackedObject)
            {
                slide.value = 1 - (trackedObject.cooldown.Check() / trackedObject.cooldownMax.Check());
            }
        }
        catch
        {

        }
    }
}
