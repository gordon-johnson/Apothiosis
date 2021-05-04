using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurrowMovement : MonoBehaviour
{

    public Vector3[] travelLocations;
    public float timeToTravel;

    public GameObject burrowParticles;

    public float burrowDepth;
    public float burrowTime;

    public float surfaceTime;

    public float riseTime;
    private float riseTimer;

    private float surfaceTimer;
    private float travelTimer;
    private Vector3 startPosition;
    private float burrowTimer;

    private Vector3 targetPosition;

    private WeaponsHolder weapons;

    public Animator anim;

    public ParticleSystem risingParticles;
	public ParticleSystem surfaceParticles;

	private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        surfaceTimer = surfaceTime;
        burrowTimer = 0;
        travelTimer = 0;
        riseTimer = 0;
        weapons = GetComponentInChildren<WeaponsHolder>();
        burrowParticles.GetComponent<ParticleSystem>().Stop();
        risingParticles.Stop();
		surfaceParticles.Play();
		camera = Camera.main;
    }

	// Update is called once per frame
	void Update()
    {
        if(surfaceTimer > 0)
        {
			camera.GetComponent<Shaker>().shake = false;

			surfaceTimer -= Time.deltaTime;
            if(surfaceTimer <= 0)
            {
                burrowTimer = burrowTime;
                startPosition = transform.position;
                weapons.PauseAll();
			}
		}
        if(burrowTimer > 0)
        {
			camera.GetComponent<Shaker>().shake = true;
			camera.GetComponent<Shaker>().mag = 0.05f;

            burrowTimer -= Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, startPosition + (Vector3.down * burrowDepth), (burrowTime - burrowTimer) / burrowTime);
            if(burrowTimer <= 0)
            {
				transform.position = startPosition + (Vector3.down * burrowDepth);
                travelTimer = timeToTravel;
                startPosition = transform.position;
                burrowParticles.GetComponent<ParticleSystem>().Play();
                targetPosition = travelLocations[(int)Mathf.Floor(Random.Range(0, travelLocations.Length))];
                while (targetPosition.x == transform.position.x && targetPosition.z == transform.position.z)
                {
                    targetPosition = travelLocations[(int)Mathf.Floor(Random.Range(0, travelLocations.Length))];
                }
            }
        }
        if(travelTimer > 0)
        {
			camera.GetComponent<Shaker>().mag = 0.1f;

			travelTimer -= Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, targetPosition, (timeToTravel - travelTimer) / timeToTravel);
            transform.position = new Vector3(transform.position.x, startPosition.y, transform.position.z);
            if(travelTimer <= 0)
            {
                transform.position = new Vector3(targetPosition.x,startPosition.y,targetPosition.z);
                startPosition = transform.position;
                burrowParticles.GetComponent<ParticleSystem>().Stop();
                riseTimer = riseTime;
                anim.SetTrigger("Rise");
                float newRot = (Mathf.Atan2(transform.position.x, transform.position.z) * Mathf.Rad2Deg);
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, newRot, transform.localEulerAngles.z);
                risingParticles.Play();
            }
        }
        if(riseTimer > 0)
        {
			surfaceParticles.transform.position = new Vector3(surfaceParticles.transform.position.x, -0.5f, surfaceParticles.transform.position.z);
			camera.GetComponent<Shaker>().mag = 0.3f;

			riseTimer -= Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, startPosition + (Vector3.up * burrowDepth), (riseTime - riseTimer) / riseTime);
            if(riseTimer <= 0)
            {
                transform.position = startPosition + (Vector3.up * burrowDepth);
                startPosition = transform.position;
                surfaceTimer = surfaceTime;
                weapons.ResumeAll();
            }
        }
    }
}
