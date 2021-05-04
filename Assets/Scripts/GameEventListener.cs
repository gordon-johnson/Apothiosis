using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Listener component for a specified GameEvent
/// ============================================
/// Add an instance of this component for each event to be listened to
/// and assign functionality by attaching a script that contains
/// the function that is called when the event is raised
/// </summary>
[RequireComponent(typeof(Event), typeof(UnityEvent))]
public class GameEventListener : MonoBehaviour
{
    public GameEvent Event;
    public UnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        Response.Invoke();
    }
}

// Code acquired from here: https://unity3d.com/how-to/architect-with-scriptable-objects