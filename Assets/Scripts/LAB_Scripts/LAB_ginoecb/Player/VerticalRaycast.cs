using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalRaycast : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Collider playerCollider;
    [SerializeField] private LayerMask mask;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Vector3 target;
    [SerializeField] private float targetHeight;
    [Tooltip("Fall speed value should be greater than zero.")]
    [SerializeField] private float fallAcceleration;
    private float fallSpeed;

    private void Start()
    {
        if(targetHeight == 0)
        {
            targetHeight = playerCollider.bounds.size.y;
        }
        fallSpeed = 0;
    }

    private void LateUpdate()
    {
        //this.transform.position = new Vector3(player.transform.position.x, 100, player.transform.position.z);
        GetTarget();
        if (transform.position.y > target.y)
        {
            fallSpeed += fallAcceleration * Time.deltaTime;
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        } else
        {
            fallSpeed = 0;
        }
        if (transform.position.y < target.y)
        {
            transform.position = new Vector3(transform.position.x, target.y, transform.position.z);
            fallSpeed = 0;
        }
    }

    private void GetTarget()
    {
        Debug.DrawRay(this.transform.position, Vector3.down * 200, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position + (Vector3.up * 2), Vector3.down * 200, out hit, Mathf.Infinity, mask))
        {
          //  Debug.Log(hit.collider.gameObject.name);

            if (hit.collider.gameObject.layer == (LayerMask.NameToLayer("Ground")))
            {
                //player.GetComponentInChildren<Health>().takeDamage(100);
            }

            // TODO: Add conditions for applying gravity
            target = hit.point + Vector3.up * targetHeight;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
