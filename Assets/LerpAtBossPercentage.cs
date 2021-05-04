using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpAtBossPercentage : MonoBehaviour
{
    public Health janus;
    Vector3 landingPosition;
    public float startingPos = 200f;
    bool crashed = false;
    public AnimationCurve ease;
    public bool dontCheckActive = false;
    public float landPercentage = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        landingPosition = transform.position;
        transform.position += Vector3.up * startingPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (!crashed && janus && (janus.isActiveAndEnabled || dontCheckActive) &&  janus.getHealth() <= janus.maxHealth * landPercentage)
        {
            StartCoroutine(Land());
        }
    }

    private IEnumerator Land()
    {
        float duration_ease_sec = 100f;
        float initial_time = Time.time;
        float progress = (Time.time - initial_time) / duration_ease_sec;

        while (progress < 1.0f)
        {
            progress = (Time.time - initial_time) / duration_ease_sec;
            float eased_progress = ease.Evaluate(progress);
            transform.position = Vector3.LerpUnclamped(transform.position, landingPosition, eased_progress);
            yield return null;
        }
    }
}
