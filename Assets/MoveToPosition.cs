using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPosition : MonoBehaviour
{

    private Vector3 startPosition;
    public float delay;
    public float timeToMove;
    private float moveTimer;

    public LayerMask mask;

    public bool blockable = false;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
        moveTimer = timeToMove;
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if(delay < 0)
        {
            moveTimer -= Time.deltaTime;
            transform.localPosition = Vector3.Lerp( Vector3.zero, startPosition, moveTimer / timeToMove);
        }
        if (blockable)
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position,Vector3.down,out hit, 100, mask)){
                Debug.Log("Should be blocked");
                transform.parent.transform.position = new Vector3(transform.parent.transform.position.x, hit.point.y, transform.parent.transform.position.z);
            }
        }
    }
}
