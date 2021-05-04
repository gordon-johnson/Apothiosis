using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Vector2 innerBox;
    public Vector2 outerBox;

    public float bossMultiplier;

    public float speed;

    public static CameraController instance;

    private bool paused;

    private void Awake()
    {
        if (instance)
        {
            Debug.LogWarning("Instance of Camera Controller already exists");
        }
        instance = this;
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            return;
        }
        transform.position += transform.forward * speed * getDirection() * Time.deltaTime;
    }

    public static void Pause()
    {
        instance.paused = true;
    }

    public static void Resume()
    {
        instance.paused = false;
    }

    public static void SnapPosition(Vector3 position, Vector3 rotation)
    {
        instance.transform.position = position;
        instance.transform.eulerAngles = rotation;
    }

    public static void SetFOV(float fieldOfView)
    {
        instance.GetComponent<Camera>().fieldOfView = fieldOfView;
    }

    private float getDirection()
    {
        int direction = 1;

        Vector3 playerPosition;

        foreach (GameObject player in GameController.Instance.Players)
        {
            if (player.active)
            {
                playerPosition = Camera.main.WorldToScreenPoint(player.transform.position);
                if ((playerPosition.x > (Camera.main.pixelWidth / 2) + (innerBox.x * Camera.main.pixelWidth / 2) || playerPosition.x < (Camera.main.pixelWidth / 2) - (innerBox.x * Camera.main.pixelWidth / 2)) && direction > 0)
                {
                    direction = 0;
                }
                if ((playerPosition.y > (Camera.main.pixelHeight / 2) + (innerBox.y * Camera.main.pixelHeight / 2) || playerPosition.y < (Camera.main.pixelHeight / 2) - (innerBox.y * Camera.main.pixelHeight / 2)) && direction > 0)
                {
                    direction = 0;
                }
                if (playerPosition.x > (Camera.main.pixelWidth / 2) + (outerBox.x * Camera.main.pixelWidth / 2) || playerPosition.x < (Camera.main.pixelWidth / 2) - (outerBox.x * Camera.main.pixelWidth / 2))
                {
                    direction = -1;
                }
                if (playerPosition.y > (Camera.main.pixelHeight / 2) + (outerBox.y * Camera.main.pixelHeight / 2) || playerPosition.y < (Camera.main.pixelHeight / 2) - (outerBox.y * Camera.main.pixelHeight / 2))
                {
                    direction = -1;
                }
            }
            Debug.Log("Preboss Direction: " + direction);
        }
        playerPosition = Camera.main.WorldToScreenPoint(GameController.Instance.boss.transform.position);
        if ((playerPosition.x > (Camera.main.pixelWidth / 2) + (innerBox.x * bossMultiplier * Camera.main.pixelWidth / 2) || playerPosition.x < (Camera.main.pixelWidth / 2) - (innerBox.x * bossMultiplier * Camera.main.pixelWidth / 2)) && direction > 0)
        {
            direction = 0;
        }
        if ((playerPosition.y > (Camera.main.pixelHeight / 2) + (innerBox.y * bossMultiplier * Camera.main.pixelHeight / 2) || playerPosition.y < (Camera.main.pixelHeight / 2) - (innerBox.y * bossMultiplier * Camera.main.pixelHeight / 2)) && direction > 0)
        {
            direction = 0;
        }
        if (playerPosition.x > (Camera.main.pixelWidth / 2) + (outerBox.x * bossMultiplier * Camera.main.pixelWidth / 2) || playerPosition.x < (Camera.main.pixelWidth / 2) - (outerBox.x * bossMultiplier * Camera.main.pixelWidth / 2))
        {
            direction = -1;
        }
        if (playerPosition.y > (Camera.main.pixelHeight / 2) + (outerBox.y * bossMultiplier * Camera.main.pixelHeight / 2) || playerPosition.y < (Camera.main.pixelHeight / 2) - (outerBox.y * bossMultiplier * Camera.main.pixelHeight / 2))
        {
            direction = -1;
        }


        return direction;
    }
}
