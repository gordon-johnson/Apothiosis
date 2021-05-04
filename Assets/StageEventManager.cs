using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEventManager : MonoBehaviour
{
    [Serializable]
    public class CameraEvent
    {
        public float health;
        public Vector3 position;
        public Vector3 rotation;
        public float FOV;

        public bool timed;

        public float time;

        public bool fired = false;
    }

    public CameraEvent[] cameraEvents;

    // Update is called once per frame
    void Update()
    {
        foreach(CameraEvent cameraEvent in cameraEvents)
        {
            if(!cameraEvent.fired && (GetComponent<Health>().getHealth() / GetComponent<Health>().maxHealth) * 100 <= cameraEvent.health)
            {
                Debug.Log("Fired Camera Event");
                CameraController.SnapPosition(cameraEvent.position,cameraEvent.rotation);
                if(cameraEvent.FOV != 0)
                {
                    CameraController.SetFOV(cameraEvent.FOV);
                }
                cameraEvent.fired = true;
            }
        }
    }
}
