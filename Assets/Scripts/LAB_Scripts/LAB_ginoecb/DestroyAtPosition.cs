using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtPosition : MonoBehaviour
{
    [SerializeField] private Vector2 target;

    private void Update()
    {
        if (Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.z), target) <= 0.1f)
            Destroy(this.gameObject);
    }

    public void SetTarget(Vector3 position)
    {
        target = new Vector2(position.x, position.z);
    }
}
