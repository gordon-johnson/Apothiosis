using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_OnGameEvent : MonoBehaviour
{
    // Function called in response to GameEvent being raised
    // This is attached to the listener in the Inspector, so name may vary
    public void OnGameEvent()
    {
        Debug.Log("OnGameEvent");
    }
}
