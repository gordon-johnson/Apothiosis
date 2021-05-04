using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_GameEventTrigger : MonoBehaviour
{
    // Specific event to be triggered
    // GameEvent is attached in the Inspector
    public GameEvent Event;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Raises specified GameEvent
            Event.Raise();
        }
    }
}
