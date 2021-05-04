using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerState))]
[RequireComponent(typeof(Collider))]
public class PlayerDash : MonoBehaviour
{
    [Header("Required")]
    [SerializeField] private PlayerState state;
    [SerializeField] private Collider collider;
    public GameEvent DashingStart;
    public GameEvent DashingEnd;

    [Header("Dashing")]
    [SerializeField] private float duration;
    [SerializeField] private float cooldown;
    [SerializeField] private float cooldownMax;
    [SerializeField] private float postDashInvDuration;
    [SerializeField] private TrailRenderer rend;

    private void Awake()
    {
        state = this.GetComponent<PlayerState>();
        rend = this.GetComponentInChildren<TrailRenderer>();
    }

    private void Update()
    {
        if (cooldown > 0)
            cooldown -= Time.deltaTime;
    }

    public void OnInput(Rigidbody rb, bool input)
    {
        if (input == false || state.isDashing.Check() || state.isCastingAbility.Check() || cooldown > 0)
            return;

        state.isDashing.Set(true);
        this.GetComponent<Health>().setInvincible(postDashInvDuration);
        if (GetComponent<MaterialFlasher>() != null)
        {
            GetComponent<MaterialFlasher>().flash("Dash", postDashInvDuration);
        }
        StartCoroutine(Dash());
    }

    private IEnumerator Dash()
    {
        cooldown = cooldownMax;
        if (rend != null)
        {
            rend.enabled = true;
            //rend.gameObject.transform.position += Vector3.up * 100;
        }

        yield return new WaitForSeconds(duration);
        state.isDashing.Set(false);
        if (rend != null)
        {
            rend.enabled = false;
            //rend.gameObject.transform.position -= Vector3.up * 100;
        }
        //collider.gameObject.SetActive(true);
    }
}
