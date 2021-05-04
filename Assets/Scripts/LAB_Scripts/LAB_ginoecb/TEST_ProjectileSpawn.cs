using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_ProjectileSpawn : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private GameObject instance;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            instance = Instantiate(prefab, this.transform.position, Quaternion.identity);
            Destroy(instance.GetComponent<EnemyProjectile>());
        }
    }
}
