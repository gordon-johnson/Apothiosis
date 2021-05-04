using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Template GameEvent, trackable by any object with a respective GameEventListener component
/// =========================================================================================
/// To create a new GameEvent, navigate to the Project window and right click
/// and select Create > GameEvent
/// </summary>
[CreateAssetMenu(fileName = "New GameEvent", menuName = "GameEvent")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();
    public void Raise()
    {
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}

// Code acquired from here: https://unity3d.com/how-to/architect-with-scriptable-objects