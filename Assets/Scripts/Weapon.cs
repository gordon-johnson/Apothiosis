using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float coolDown;
    public float repeat;
    private float currentRepeats;
    public bool fixRotation;

    private GameController gameController;

    [System.Serializable]
    public class ProjectileSpawner
    {
        public GameObject spawn;
        public float angle;
        public float randomness;
        public void Spawn(Vector3 position, float rotation)
        {
            GameObject newSpawn = Instantiate(spawn);
            newSpawn.transform.position = position;
            newSpawn.transform.eulerAngles = new Vector3(0, angle + rotation + Random.Range(-randomness/2,randomness/2), 0);
        }
    }

    [System.Serializable]
    public class ProjectileWave
    {
        public ProjectileSpawner[] spawners;
        public float delay;
        private float timer;
        public bool fired;
        public bool targeted;
        public bool predictive;
        public float predicitionDelay;
        public void Spawn(Vector3 position, float rotation)
        {
            foreach(ProjectileSpawner spawn in spawners)
            {
                if (targeted)
                {
                    foreach(GameObject Player in GameController.Instance.Players)
                    {
                        Vector3 offset = Vector3.zero;
                        if (predictive)
                        {
                            offset = Player.GetComponent<Rigidbody>().velocity * predicitionDelay;
                        }
                        RaycastHit hit;
                        if(Physics.Raycast(Player.transform.position + offset + (Vector3.up * 100), Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
                        {
                            spawn.Spawn(hit.point, rotation);
                        }
                    }
                } else
                {
                    spawn.Spawn(position, rotation);
                }
            }
            fired = true;
        }
        public void Reset()
        {
            fired = false;
        }
    }

    public ProjectileWave[] waves;

    public bool isFinished;

    private float timer;

    private void Start()
    {
        isFinished = true;
        gameController = GameController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFinished)
        {
            timer += Time.deltaTime;
            isFinished = true;
            foreach(ProjectileWave wave in waves)
            {
                if (!wave.fired)
                {
                    if(wave.delay < timer)
                    {
                        float angle = (Mathf.Atan2(transform.position.x, transform.position.z) * Mathf.Rad2Deg) - 180;
                        if (fixRotation)
                        {
                            angle = transform.eulerAngles.y;
                        }
                        wave.Spawn(transform.position, angle);
                        timer = 0;
                    }
                    isFinished = false;
                }
            }
            if (isFinished)
            {
                if(currentRepeats > 0)
                {
                    currentRepeats -= 1;
                    isFinished = false;
                    timer = 0;
                    foreach (ProjectileWave wave in waves)
                    {
                        wave.Reset();
                    }
                }
            }
        }
    }

    public void Activate()
    {
        isFinished = false;
        timer = 0;
        currentRepeats = repeat;
        foreach(ProjectileWave wave in waves)
        {
            wave.Reset();
        }
    }

    public void ForceStop()
    {
        isFinished = true;
    }
}
